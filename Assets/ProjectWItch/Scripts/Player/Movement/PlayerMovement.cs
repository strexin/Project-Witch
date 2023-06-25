using ProjectWItch.Scripts.Interfaces;
using System;
using UnityEngine;

namespace ProjectWitch.Scripts.Player.Movement
{
    /// <summary>
    /// Handle the normal movement for player.
    /// </summary>
    public class PlayerMovement : MonoBehaviour, IMoveData, IPlayerEvent
    {
        #region IMoveData

        [field: Header("Move Data")]

        [field: SerializeField]
        public float MoveSpeed { get; set; } = default;

        [field: SerializeField]
        public float RotationSpeed { get; set; } = default;

        [field: SerializeField]
        public float MaxVelocity { get; set; } = default;

        #endregion

        #region IPlayerEvent

        public event Action<float> OnPlayerMove = default;

        public event Action<bool> OnPlayerChangeBroom = default;

        #endregion

        #region Variable

        /// <summary>
        /// Component that use to calculate the player movement.
        /// </summary>
        private Rigidbody _rb = null;

        /// <summary>
        /// Componnent that use to check ground under the player.
        /// </summary>
        private IGroundCheck _groundCheck = null;

        /// <summary>
        /// Component that use to check move input that is given by player.
        /// </summary>
        private IMoveInput _playerMoveInput = null;

        /// <summary>
        /// TEMPORARY (Component that use to know if player press an action input.)
        /// </summary>
        private IActionInput _playerActionInput = null;

        /// <summary>
        /// The normal ground layer to check if player touch it or not.
        /// </summary>
        [Header("Layer")]

        [SerializeField]
        private LayerMask _groundLayerMask = default;

        #endregion

        #region Mono

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();

            _groundCheck = GetComponent<IGroundCheck>();

            _playerMoveInput = GetComponent<IMoveInput>();

            _playerActionInput = GetComponent<IActionInput>();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _rb.freezeRotation = true;
        }

        private void OnEnable()
        {
            _playerActionInput._onBroomInput += OnBroomChange;
        }

        private void OnDisable()
        {
            _playerActionInput._onBroomInput -= OnBroomChange;
        }

        private void FixedUpdate()
        {
            MoveCalculation();

            DownwardCalculation();
        }

        #endregion

        #region Main

        /// <summary>
        /// To calculate the movement for the player.
        /// </summary>
        private void MoveCalculation()
        {
            OnPlayerMove(_playerMoveInput.MoveInputReader.magnitude);

            if (_groundCheck.IsGrounded(_groundLayerMask) && _playerMoveInput.MoveDirection != Vector3.zero)
            {
                _rb.velocity = Vector3.ClampMagnitude(_playerMoveInput.MoveDirection * MoveSpeed, MaxVelocity);

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_playerMoveInput.MoveDirection), RotationSpeed * Time.deltaTime);
            }
        }

        /// <summary>
        /// To calculate the downward velocity for the player.
        /// </summary>
        private void DownwardCalculation()
        {

            if (!_groundCheck.IsGrounded(_groundLayerMask)) 
            {
                _rb.AddForce(new Vector3(0.0f, -5.0f * Time.deltaTime, 0.0f), ForceMode.Impulse);
            }
        }

        /// <summary>
        /// Change the player from use broom or not.
        /// </summary>
        private void OnBroomChange(bool isBroomPressed)
        {
            OnPlayerChangeBroom.Invoke(isBroomPressed);
        }

        #endregion
    }
}