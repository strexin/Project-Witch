using System;
using UnityEngine;

namespace Scripts
{
    /// <summary>
    /// Handle the player animator.
    /// </summary>
    public class PlayerAnimation : MonoBehaviour
    {
        /// <summary>
        /// The component that needed to control the player animation.
        /// </summary>
        private Animator _playerAnimator = null;

        /// <summary>
        /// The player move input.
        /// </summary>
        private Vector3 _playerMoveInput = default;

        private float _playerHorizontal = default;

        private float _playerVertical = default;

        /// <summary>
        /// Condition is the player on the broom or not.
        /// </summary>
        private bool _isOnBroom = default;

        private void Awake()
        {
            _playerAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            _isOnBroom = false;
        }

        // Update is called once per frame
        void Update()
        {
            _playerMoveInput = new Vector3(_playerHorizontal, 0.0f, _playerVertical);

            _playerHorizontal = Input.GetAxis("Horizontal");

            _playerVertical = Input.GetAxis("Vertical");



            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isOnBroom)
                {
                    _isOnBroom = false;

                    _playerAnimator.SetBool("OnBroom", _isOnBroom);
                }
                else
                {
                    _isOnBroom = true;

                    _playerAnimator.SetBool("OnBroom", _isOnBroom);
                } 
            }

            if (_playerMoveInput != Vector3.zero)
            {
                _playerAnimator.SetFloat("Speed", Mathf.Abs(_playerHorizontal) + MathF.Abs(_playerVertical));
            }
        }
    }
}