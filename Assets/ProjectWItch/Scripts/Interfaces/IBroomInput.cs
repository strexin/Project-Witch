using System;

namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Checking if any action input is pressed.
    /// </summary>
    public interface IBroomInput
    {
        /// <summary>
        /// Checking if the broom action is pressed or not.
        /// </summary>
        bool PlayerOnFlyingBroom { get; set; }

        /// <summary>
        /// An event that is use when player pressed the broom input.
        /// </summary>
        event Action<bool> OnBroomPressed;
    }
}