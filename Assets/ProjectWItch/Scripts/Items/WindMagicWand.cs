using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWItch.Scripts.Items
{
    /// <summary>
    /// Implementation of IMagicWand for wind magic wand.
    /// </summary>
    public class WindMagicWand : MonoBehaviour, IMagicWand
    {
        #region IMagicWand

        [field: SerializeField]
        public string SpellElement { get; set; } = default;

        [field: SerializeField]
        public GameObject SpellPrefab { get; set; } = null;

        #endregion

    }
}