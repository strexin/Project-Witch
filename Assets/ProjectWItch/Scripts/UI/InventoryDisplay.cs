using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.ProjectWItch.Scripts.UI
{
    public class InventoryDisplay : MonoBehaviour
    {
        public InventoryObject inventory;

        public int xStartPos;
        public int yStartPos;

        public int xSpaceBetwwenItem;
        public int ySpaceBetwwenItem;

        public int numberOfColumn;

        Dictionary<InventorySlot, GameObject> itemDisplayed = new Dictionary<InventorySlot, GameObject>();

        private void OnEnable()
        {
            UpdateDisplay();
        }

        private void Start()
        {
            CreateDisplay();
        }

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

        public Vector3 GetPosition(int i)
        {
            return new Vector3(xStartPos + (xSpaceBetwwenItem * (i % numberOfColumn)), yStartPos + (-ySpaceBetwwenItem * (i % numberOfColumn)), 0.0f);
        }

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
    }
}
