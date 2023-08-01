using ProjectWItch.Scripts.Interfaces;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectWitch.Scripts.Player.Movement.InputRead
{
    /// <summary>
    /// Implementation of IActionInput for player.
    /// </summary>
    public class PlayerFlyingBroomInput : MonoBehaviour, IBroomInput
    {
        #region IBroomInput

        public bool _onBroomActionPressed { get; set; } = default;

        public event Action<bool> _onBroomInput = null;

        #endregion

        #region Variable

        /// <summary>
        /// Component that use for reading the action input from player.
        /// </summary>
        PlayerInputActions _playerInputAction = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _playerInputAction = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _playerInputAction.Player.Enable();

            _playerInputAction.Player.Broom.performed += OnBroomActionIsPressed;
        }

        private void OnDisable()
        {
            _playerInputAction.Player.Disable();

            _playerInputAction.Player.Broom.performed -= OnBroomActionIsPressed;
        }

        #endregion

        #region Main

        /// <summary>
        /// To change the player condition between on broom or not.
        /// </summary>
        /// <param name="context">
        /// the callback context from input.
        /// </param>
        private void OnBroomActionIsPressed(InputAction.CallbackContext context)
        {
            if (_onBroomActionPressed)
            {
                _onBroomActionPressed = false;

                _onBroomInput.Invoke(_onBroomActionPressed);
            } else
            {
                _onBroomActionPressed = true;

                _onBroomInput.Invoke(_onBroomActionPressed);
            }
        }

        #endregion
    }
}