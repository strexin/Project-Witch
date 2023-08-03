using ProjectWItch.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.ProjectWItch.Scripts.Player.Stats
{
    /// <summary>
    /// Implementation of IMana for player.
    /// </summary>
    public class PlayerManaSystem : MonoBehaviour, IMana
    {
        #region IMana

        [field: SerializeField]
        public float MaxMana { get; set; } = default;

        [field: SerializeField]
        public float CurrentMana { get; set; } = default;

        public event Action OnManaDepleted = null;

        #endregion

        #region Variable

        /// <summary>
        /// Component that use to know when player using flying broom.
        /// </summary>
        private IBroomEvent _broomEvent = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _broomEvent = GetComponent<IBroomEvent>();
        }

        private void OnEnable()
        {
            _broomEvent.OnUsingFlyingBroom += DecreaseMana;
        }

        private void OnDisable()
        {
            _broomEvent.OnUsingFlyingBroom -= DecreaseMana;
        }

        private void Start()
        {
            CurrentMana = MaxMana;
        }

        #endregion

        #region Main

        /// <summary>
        /// Decreasing mana when player using flying broom.
        /// </summary>
        private void DecreaseMana()
        {
            CurrentMana -= 10.0f * Time.deltaTime;

            CurrentMana = Mathf.Clamp(CurrentMana, 0, MaxMana);

            if (CurrentMana <= 0)
            {
                OnManaDepleted?.Invoke();
            }
        }

        #endregion
    }
}
