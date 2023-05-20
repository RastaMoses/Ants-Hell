using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    [Header("Text Fields")]
    [SerializeField] TextMeshProUGUI hiveShellText;
    [SerializeField] TextMeshProUGUI playerShellText;
    [SerializeField] List<TextMeshProUGUI> upgradeCostTexts;
    [SerializeField] List<TextMeshProUGUI> upgradeLevelText;

    [SerializeField] GameObject shopCanvas;

    Shop shop;

    private void Start()
    {
        shop = FindAnyObjectByType<Shop>();
        UpdateText();
    }
    public void PressUpgrade(int upgradeInt)
    {
        shop.Upgrade(upgradeInt);
    }

    public void UpdateText()
    {
        int playerShells = shop.playerShells;
        int hiveShells = shop.hiveShells;

        
        //Update Level Text
        for (int i = 0; i < upgradeLevelText.Count; i++)
        {
            if (!shop.upgrades[i].infiniteUpgrades)
            {
                upgradeLevelText[i].text = shop.upgradeLvls[i] + "/" + shop.upgrades[i].costs.Count;
            }
            
        }
        //Update Cost Text
        
        for (int i= 0; i < upgradeCostTexts.Count; i++)
        {
            if (!shop.upgrades[i].infiniteUpgrades && shop.upgradeLvls[i] < shop.upgrades[i].costs.Count)
            {
                upgradeCostTexts[i].text = shop.upgrades[i].costs[shop.upgradeLvls[i]].ToString();

            }
        }
        //Update Resource Texts
        hiveShellText.text= hiveShells.ToString();
        //playerShellText.text= shop.playerShells.ToString();
    }

    public void UpdateHealthHiveDisplay(int health)
    {

    }

    public void UpdateHealthPlayerDisplay(int health)
    {

    }

    public void ToggleShop(bool open)
    {
        shopCanvas.SetActive(open);
    }
}
