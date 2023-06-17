using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWitch.Scripts.Player.Condition
{
    /// <summary>
    /// Implementation of IGroundCheck for player.
    /// </summary>
    public class PlayerGroundCheck : MonoBehaviour, IGroundCheck
    {
        #region Variable

        /// <summary>
        /// A ray that is used to check the ground.
        /// </summary>
        private Ray _ray = default;

        /// <summary>
        /// The collider that got hit by the raycast.
        /// </summary>
        private RaycastHit _hit = default;

        #endregion

        #region IGroundCheck

        [field: Header("Ground Check")]

        [field: SerializeField]
        public float MaxDistanceCheck { get; set; } = default;

        public bool IsGrounded(LayerMask layer)
        {
            _ray = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Vector3.down);

            if (Physics.Raycast(_ray, out _hit, MaxDistanceCheck, layer))
            {
                return true;
            }

            return false; 
        }

        #endregion
    }
}