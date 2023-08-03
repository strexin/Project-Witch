using System;

namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// To set the mana stat.
    /// </summary>
    public interface IMana
    {
        /// <summary>
        /// The maximum value of mana that can be stored.
        /// </summary>
        float MaxMana { get; set; }

        /// <summary>
        /// The current value of mana that can be used.
        /// </summary>
        float CurrentMana { get; set; }

        /// <summary>
        /// Event that called when the current player's mana is depleted.
        /// </summary>
        event Action OnManaDepleted;
    }
}
