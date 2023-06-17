namespace Scripts.Interfaces
{
    /// <summary>
    /// The data that needed to make object move.
    /// </summary>
    public interface IMoveData
    {
        /// <summary>
        /// The move speed of an object.
        /// </summary>
        float MoveSpeed { get; set; }

        /// <summary>
        /// The max velocity when moving for an object.
        /// </summary>
        float MaxVelocity { get; set; }

        /// <summary>
        /// The speed of rotation for an object to face the move direction.
        /// </summary>
        float RotationSpeed { get; set; }
    }
}