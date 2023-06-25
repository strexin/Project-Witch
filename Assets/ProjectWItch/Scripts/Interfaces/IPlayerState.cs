namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// The state of player.
    /// </summary>
    public interface IPlayerState
    {
        /// <summary>
        /// Is player on broom or not.
        /// </summary>
        bool OnBroom { get; set; }
    }
}