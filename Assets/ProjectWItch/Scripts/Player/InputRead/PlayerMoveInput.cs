using ProjectWItch.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        #endregion

        #region Variable

        /// <summary>
        /// An input action for player.
        /// </summary>
        private PlayerInputActions _playerInputAction = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _playerInputAction = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _playerInputAction.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInputAction.Player.Disable();
        }

        private void Update()
        {
            MoveInputReader = _playerInputAction.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            MoveDirection = new Vector3(MoveInputReader.x, 0.0f, MoveInputReader.y);
        }

        #endregion
    }
}