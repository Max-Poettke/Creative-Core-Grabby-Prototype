using UnityEngine;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour
{
    public static InventoryScript Instance;
    public List<GameObject> InventoryObjects;
    public List<Transform> InventorySlots;
    public int InventorySize = 2;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(GameObject item)
    {
        if (InventoryObjects.Count < InventorySize)
        {
            InventoryObjects.Add(item);
            item.transform.parent = InventorySlots[InventoryObjects.Count - 1];
            item.transform.localPosition = Vector3.zero;
        }
        else
        {
            DisplayMessageScript.Instance.DisplayMessage("Inventory is full");
        }
    }

    public bool RemoveItem()
    {
        if (InventoryObjects.Count > 0)
        {
            Destroy(InventoryObjects[InventoryObjects.Count - 1]);
            InventoryObjects.RemoveAt(InventoryObjects.Count - 1);
            return true;
        }
        return false;
    }
}
