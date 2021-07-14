using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 10;
    public int baseEXP = 1000;


    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] mpLvlBonus;
    public int strength;
    public int defense;
    public int wpnPwr;
    public int armrPwr;
    public string equippedWeapon;
    public string equippedArmor;
    public Sprite charImage;
    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(600);
        }
    }
    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
        //checks to make sure the player does not go above max level
        if (playerLevel < maxLevel)
        {
            //Level up player to correct level regardless of EXP gain amount
            while (currentEXP >= expToNextLevel[playerLevel])
            {
                
                playerLevel++;
                if (playerLevel >= maxLevel)

                {

                    currentEXP = 0;

                }

                else

                {

                    currentEXP -= expToNextLevel[playerLevel];

                }

                //Determine whether to add to strength or defense based off odd or even level
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defense++;
                }

                //Modify max HP
                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                //modify Mp
                maxMP += mpLvlBonus[playerLevel];
                currentMP = maxMP;

                if (playerLevel == maxLevel)
                {
                    break;
                }
            }
        }
        //Stops EXP gain once at max level
        if (playerLevel == maxLevel)
        {
            currentEXP = 0;
        }
    }
}
