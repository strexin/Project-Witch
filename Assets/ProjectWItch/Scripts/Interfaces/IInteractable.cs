namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Object that can be interacted by player.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Called when the player interacted with this object.
        /// </summary>
        void Interact();
    }
}