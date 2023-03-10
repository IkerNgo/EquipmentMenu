using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryWeaponBox : MonoBehaviour
{
    [SerializeField] private StatsManager stats;

    public Sprite blankSprite;

    public int weaponIsChoosing;

    private void Update()
    {
        for(int i=0; i<stats.numberWeaponHavingRightNow; i++)
        {
            if (weaponIsChoosing == stats.weaponHave[i].GetComponent<Item>().weaponNo)
            {
                //Set the weapon display same sprite as the weapon
                this.GetComponent<Image>().sprite = stats.weaponHave[i].GetComponent<Image>().sprite;
            }
        }
        if(weaponIsChoosing == 0)
        {
            //If no weapon is being chosen, set weapon display blank
            this.GetComponent<Image>().sprite = blankSprite;
        }
    }
}
