using Cysharp.Threading.Tasks;

namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Handle the logic for object that can be burned by fire.
    /// </summary>
    public interface IBurnable
    {
        /// <summary>
        /// Make the object burn when got touched by fire.
        /// </summary>
        /// <returns>
        /// return task.
        /// </returns>
        UniTask GetBurn();

        /// <summary>
        /// Condition is the object already burn or not.
        /// </summary>
        bool HasBurned { get; set; }
    }
}