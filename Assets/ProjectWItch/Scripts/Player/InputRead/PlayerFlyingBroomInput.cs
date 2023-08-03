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

        public bool _playerOnFlyingBroom { get; set; } = default;

        public event Action<bool> _onBroomInput = null;

        #endregion

        #region Variable

        /// <summary>
        /// Component that use for reading the action input from player.
        /// </summary>
        PlayerInputActions _playerInputAction = null;

        /// <summary>
        /// Component that use to get the current player's mana.
        /// </summary>
        private IMana _playerMana = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _playerInputAction = new PlayerInputActions();

            _playerMana = GetComponent<IMana>();
        }

        private void OnEnable()
        {
            _playerInputAction.Player.Enable();

            _playerInputAction.Player.Broom.performed += OnBroomActionIsPressed;

            _playerMana.OnManaDepleted += OnManaDepleted;
        }

        private void OnDisable()
        {
            _playerInputAction.Player.Disable();

            _playerInputAction.Player.Broom.performed -= OnBroomActionIsPressed;

            _playerMana.OnManaDepleted -= OnManaDepleted;

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
            if (!_playerOnFlyingBroom && _playerMana.CurrentMana > 0)
            {
                _playerOnFlyingBroom = true;

                _onBroomInput.Invoke(_playerOnFlyingBroom);
            } else
            {
                _playerOnFlyingBroom = false;

                _onBroomInput.Invoke(_playerOnFlyingBroom);
            }
        }

        /// <summary>
        /// Change the player condition to normal when mana depleted.
        /// </summary>
        private void OnManaDepleted()
        {
            _playerOnFlyingBroom = false;

            _onBroomInput.Invoke(_playerOnFlyingBroom);
        }

        #endregion
    }
}