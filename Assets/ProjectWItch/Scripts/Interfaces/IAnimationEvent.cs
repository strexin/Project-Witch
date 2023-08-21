using System;

namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Handle the event that happen at animation.
    /// </summary>
    public interface IAnimationEvent
    {
        /// <summary>
        /// Event that called when the animation is at attack position.
        /// </summary>
        event Action OnAttackPose;
    }
}