using System;

namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Handle the event that happen for the player.
    /// </summary>
    public interface IPlayerEvent
    {
        /// <summary>
        /// Event that called when the player move.
        /// </summary>
        event Action<float> OnPlayerMove;
    }
}