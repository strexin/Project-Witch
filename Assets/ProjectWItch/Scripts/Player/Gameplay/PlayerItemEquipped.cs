using ProjectWItch.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectWitch.Scripts.Player.Gameplay
{
    /// <summary>
    /// Implementation of IEquip for player.
    /// </summary>
    public class PlayerItemEquipped : MonoBehaviour, IEquip
    {
        #region IEquip

        [field: SerializeField]
        public int ItemSlot { get; set; } = default;

        [field: SerializeField]
        public GameObject[] ItemsGameobject { get; set; } = null;

        public GameObject ItemEquipped { get; set; } = null;

        #endregion

        #region Variable

        /// <summary>
        /// Component that use to get the change equipment input from player.
        /// </summary>
        private PlayerInputActions _playerInputActions = null;

        #endregion

        #region Mono

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _playerInputActions.Enable();

            _playerInputActions.Player.ChangeItem.performed += ChangeEquippedItem;
        }

        private void OnDisable()
        {
            _playerInputActions.Disable();

            _playerInputActions.Player.ChangeItem.performed -= ChangeEquippedItem;
        }

        private void Start()
        {
            ItemEquipped = ItemsGameobject[0];

            ItemsGameobject[0].SetActive(true);

            ItemsGameobject[1].SetActive(false);
            ItemsGameobject[2].SetActive(false);

            Debug.Log(ItemEquipped.name);

            Debug.Log(ItemsGameobject.Length);
        }

        #endregion

        #region Main

        /// <summary>
        /// Change the equipped item when player press the change item button.
        /// </summary>
        private void ChangeEquippedItem(InputAction.CallbackContext context)
        {
            var currentIndex = 0;

            ItemsGameobject[0].SetActive(false);
            ItemsGameobject[1].SetActive(false);
            ItemsGameobject[2].SetActive(false);

            for (int i = 0; i < ItemsGameobject.Length; i++) 
            {
                if (ItemsGameobject[i] == ItemEquipped)
                {
                    currentIndex = i;

                    Debug.Log(currentIndex);

                    break;
                }
            }

            if (currentIndex + 1 > ItemsGameobject.Length - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex += 1;

                Debug.Log(currentIndex);
            }

            ItemEquipped = ItemsGameobject[currentIndex];

            ItemsGameobject[currentIndex].SetActive(true);

            Debug.Log(ItemEquipped.name);
        }

        #endregion
    }
}