using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWitch.Scripts.Player.Movement.InputRead
{
    /// <summary>
    /// Implementation of IMoveInput for player.
    /// </summary>
    public class PlayerMoveInput : MonoBehaviour, IMoveInput
    {
        #region IMoveInput

        public Vector2 MoveInputReader { get; set; } = default;
        public Vector3 MoveDirection { get; set; } = default;
        public PlayerInputActions PlayerInputActions { get; set; }

        #endregion

        #region Mono

        private void Awake()
        {
            PlayerInputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            PlayerInputActions.Player.Enable();
        }

        private void OnDisable()
        {
            PlayerInputActions.Player.Disable();
        }

        private void Update()
        {
            MoveInputReader = PlayerInputActions.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            MoveDirection = new Vector3(MoveInputReader.x, 0.0f, MoveInputReader.y);
        }

        #endregion
    }
}