using Assets.ProjectWItch.Scripts.Player.Stats;
using ProjectWItch.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectWItch.Scripts.UI
{
    /// <summary>
    /// Handle the value display of player's mana.
    /// </summary>
    [DefaultExecutionOrder(100000)]
    public class PlayerManaUI : MonoBehaviour
    {
        #region Variable 

        /// <summary>
        /// Reference for PlayerManaSystem script to get IMana.
        /// </summary>
        [Header("References")]
        [field: SerializeField]
        private PlayerManaSystem playerManaSystem = null;

        /// <summary>
        /// Component that use to update the player's mana value in UI.
        /// </summary>
        [Space]
        private IMana _playerMana = null;

        /// <summary>
        /// Slider that use to update the mana value in UI.
        /// </summary>
        private Slider _manaUIValue = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _manaUIValue = GetComponent<Slider>();

            _playerMana = playerManaSystem.GetComponent<IMana>();
        }

        private void Start()
        {
            _manaUIValue.maxValue = _playerMana.MaxMana;

            _manaUIValue.value = _playerMana.CurrentMana;
        }

        private void OnEnable()
        {
            _playerMana.OnManaChanged += UpdateManaValue;
        }

        private void OnDisable()
        {
            _playerMana.OnManaChanged -= UpdateManaValue;
        }

        #endregion

        #region Main

        /// <summary>
        /// Update the UI when the value of mana changed.
        /// </summary>
        /// <param name="mana">
        /// The value of player's mana.
        /// </param>
        private void UpdateManaValue(float mana)
        {
            _manaUIValue.value = mana;
        }

        #endregion
    }
}