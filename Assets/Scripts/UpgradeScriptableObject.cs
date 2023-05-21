using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/Upgrade", order = 1)]
public class UpgradeScriptableObject : ScriptableObject
{
    public string upgradeName;
    public bool infiniteUpgrades;
    public List<int> costs;
    public bool playerUpgrade;
    public List<float> upgradeStats;
}
