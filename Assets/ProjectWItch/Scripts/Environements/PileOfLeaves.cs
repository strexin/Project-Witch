using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWItch.Scripts.Environments
{
    /// <summary>
    /// Implementation of IBlowable.
    /// </summary>
    public class PileOfLeaves : MonoBehaviour, IBlowable
    {
        #region Variable

        /// <summary>
        /// Prefab of leaves particle that spawn when leaves get blow by wind.
        /// </summary>
        [SerializeField]
        private GameObject leavesParticle = null;

        #endregion

        #region IBlowable

        public void GetBlow()
        {
            Instantiate(leavesParticle, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        #endregion
    }
}