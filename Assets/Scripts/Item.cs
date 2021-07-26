using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;
    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;
    [Header("Item Details")]
    public int amountToChange;
    public bool affectHp;
    public bool affectMP;
    public bool affectStr;
    public bool affectDef;
    [Header("Weapon/Armor Details")]
    public int weaponStrength;
    public int armorStrength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Use(int charToUse)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUse];

        if(isItem)
        {
            if(affectHp)
            { 
                selectedChar.currentHP += amountToChange;
                if(selectedChar.currentHP > selectedChar.maxHP)
                {
                    selectedChar.currentHP = selectedChar.maxHP;
                }
            }
            if(affectMP)
            {
                selectedChar.currentMP += amountToChange;
                if (selectedChar.currentMP > selectedChar.maxMP)
                {
                    selectedChar.currentMP = selectedChar.maxMP;
                }
            }
            if(affectStr)
            {
                selectedChar.strength += amountToChange;
            }
            if (affectDef)
            {
                selectedChar.defense += amountToChange;
            }

        }

        if(isWeapon)
        {
            if(selectedChar.equippedWeapon != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWeapon);
            }
            selectedChar.equippedWeapon = itemName;
            selectedChar.wpnPwr = weaponStrength;
            

        }
        if (isArmor)
        {
            if (selectedChar.equippedArmor != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedArmor);
            }
            selectedChar.equippedArmor = itemName;
            selectedChar.armrPwr = armorStrength;


        }
        GameManager.instance.RemoveItem(itemName);
    }
}
