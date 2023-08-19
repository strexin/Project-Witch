using System;

namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Handle the input action for an object.
    /// </summary>
    public interface IActionInput
    {
        /// <summary>
        /// An event that called when object press action button.
        /// </summary>
        event Action OnActionPressed;
    }
}