using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    [Header("Weapon Infomation")]
    [SerializeField] private Text weaponName;
    [SerializeField] private Text damage;
    [SerializeField] private Text dispersion;
    [SerializeField] private Text rateOfFire;
    [SerializeField] private Text reloadSpeed;
    [SerializeField] private Text ammunition;
    [Header("")]
    [SerializeField] private GameObject primaryWeaponBox;
    [SerializeField] private GameObject scrollBar;
    [SerializeField] private GameObject slider;

    public int numberWeaponHavingRightNow;

    public Item[] items;

    public GameObject[] weaponHave;

    public int weaponIsChoosing;

    public bool clearToggleButton;

    private void Awake()
    {
        weaponHave = GameObject.FindGameObjectsWithTag("Weapon");       //Get all weapon
        numberWeaponHavingRightNow = weaponHave.Length;                 //Calculate how many weapon are there
        items = new Item[numberWeaponHavingRightNow];                   //Create an array contains all the scripts of the weapon

        for (int i = 0; i < weaponHave.Length; i++)                     //Item[1] is weapon 1's script and so on.
        {
            items[weaponHave[i].GetComponent<Item>().weaponNo - 1] = weaponHave[i].GetComponent<Item>();
        }

        weaponIsChoosing = 0;                                           //Start with no weapon is being chosen
        clearToggleButton = false;
    }

    private void Update()
    {
        //If a weapon is being chosen, display it's infomation
        if (weaponIsChoosing != 0)
        {
            weaponName.text = items[weaponIsChoosing - 1].weaponName;
            damage.text = items[weaponIsChoosing - 1].damage + "";
            dispersion.text = items[weaponIsChoosing - 1].dispersion + "";
            rateOfFire.text = items[weaponIsChoosing - 1].rateOfFire + "RPM";
            reloadSpeed.text = items[weaponIsChoosing - 1].reloadSpeed + "%";
            ammunition.text = items[weaponIsChoosing - 1].ammunition + "/" + items[weaponIsChoosing - 1].ammunition;
        }
        else
        {
            weaponName.text = "";
            damage.text = "";
            dispersion.text = "";
            rateOfFire.text = "";
            reloadSpeed.text = "";
            ammunition.text = "";
        }
    }
    public void bnbButtonPress()
    {
        if (weaponIsChoosing != 0)
        {
            items[weaponIsChoosing - 1].damage += 2;
            items[weaponIsChoosing - 1].dispersion += 1;
            items[weaponIsChoosing - 1].rateOfFire += 50;
            items[weaponIsChoosing - 1].reloadSpeed += 1;
            items[weaponIsChoosing - 1].ammunition += 50;
        }
    }

    public void ewarButtonPress()
    {
        if (weaponIsChoosing != 0)
        {
            items[weaponIsChoosing - 1].damage += 3;
            items[weaponIsChoosing - 1].dispersion += 2;
            items[weaponIsChoosing - 1].rateOfFire += 100;
            items[weaponIsChoosing - 1].reloadSpeed += 2;
            items[weaponIsChoosing - 1].ammunition += 100;
        }
    }

    //When hit back or done button will get no weapon is being displayed and turn off all toggle still on
    public void doneVsBackButton()
    {
        primaryWeaponBox.GetComponent<PrimaryWeaponBox>().weaponIsChoosing = 0;
        weaponIsChoosing = 0;
        clearToggleButton = true;
    }

    //Use button just can click only when the item have been rented
    public void useButton()                         
    {
        if (weaponIsChoosing != 0 && items[weaponIsChoosing - 1].weaponStatus!=Item.ItemStatus.none)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].weaponStatus == Item.ItemStatus.rented)
                {
                    if (i == (weaponIsChoosing - 1))
                    {
                        items[weaponIsChoosing - 1].weaponStatus = Item.ItemStatus.used;
                        items[weaponIsChoosing - 1].change = true;
                    }
                }
                else if (items[i].weaponStatus==Item.ItemStatus.used)
                {
                    items[i].weaponStatus=Item.ItemStatus.none;
                    items[i].change = true;
                }
            }
        }
    }

    //Set status rented to the toggle
    public void rentOutButton()
    {
        if (weaponIsChoosing != 0)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (i == weaponIsChoosing - 1)
                {
                    items[weaponIsChoosing - 1].weaponStatus = Item.ItemStatus.rented;
                    items[weaponIsChoosing - 1].change = true;
                    continue;
                }
                else if (items[i].weaponStatus!=Item.ItemStatus.used)
                {
                    items[i].weaponStatus = Item.ItemStatus.none;
                    items[i].change = true;
                }
            }
        }
    }

    //Make the fixed size handle of scrollbar (using slider)
    public void getFixedHandleBar()
    {
      slider.GetComponent<Slider>().value = scrollBar.GetComponent<Scrollbar>().value;
    }
}
