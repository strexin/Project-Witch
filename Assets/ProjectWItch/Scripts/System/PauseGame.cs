using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectWitch.Scripts.System
{
    /// <summary>
    /// Pause the game and show the pause menu UI to player.
    /// </summary>
    public class PauseGame : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Component that use to get the input from player.
        /// </summary>
        private PlayerInputActions _playerInputActions = null;

        /// <summary>
        /// Object that use to show or close the manu panel.
        /// </summary>
        [SerializeField]
        private GameObject pauseMenuPanel = null;

        /// <summary>
        /// Condition where the game is paused by the player or not.
        /// </summary>
        private bool _isPaused = default;

        #endregion

        #region Mono

        private void Awake()
        {
            pauseMenuPanel.SetActive(false);

            _playerInputActions = new PlayerInputActions();

            _playerInputActions.System.Enable();

            _playerInputActions.System.Pause.performed += ShowOrClosePauseMenu;
        }

        private void OnDestroy()
        {
            _playerInputActions.System.Disable();

            _playerInputActions.System.Pause.performed -= ShowOrClosePauseMenu;
        }

        #endregion

        #region Main

        /// <summary>
        /// Called when the player pressed the escape button to show or close the menu panel.
        /// </summary>
        /// <param name="context">
        /// Input context from the player.
        /// </param>
        private void ShowOrClosePauseMenu(InputAction.CallbackContext context)
        {
            if (_isPaused)
            {
                _isPaused = false;

                pauseMenuPanel?.SetActive(false);
            }
            else
            {
                _isPaused = true;

                pauseMenuPanel?.SetActive(true);
            }
        }

        #endregion
    }
}