using UnityEngine;

namespace Scripts.Interfaces
{
    /// <summary>
    /// Handle the input for movement.
    /// </summary>
    public interface IMoveInput
    {
        /// <summary>
        /// The input value that player give when pressed move input.
        /// </summary>
        Vector2 InputRead { get; set; }

        /// <summary>
        /// The direction where the player will move based on the input.
        /// </summary>
        Vector3 MoveDirection { get; set; }
    }
}