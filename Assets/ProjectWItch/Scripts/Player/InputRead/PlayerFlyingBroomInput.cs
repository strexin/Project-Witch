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

        public bool PlayerOnFlyingBroom { get; set; } = default;

        public event Action<bool> OnBroomInput = null;

        #endregion

        #region Variable

        /// <summary>
        /// Component that use for reading the action input from player.
        /// </summary>
        private PlayerInputActions _playerInputActions = null;

        /// <summary>
        /// Component that use to get the current player's mana.
        /// </summary>
        private IMana _playerMana = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();

            _playerMana = GetComponent<IMana>();
        }

        private void OnEnable()
        {
            _playerInputActions.Player.Enable();

            _playerInputActions.Player.Broom.performed += OnBroomActionIsPressed;

            _playerMana.OnManaDepleted += OnManaDepleted;
        }

        private void OnDisable()
        {
            _playerInputActions.Player.Disable();

            _playerInputActions.Player.Broom.performed -= OnBroomActionIsPressed;

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
            if (!PlayerOnFlyingBroom && _playerMana.CurrentMana > 0)
            {
                PlayerOnFlyingBroom = true;

                OnBroomInput.Invoke(PlayerOnFlyingBroom);
            } else
            {
                PlayerOnFlyingBroom = false;

                OnBroomInput.Invoke(PlayerOnFlyingBroom);
            }
        }

        /// <summary>
        /// Change the player condition to normal when mana depleted.
        /// </summary>
        private void OnManaDepleted()
        {
            PlayerOnFlyingBroom = false;

            OnBroomInput.Invoke(PlayerOnFlyingBroom);
        }

        #endregion
    }
}