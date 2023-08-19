using ProjectWItch.Scripts.Interfaces;
using UnityEngine;

namespace ProjectWItch.Scripts.Items
{
    /// <summary>
    /// Implementatin of IMagicWand for fire magic wand.
    /// </summary>
    public class FireMagicWand : MonoBehaviour, IMagicWand
    {
        #region IMagicWand

        [field: SerializeField]
        public string SpellElement { get; set; } = default;

        [field: SerializeField]
        public GameObject SpellPrefab { get; set; } = default;

        #endregion
    }
}