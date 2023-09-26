using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.ProjectWItch.Scripts.UI
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
        private InventoryObject inventory;

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
        [SerializeField]
        private int ySpaceBetwwenItem;

        /// <summary>
        /// Total slot column that display in inventory UI.
        /// </summary>
        [SerializeField]
        private int numberOfColumn;

        /// <summary>
        /// Component that use to match the slot and item that will be displayed.
        /// </summary>
        private Dictionary<InventorySlot, GameObject> itemDisplayed = new Dictionary<InventorySlot, GameObject>();

        #endregion

        #region Mono

        private void OnEnable()
        {
            UpdateDisplay();
        }

        private void Start()
        {
            CreateDisplay();
        }

        #endregion

        #region Main

        /// <summary>
        /// Make display slot in inventory UI.
        /// </summary>
        private void CreateDisplay()
        {
            for (int i = 0; i < inventory.container.Count; i++)
            {
                var obj = Instantiate(inventory.container[i].item.itemPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                itemDisplayed.Add(inventory.container[i], obj);
            }
        }

        /// <summary>
        /// Get slot position in the inventory UI.
        /// </summary>
        /// <param name="i">
        /// Indeks of slot in inventory UI.
        /// </param>
        /// <returns></returns>
        public Vector3 GetPosition(int i)
        {
            return new Vector3(xStartPos + (xSpaceBetwwenItem * (i % numberOfColumn)), yStartPos + (-ySpaceBetwwenItem * (i / numberOfColumn)), 0.0f);
        }

        /// <summary>
        /// Update the item slot display when there is new item.
        /// </summary>
        private void UpdateDisplay()
        {
            for (int i = 0; i < inventory.container.Count; i++)
            {
                if (itemDisplayed.ContainsKey(inventory.container[i]))
                {
                    itemDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                }
                else
                {
                    var obj = Instantiate(inventory.container[i].item.itemPrefab, Vector3.zero, Quaternion.identity, transform);
                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

                    obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                    itemDisplayed.Add(inventory.container[i], obj);
                }
            }
        }

        #endregion
    }
}
