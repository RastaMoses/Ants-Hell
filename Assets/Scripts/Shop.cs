using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Upgrades")]
    [SerializeField] public List<UpgradeScriptableObject> upgrades;
    public List<int> upgradeLvls;

    [SerializeField] Canvas canvas;
    public int playerShells;
    public int hiveShells;


    public int GetCost(int upgradeNumber)
    {
        if (upgrades[upgradeNumber].infiniteUpgrades)
        {
            return upgrades[upgradeNumber].costs[0];
        }
        return upgrades[upgradeNumber].costs[upgradeLvls[upgradeNumber]];
    }

    public void Upgrade(int upgradeNumber)
    {
        if (upgradeLvls[upgradeNumber] >= upgrades[upgradeNumber].costs.Count)
        {
            Debug.Log("Max Level reached");
        }

        else if (GetCost(upgradeNumber) > hiveShells)
        {
            //Too expensive
            //Play SFX
            Debug.Log("Not enough cash");
        }
        else
        {
            //Enough money
            hiveShells -= GetCost(upgradeNumber);
            upgradeLvls[upgradeNumber]++;
            //Send upgrade update to turret and player
        }
        UpdateUI();
    }
    
    public void AddShellsToPlayer(int amount)
    {
        playerShells += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        FindObjectOfType<UIController>().UpdateText();
    }

    public void EnteredHive()
    {
        hiveShells += playerShells;
        playerShells = 0;
        //Open canvas
    }
}
