using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponStates> stats;
    public int weaponLevel;
    [HideInInspector]
    public bool statsUpdated;

    public Sprite icon;
    public void LevelUp()
    {
        if (weaponLevel < stats.Count - 1)
        {
            weaponLevel++;
            statsUpdated = true;
        }

        if (weaponLevel >= stats.Count - 1)
        {
            PlayerController.instance.fullyLevelledWeapons.Add(this);
            PlayerController.instance.assignWeapons.Remove(this);
        }
    }
}
[System.Serializable]
public class WeaponStates
{
    public float speed, damage, range, timeBetweenAttacks, amount, duration;
    public string upgradeText;
}
