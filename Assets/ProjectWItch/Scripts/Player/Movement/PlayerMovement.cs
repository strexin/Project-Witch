using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWitch.Scripts.Player.Movement
{
    /// <summary>
    /// Handle the normal movement for player.
    /// </summary>
    public class PlayerMovement : MonoBehaviour, IMoveData
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

        #region Variable

        /// <summary>
        /// Component that use to calculate the player movement.
        /// </summary>
        private Rigidbody _rb = null;

        /// <summary>
        /// Condition where the player is using flying broom or not.
        /// </summary>
        private bool _isUsingFlyingBroom = default;

        /// <summary>
        /// Componnent that use to check ground under the player.
        /// </summary>
        private IGroundCheck _groundCheck = null;

        /// <summary>
        /// Component that use to check move input that is given by player.
        /// </summary>
        private IMoveInput _playerMoveInput = null;

        /// <summary>
        /// Component that use to know the player is using flying broom or not.
        /// </summary>
        private IBroomInput _broomInput = default;

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

            _broomInput = GetComponent<IBroomInput>();
        }

        private void Start()
        {
/*            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;*/

            _rb.freezeRotation = true;
        }

        private void OnEnable()
        {
            _broomInput.OnBroomInput += CheckPlayerUsingFLyingBroom;
        }

        private void OnDisable()
        {
            _broomInput.OnBroomInput -= CheckPlayerUsingFLyingBroom;
        }

        private void FixedUpdate()
        {
            MoveCalculation();
            StopMovement();
            DownwardCalculation();
        }

        #endregion

        #region Main

        /// <summary>
        /// To calculate the movement for the player.
        /// </summary>
        private void MoveCalculation()
        {
            if (_groundCheck.IsGrounded(_groundLayerMask) && _playerMoveInput.MoveDirection != Vector3.zero && !_isUsingFlyingBroom)
            {
                _rb.velocity = Vector3.ClampMagnitude(_playerMoveInput.MoveDirection * MoveSpeed, MaxVelocity);

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_playerMoveInput.MoveDirection), RotationSpeed * Time.deltaTime);
            }
        }

        /// <summary>
        /// To stop the player when there is no move input value.
        /// </summary>
        private void StopMovement()
        {
            if (_playerMoveInput.MoveInputReader.magnitude == 0.0f && _groundCheck.IsGrounded(_groundLayerMask) && !_isUsingFlyingBroom)
            {
                _rb.velocity = Vector3.Lerp(_rb.velocity, Vector3.zero, 0.1f);
            }
        }

        /// <summary>
        /// To calculate the downward velocity for the player.
        /// </summary>
        private void DownwardCalculation()
        {
            if (!_groundCheck.IsGrounded(_groundLayerMask) && !_isUsingFlyingBroom) 
            {
                _rb.AddForce(new Vector3(0.0f, -5.0f * Time.deltaTime, 0.0f), ForceMode.Impulse);
            }
        }

        /// <summary>
        /// Change the condition is the player using flying broom or not.
        /// </summary>
        /// <param name="onBroom">
        /// Condition of the player is using flying broom or not.
        /// </param>
        private void CheckPlayerUsingFLyingBroom(bool onBroom)
        {
            _isUsingFlyingBroom = onBroom;
        }

        #endregion
    }
}