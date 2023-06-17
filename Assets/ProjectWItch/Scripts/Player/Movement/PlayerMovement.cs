using Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Player.PlayerInput
{
    /// <summary>
    /// Handle the movement for player.
    /// </summary>
    public class PlayerMovement : MonoBehaviour, IMoveInput, IMoveData
    {
        #region IMoveInput

        public Vector3 MoveDirection { get; set; } = default;
        public Vector2 InputRead { get; set; } = default;

        #endregion

        #region IMoveData

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
        private Rigidbody _rb;

        /// <summary>
        /// An input action for player.
        /// </summary>
        private PlayerInputActions _playerInputAction = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();

            _playerInputAction = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _playerInputAction.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInputAction.Player.Disable();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _rb.freezeRotation = true;
        }

        private void Update()
        {
            InputRead = _playerInputAction.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            MoveCalculation();

            DownwardCalculation();
        }

        #endregion

        #region Main

        private void MoveCalculation()
        {
            MoveDirection = new Vector3(InputRead.x, 0.0f, InputRead.y);

            if (IsGrounded())
            {
                _rb.AddForce(MoveDirection * MoveSpeed, ForceMode.Impulse);

                _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, MaxVelocity);

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveDirection), RotationSpeed * Time.deltaTime);
            }
        }

        private void DownwardCalculation()
        {
            if (!IsGrounded()) 
            {
                _rb.AddForce(new Vector3(0.0f, -5.0f * Time.deltaTime, 0.0f), ForceMode.Impulse);
            }
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Vector3.down, 0.8f);
        }

        #endregion
    }
}