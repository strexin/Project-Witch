using System;

namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Handle the event that happen when player using broom.
    /// </summary>
    public interface IBroomEvent
    {
        /// <summary>
        /// Event that called when the player is using flying broom.
        /// </summary>
        event Action OnUsingFlyingBroom;
    }
}