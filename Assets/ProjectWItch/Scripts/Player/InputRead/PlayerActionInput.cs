﻿using ProjectWItch.Scripts.Interfaces;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.ProjectWItch.Scripts.Player.InputRead
{
    /// <summary>
    /// Implementation of IActionInput for player.
    /// </summary>
    public class PlayerActionInput : MonoBehaviour, IActionInput
    {
        #region IActionInput

        public event Action OnActionPressed = null;

        #endregion

        #region Variable

        /// <summary>
        /// position that use as the start position when spawn a spell.
        /// </summary>
        [SerializeField]
        private Transform shotPoint = null;

        /// <summary>
        /// Component that use to get the player input for action button.
        /// </summary>
        private PlayerInputActions _playerInputActions = null;

        /// <summary>
        /// Component to get what item that equipped by player.
        /// </summary>
        private IEquip _playerEquip = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();

            _playerEquip = GetComponent<IEquip>();
        }

        private void OnEnable()
        {
            _playerInputActions.Player.Enable();

            _playerInputActions.Player.Action.performed += OnActionInputPressed;
        }

        private void OnDisable()
        {
            _playerInputActions.Player.Disable();

            _playerInputActions.Player.Action.performed -= OnActionInputPressed;
        }

        #endregion

        #region Main

        /// <summary>
        /// Send event when player pressed action input.
        /// </summary>
        /// <param name="context">
        /// return context.
        /// </param>
        private void OnActionInputPressed(InputAction.CallbackContext context)
        {
            OnActionPressed.Invoke();

            if (_playerEquip.ItemEquipped.GetComponent<IMagicWand>() != null )
            {
                Instantiate(_playerEquip.ItemEquipped.GetComponent<IMagicWand>().SpellPrefab, shotPoint.position, gameObject.transform.rotation);
            }
        }

        #endregion
    }
}
