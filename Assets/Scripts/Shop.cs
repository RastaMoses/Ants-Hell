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

    public GameObject player;

    public GameObject turretOutPost;
    public GameObject magnetOutPost;
    public GameObject shieldOutPost;
    public GameObject slowOutPost;




    private void Start()
    {
        
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
                if (upgradeNumber == 4)
                {
                    //Magnet
                    player.GetComponent<PlayerController>().magnet.ChangeRadius(upgrades[upgradeNumber].upgradeStats[upgradeLvls[upgradeNumber]]);
                }
                else if (upgradeNumber == 5)
                {
                    player.GetComponent<PlayerStats>().movementSpeed = upgrades[upgradeNumber].upgradeStats[upgradeLvls[upgradeNumber]];
                }
                else if (upgradeNumber == 6)
                {
                    player.GetComponent<PlayerStats>().maxHP = upgrades[upgradeNumber].upgradeStats[upgradeLvls[upgradeNumber]];
                }
                else if (upgradeNumber == 7)
                {
                    player.GetComponent<PlayerStats>().carryCapacity = upgrades[upgradeNumber].upgradeStats[upgradeLvls[upgradeNumber]];
                }

                else if (upgradeNumber == 9)
                {
                    player.GetComponent<PlayerStats>().Inventory = shieldOutPost;
                }
                else if (upgradeNumber == 10)
                {
                    player.GetComponent<PlayerStats>().Inventory = turretOutPost;
                }
                else if (upgradeNumber == 11)
                {
                    player.GetComponent<PlayerStats>().Inventory = magnetOutPost;
                }
                else if (upgradeNumber == 12)
                {
                    player.GetComponent<PlayerStats>().Inventory = slowOutPost;
                }
                else if (upgradeNumber == 0)
                {

                }
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

    public void leaveHive()
    {
        Time.timeScale = 1;
        canvas.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void EnteredHive()
    {
        Time.timeScale = 0;
        hiveShells += player.GetComponent<PlayerStats>().shells;
        player.GetComponent<PlayerStats>().shells = 0;
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        UpdateUI();
        //Open canvas
    }
}
