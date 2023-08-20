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
        /// Component that use to know the move input from the player.
        /// </summary>
        private IMoveInput _moveInput = null;

        /// <summary>
        /// Component that use to know the player use flying broom or not.
        /// </summary>
        private IBroomInput _broomInput = null;

        /// <summary>
        /// Component that use to know when the player pressed action input.
        /// </summary>
        private IActionInput _actionInput = null;

        /// <summary>
        /// Component that use to get the player input action.
        /// </summary>
        private PlayerInputActions _playerInputActions = null;

        #endregion

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();

            _playerAnimator = GetComponent<Animator>();

            _moveInput = GetComponentInParent<IMoveInput>();

            _broomInput = GetComponentInParent<IBroomInput>();

            _actionInput = GetComponentInParent<IActionInput>();
        }

        private void Update()
        {
            _playerAnimator.SetFloat("Speed", Mathf.Abs(_moveInput.MoveInputReader.magnitude));
        }

        private void OnEnable()
        {
            _broomInput.OnBroomPressed += OnPlayerUseBroom;

            _actionInput.OnActionPressed += OnPlayerPressedAction;
        }

        private void OnDisable()
        {
            _broomInput.OnBroomPressed -= OnPlayerUseBroom;

            _actionInput.OnActionPressed -= OnPlayerPressedAction;
        }

        #region Main

        /// <summary>
        /// Change the condition of the animation when player use broom or not.
        /// </summary>
        /// <param name="useBroom">
        /// The condition is the player using flying broom or not.
        /// </param>
        private void OnPlayerUseBroom(bool useBroom)
        {
            _playerAnimator.SetBool("OnBroom", useBroom);
        }

        /// <summary>
        /// Play the animation of player using spell when pressed action input.
        /// </summary>
        private void OnPlayerPressedAction()
        {
            _playerAnimator.SetTrigger("Spell");
        }

        /// <summary>
        /// Make player cannot move by disable the move input.
        /// </summary>
        public void DisablePlayerMove()
        {
            _playerInputActions.Player.Disable();
        }

        /// <summary>
        /// Make player can move by enable the move input.
        /// </summary>
        public void EnablePlayerMove()
        {
            _playerInputActions.Player.Enable();
        }

        #endregion
    }
}