using ProjectWItch.Scripts.Interfaces;
using System.Threading.Tasks;
using UnityEngine;

namespace ProjectWItch.Scripts.Environments
{
    /// <summary>
    /// Implementation of IBurnable for thorn.
    /// </summary>
    public class Thorn : MonoBehaviour, IBurnable
    {
        #region IBurnable

        public bool HasBurned { get; set; }

        public async Task GetBurn()
        {
            
        }

        #endregion
    }
}