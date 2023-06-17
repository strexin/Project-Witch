using ProjectWItch.Scripts.Interfaces;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectWitch.Scripts.Player.Movement
{
    /// <summary>
    /// Handle the movement for player.
    /// </summary>
    public class PlayerMovement : MonoBehaviour, IMoveInput, IMoveData, IPlayerEvent
    {
        #region IMoveInput

        public Vector3 MoveDirection { get; set; } = default;
        public Vector2 MoveInputReader { get; set; } = default;

        #endregion

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
        /// An input action for player.
        /// </summary>
        private PlayerInputActions _playerInputAction = null;

        /// <summary>
        /// Condition which the player is on broom or not.
        /// </summary>
        private bool _onBroom = default;

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

            _playerInputAction = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _playerInputAction.Player.Enable();

            _playerInputAction.Player.Broom.performed += OnBroomChange;
        }

        private void OnDisable()
        {
            _playerInputAction.Player.Disable();

            _playerInputAction.Player.Broom.performed -= OnBroomChange;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _rb.freezeRotation = true;
        }

        private void Update()
        {
            MoveInputReader = _playerInputAction.Player.Move.ReadValue<Vector2>();
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
            MoveDirection = new Vector3(MoveInputReader.x, 0.0f, MoveInputReader.y);

            OnPlayerMove(MoveInputReader.magnitude);

            if (_groundCheck.IsGrounded(_groundLayerMask) && MoveDirection != Vector3.zero)
            {
                _rb.velocity = Vector3.ClampMagnitude(MoveDirection * MoveSpeed, MaxVelocity);

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveDirection), RotationSpeed * Time.deltaTime);
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
        /// <param name="context">
        /// THe button callback context from input system. 
        /// </param>
        private void OnBroomChange(InputAction.CallbackContext context)
        {
            if (_onBroom)
            {
                _onBroom = false;
                OnPlayerChangeBroom(_onBroom);
            }
            else
            {
                _onBroom = true;
                OnPlayerChangeBroom(_onBroom);
            }
        }

        #endregion
    }
}