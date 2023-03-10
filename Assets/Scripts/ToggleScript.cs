using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    private GameObject primaryWeaponBox;
    private PrimaryWeaponBox primaryWeaponBoxScript;
    private GameObject statsManager;
    private GameObject toggleGr;
    public int weaponIsChoosing;

    private void Start()
    {
        primaryWeaponBox = GameObject.FindGameObjectWithTag("Weapon Display");
        primaryWeaponBoxScript = primaryWeaponBox.GetComponent<PrimaryWeaponBox>();

        statsManager = GameObject.FindGameObjectWithTag("GameController");

        toggleGr = GameObject.FindGameObjectWithTag("Toggle Group");

        this.GetComponent<Toggle>().group = toggleGr.GetComponent<ToggleGroup>();

        weaponIsChoosing = this.GetComponentInChildren<Item>().weaponNo;
    }

    private void Update()
    {
        if(statsManager.GetComponent<StatsManager>().clearToggleButton)
        {
            this.GetComponent<Toggle>().isOn = false;
        }
    }
    public void onTogglePress()
    {
        if(this.GetComponent<Toggle>().isOn)
        {
            //Set the weapon is being chosen for primary weapon box
            primaryWeaponBoxScript.weaponIsChoosing = weaponIsChoosing;

            //Set the weapon is being chosen for stats manager
            statsManager.GetComponent<StatsManager>().weaponIsChoosing = weaponIsChoosing;

            //Turn off the toggle when click back or done button
            statsManager.GetComponent<StatsManager>().clearToggleButton = false;
        }
        else
        {
            //Set the weapon is being chosen for primary weapon box
            primaryWeaponBoxScript.weaponIsChoosing = 0;

            //Set the weapon is being chosen for stats manager
            statsManager.GetComponent<StatsManager>().weaponIsChoosing = 0;
        }
    }

    public void setOffToggle()
    {
        this.GetComponent<Toggle>().isOn = false;
    }
}
