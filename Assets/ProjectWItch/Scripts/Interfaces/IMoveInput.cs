using UnityEngine;

namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Handle the input for movement.
    /// </summary>
    public interface IMoveInput
    {
        /// <summary>
        /// The input value that player give when pressed move input.
        /// </summary>
        Vector2 MoveInputReader { get; set; }

        /// <summary>
        /// The direction where the player will move based on the input.
        /// </summary>
        Vector3 MoveDirection { get; set; }

        /// <summary>
        /// An input action for player.
        /// </summary>
        PlayerInputActions PlayerInputActions { get; set; }
    }
}