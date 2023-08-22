namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Handle the object that can be blowed by wind.
    /// </summary>
    public interface IBlowable
    {
        /// <summary>
        /// Destroy the gameobject when contact with wind and spawn leaves particle.
        /// </summary>
        void GetBlow();
    }
}