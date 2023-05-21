using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject player;
    public PlayerStats stats;
    public GameObject InventoryText;
    public GameObject InventoryImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.Inventory != null)
        {
            InventoryText.SetActive(false);
            InventoryImage.SetActive(true);
            InventoryImage.GetComponent<SpriteRenderer>().sprite = stats.Inventory.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            InventoryText.GetComponent<TextMeshProUGUI>().text = "Inventory:" + stats.shells.ToString() + "/" + stats.carryCapacity.ToString() + "Shells";
            InventoryText.SetActive(true);
            InventoryImage.SetActive(false);
        }
    }
}
