using ProjectWItch.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectWitch.Scripts.Player.Gameplay
{
    public class PlayerInteract : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Component that use to get the action input from player.
        /// </summary>
        private PlayerInputActions _playerInputActions = null;
        
        /// <summary>
        /// Condition where the player can interact with interactable or not.
        /// </summary>
        private bool _canInteract = default;

        /// <summary>
        /// Store the object that player can interact with.
        /// </summary>
        private IInteractable _interactable = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _playerInputActions.Enable();

            _playerInputActions.Player.Action.performed += NearInteractable;
        }

        private void OnDisable()
        {
            _playerInputActions.Disable();

            _playerInputActions.Player.Action.performed -= NearInteractable;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<IInteractable>() != null)
            {
                _interactable = other.gameObject.GetComponent<IInteractable>();

                _canInteract = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<IInteractable>() != null)
            {
                _interactable = null;

                _canInteract = false;
            }
        }

        #endregion

        #region Main

        /// <summary>
        /// Called when the player pressed action input and check if there is interactable nearby.
        /// </summary>
        /// <param name="context">
        /// input action context for player input.
        /// </param>
        private void NearInteractable(InputAction.CallbackContext context)
        {
            if (_canInteract && _interactable != null)
            {
                _interactable.Interact();
            }
        }

        #endregion
    }
}