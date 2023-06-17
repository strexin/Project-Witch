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

        #endregion

        #region IGroundCheck

        [field: Header("Ground Check")]

        [field: SerializeField]
        public float MaxDistanceCheck { get; set; } = default;

        public bool IsGrounded(string tag)
        {
            var _downRay = Physics.Raycast(_ray, MaxDistanceCheck);

            Debug.DrawRay(transform.position, Vector3.down, Color.red);

            if (tag == "Ground")
            {
                return _downRay;
            }

            return false;
        }

        #endregion

        #region Mono

        private void Start()
        {
            _ray = new Ray(transform.position, Vector3.down);
        }

        #endregion
    }
}