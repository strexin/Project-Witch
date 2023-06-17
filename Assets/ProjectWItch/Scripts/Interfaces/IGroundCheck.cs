namespace ProjectWItch.Scripts.Interfaces
{
    /// <summary>
    /// Handle if the object is on the ground with tag or not.
    /// </summary>
    public interface IGroundCheck
    {
        /// <summary>
        /// Checking if the object is touching ground with tag or not.
        /// </summary>
        /// <param name="tag">
        /// The tag of ground that wanted to be checked.
        /// </param>
        /// <returns>
        /// Object is touch ground or not.
        /// </returns>
        bool IsGrounded(string tag);

        /// <summary>
        /// The max distance of the ray for checking the ground.
        /// </summary>
        float MaxDistanceCheck { get; set; }
    }
}
