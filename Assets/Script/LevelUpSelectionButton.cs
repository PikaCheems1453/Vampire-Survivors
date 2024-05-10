using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpSelectionButton : MonoBehaviour
{
    public TMP_Text upgradeDescText,nameLevelText;
    public Image weaponIcon;

    private Weapon assignWeapon;

    public void UpdataButtonDisplay(Weapon theWeapon)
    {
        if(theWeapon.gameObject.activeSelf == true)
        {
            upgradeDescText.text = theWeapon.stats[theWeapon.weaponLevel].upgradeText;
            weaponIcon.sprite = theWeapon.icon;
            nameLevelText.text = theWeapon.name + " - Lvl " + theWeapon.weaponLevel;
        }
        else
        {
            upgradeDescText.text = "Unlock " + theWeapon.name;
            weaponIcon.sprite = theWeapon.icon;
            nameLevelText.text = theWeapon.name;
        }
        assignWeapon = theWeapon;
    }
    
    public void SelectUpgrade()
    {
        if(assignWeapon != null)
        {
            if(assignWeapon.gameObject.activeSelf == true)
            {
                assignWeapon.LevelUp();
            }
            else
            {
                PlayerController.instance.AddWeapon(assignWeapon);
            }
            
            UIController.instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}
