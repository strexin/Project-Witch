using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWItch.Scripts.Animation
{
    /// <summary>
    /// Handle the player animator.
    /// </summary>
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// The component that needed to control the player animation.
        /// </summary>
        private Animator _playerAnimator = null;

        /// <summary>
        /// Component that use to get the event for the player.
        /// </summary>
        private IPlayerEvent _playerEvent = null;

        #endregion

        private void Awake()
        {
            _playerAnimator = GetComponent<Animator>();

            _playerEvent = GetComponentInParent<IPlayerEvent>();
        }

        private void OnEnable()
        {
            _playerEvent.OnPlayerMove += OnPlayerMoveAnimation;
        }

        private void OnDisable()
        {
            _playerEvent.OnPlayerMove -= OnPlayerMoveAnimation;
        }

        #region Main

        /// <summary>
        /// Change the value of the move animation based on player input value.
        /// </summary>
        /// <param name="speed">
        /// The speed value that player give when move.
        /// </param>
        private void OnPlayerMoveAnimation(float speed)
        {
            _playerAnimator.SetFloat("Speed", speed);
        }

        #endregion
    }
}