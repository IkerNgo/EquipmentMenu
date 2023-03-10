using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("Weapon Stats")]
    public int weaponNo;

    public string weaponName;

    public int damage, dispersion, rateOfFire, reloadSpeed, ammunition;

    private Image weaponSprite;

    public ItemStatus weaponStatus;
    [Header("")]
    [SerializeField] private GameObject usedText, rentedOutText, statusDisplayParent;

    private GameObject statusDisplay;

    public bool change, rentedOut;

    private void Awake()
    {
        weaponSprite = GetComponent<Image>();
        weaponNo = weaponSprite.sprite.name[weaponSprite.sprite.name.Length - 1] - '0'; //Get the last character of the sprite's name
        weaponName = "Plasma Gun Type 0" + weaponNo.ToString();
        
        weaponStatus = ItemStatus.none;         //Set the first status of all weapon to none
        change = false;                         //Bool chance is used when want to change the weapon status on screen

        generateRandomWeaponStat();
    }

    private void Update()
    {
        if(change)
        {
            if (weaponStatus == ItemStatus.used)
            {
                Destroy(statusDisplay);
                statusDisplay = Instantiate(usedText, this.transform.position - Vector3.up * 0.7f, Quaternion.identity, statusDisplayParent.transform);
                change = false;
            }
            else if (weaponStatus == ItemStatus.rented)
            {
                Destroy(statusDisplay);
                statusDisplay = Instantiate(rentedOutText, this.transform.position - Vector3.up * 0.7f, Quaternion.identity, statusDisplayParent.transform);
                rentedOut = true;
                change = false;
            }
            else
            {
                if(rentedOut)
                {
                    Destroy(statusDisplay);
                    statusDisplay = Instantiate(rentedOutText, this.transform.position - Vector3.up * 0.7f, Quaternion.identity, statusDisplayParent.transform);
                    weaponStatus = ItemStatus.rented;
                }
                change = false;
            }
        }
    }

    private void generateRandomWeaponStat()
    {
        damage = Random.Range(10, 51);
        dispersion = Random.Range(5, 21);
        rateOfFire = Random.Range(1, 21) * 50;
        reloadSpeed = Random.Range(10, 51);
        ammunition = Random.Range(10, 100) * 10;
    }

    public enum ItemStatus
    {
        none, rented, used
    }
}
