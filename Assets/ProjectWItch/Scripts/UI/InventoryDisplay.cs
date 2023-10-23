using System.Collections.Generic;
using ProjectWItch.Scripts.Items;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ProjectWItch.Scripts.UI
{
    /// <summary>
    /// Handle the display item that player stored in inventory.
    /// </summary>
    public class InventoryDisplay : MonoBehaviour
    {
        #region Variable

        /// <summary>
        /// Component that use to get item that stored in inventory.
        /// </summary>
        [SerializeField]
        private InventoryObject _inventory;

        /// <summary>
        /// Start position for displaying item in X axis.
        /// </summary>
        [SerializeField]
        private int xStartPos;

        /// <summary>
        /// Start position for displaying item in Y axis.
        /// </summary>
        [SerializeField]
        private int yStartPos;

        /// <summary>
        /// The space between item display slot in X axis.
        /// </summary>
        [SerializeField]
        private int xSpaceBetwwenItem;

        /// <summary>
        /// The space between item display slot in Y axis.
        /// </summary>
        [FormerlySerializedAs("ySpaceBetwwenItem")] [SerializeField]
        private int ySpaceBetweenItem;

        /// <summary>
        /// Total slot column that display in inventory UI.
        /// </summary>
        [SerializeField]
        private int numberOfColumn;

        /// <summary>
        /// Component that use to match the slot and item that will be displayed.
        /// </summary>
        private readonly Dictionary<InventorySlot, GameObject> _itemDisplayed = new Dictionary<InventorySlot, GameObject>();

        #endregion

        #region Mono

        private void OnEnable()
        {
            UpdateDisplay();
        }

        #endregion

        #region Main

        /// <summary>
        /// Get slot position in the inventory UI.
        /// </summary>
        /// <param name="i">
        /// Index of slot in inventory UI.
        /// </param>
        /// <returns></returns>
        private Vector3 GetPosition(int i)
        {
            return new Vector3(xStartPos + (xSpaceBetwwenItem * (i % numberOfColumn)), yStartPos + (-ySpaceBetweenItem * (i / numberOfColumn)), 0.0f);
        }

        /// <summary>
        /// Update the item slot display when there is new item.
        /// </summary>
        private void UpdateDisplay()
        {
            for (int i = 0; i < _inventory.container.Count; i++)
            {
                if (_itemDisplayed.ContainsKey(_inventory.container[i]))
                {
                    _itemDisplayed[_inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = _inventory.container[i].amount.ToString("n0");
                }
                else
                {
                    var obj = Instantiate(_inventory.container[i].item.itemPrefab, Vector3.zero, Quaternion.identity, transform);

                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = _inventory.container[i].amount.ToString("n0");
                    obj.GetComponentInChildren<Image>().sprite = _inventory.container[i].sprite;

                    Debug.Log(_inventory.container[i].sprite);

                    _itemDisplayed.Add(_inventory.container[i], obj);
                }
            }
        }

        #endregion
    }
}
