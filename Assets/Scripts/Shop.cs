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

    public PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
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
            if (upgrades[upgradeNumber].playerUpgrade)
            {
                if(upgradeNumber == 4)
                {
                    //Magnet
                    player.magnet.ChangeRadius(upgrades[upgradeNumber].upgradeStats[upgradeLvls[upgradeNumber]]);
                }
                else if (upgradeNumber== 5)
                {
                    player.stats.movementSpeed = upgrades[upgradeNumber].upgradeStats[upgradeLvls[upgradeNumber]];
                }
                else if (upgradeNumber == 6)
                {
                    player.stats.maxHP = upgrades[upgradeNumber].upgradeStats[upgradeLvls[upgradeNumber]];
                }
                else if(upgradeNumber == 7)
                {
                    player.stats.carryCapacity = upgrades[upgradeNumber].upgradeStats[upgradeLvls[upgradeNumber]];
                }
            }
            else if (upgradeNumber == 0)
            {

            }
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
        hiveShells += player.GetComponent<PlayerStats>().shells;
        player.GetComponent<PlayerStats>().shells = 0;
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        //Open canvas
    }
}
