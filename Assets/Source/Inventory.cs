using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Game
{
    public ItemScriptableObject[] scriptableItems;
    public ItemScriptableObject[] inventory;
    public ItemScriptableObject helmet;
    public ItemScriptableObject chest;
    public ItemScriptableObject weapon;

    public Image[] inventoryImages;
    public Sprite defaultInvetoryLook;
    public Sprite defaultEquipLook;

    public Image helmetImage;
    public Image chestImage;
    public Image weaponImage;



    public void initInventory()
    {
        inventory = new ItemScriptableObject[16];
        inventoryImages = new Image[16];

        inventory[1] = scriptableItems [0];
        inventory[0] = scriptableItems[3];
        inventory[2] = scriptableItems[2];
        inventory[3] = scriptableItems[1];
        inventory[4] = scriptableItems[4];
        inventory[5] = scriptableItems[5];
        initInventoryImages();
        LoadInventoryImages();
    }


    public void GetRandomItem()
    {
        int result = UnityEngine.Random.Range(0, scriptableItems.Length - 1);
        AddItemToInventory(scriptableItems[result]);
    }

    public void GettemFromDroppedTile()
    {
        AddItemToInventory(scriptableItems[currentTile.scriptableItemID]);
    }

    // 1 == weapon, 2 == helmet, 3 == chest
    public void UnequipItem(int equipSlot)
    {
        switch (equipSlot)
        {
            case 1:
                AddItemToInventory(weapon);
                weapon = null;
                weaponImage.sprite = defaultEquipLook;
                break;
            case 2:
                AddItemToInventory(helmet);
                helmet = null;
                helmetImage.sprite = defaultEquipLook;
                break;
            case 3:
                AddItemToInventory(chest);
                chest = null;
                chestImage.sprite = defaultEquipLook;
                break;
            default:
                break;
        }
        UpdatePlayerStats();
    }

    public void DropItem(int itemSlot)
    {
        if (currentTileType == TileType.Grass || currentTileType == TileType.PlayerSpawn)
        {
            for (int i = 0; i < scriptableItems.Length; i++)
            {
                if (inventory[itemSlot] == scriptableItems[i])
                {
                    Debug.Log("DROPPED! " + itemSlot);
                    currentTile.scriptableItemID = i;
                    level.grid[playerPosX][playerPosY] = TileType.DroppedItem;
                    inventory[itemSlot] = null;
                    LoadInventoryImages();
                    if (scriptableItems[i].itemType == 1)
                    {
                        Instantiate(data.sword,new Vector3(playerPosX, 0, -playerPosY), Quaternion.identity);
                    }
                    else if (scriptableItems[i].itemType == 2 || scriptableItems[i].itemType == 3)
                    {
                        Instantiate(data.chest, new Vector3(playerPosX, 0, -playerPosY), Quaternion.identity);
                    }
                }
            }
        }
    }
    public void AddItemToInventory(ItemScriptableObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                break;
            }
        }
        LoadInventoryImages();
    }

    public void EquipItem(int slot)
    {
        if (inventory[slot] == null)
        {
            return;
        }


        // inventory swap
        switch (inventory[slot].itemType)
        {
            case 1:
                if (weapon != null)
                {
                    UnequipItem(1);
                }
                weapon = inventory[slot];
                weaponImage.sprite = inventory[slot].icon;
                inventoryImages[slot].sprite = defaultInvetoryLook;
                inventory[slot] = null;
                break;
            case 2:
                if (chest != null)
                {
                    UnequipItem(3);
                }
                chest = inventory[slot];
                chestImage.sprite = inventory[slot].icon;
                inventoryImages[slot].sprite = defaultInvetoryLook;
                inventory[slot] = null;
                break;
            case 3:
                if (helmet != null)
                {
                    UnequipItem(2);
                }
                helmet = inventory[slot];
                helmetImage.sprite = inventory[slot].icon;
                inventoryImages[slot].sprite = defaultInvetoryLook;
                inventory[slot] = null;
                break;
            default:
                break;
        }
        UpdatePlayerStats();
    }

    public void UpdatePlayerStats()
    {
        int playerAttack = 0;
        int playerHP = 0;
        if (helmet != null)
        {
            playerAttack += helmet.damage;
            playerHP += helmet.health;
        }
        if (chest != null)
        {
            playerAttack += chest.damage;
            playerHP += chest.health;
        }
        if (weapon != null)
        {
            playerAttack += weapon.damage;
            playerHP += weapon.health;
        }


        player.attackDamage = player.baseAttack + playerAttack;
        player.health = player.baseHealth + playerHP - player.damageTaken + player.damageHealed;

        Debug.Log("PLAYER HPL " + player.health);
        UpdatePlayerHealth();
        UpdatePlayerAttack();
    }

    public void initInventoryImages()
    {
        helmetImage = UIGeneratedGameScene.HelmentSlot.GetComponent<Image>();
        chestImage = UIGeneratedGameScene.ChestSlot.GetComponent<Image>();
        weaponImage = UIGeneratedGameScene.WeaponSlot.GetComponent<Image>();

        inventoryImages[0] = UIGeneratedGameScene.ItemSlot0.GetComponent<Image>();
        inventoryImages[1] = UIGeneratedGameScene.ItemSlot1.GetComponent<Image>();
        inventoryImages[2] = UIGeneratedGameScene.ItemSlot2.GetComponent<Image>();
        inventoryImages[3] = UIGeneratedGameScene.ItemSlot3.GetComponent<Image>();
        inventoryImages[4] = UIGeneratedGameScene.ItemSlot4.GetComponent<Image>();
        inventoryImages[5] = UIGeneratedGameScene.ItemSlot5.GetComponent<Image>();
        inventoryImages[6] = UIGeneratedGameScene.ItemSlot6.GetComponent<Image>();
        inventoryImages[7] = UIGeneratedGameScene.ItemSlot7.GetComponent<Image>();
        inventoryImages[8] = UIGeneratedGameScene.ItemSlot8.GetComponent<Image>();
        inventoryImages[9] = UIGeneratedGameScene.ItemSlot9.GetComponent<Image>();
        inventoryImages[10] = UIGeneratedGameScene.ItemSlot10.GetComponent<Image>();
        inventoryImages[11] = UIGeneratedGameScene.ItemSlot11.GetComponent<Image>();
        inventoryImages[12] = UIGeneratedGameScene.ItemSlot12.GetComponent<Image>();
        inventoryImages[13] = UIGeneratedGameScene.ItemSlot13.GetComponent<Image>();
        inventoryImages[14] = UIGeneratedGameScene.ItemSlot14.GetComponent<Image>();
        inventoryImages[15] = UIGeneratedGameScene.ItemSlot15.GetComponent<Image>();
    }

    public void LoadInventoryImages()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                inventoryImages[i].sprite = inventory[i].icon;
            }
            else
            {
                inventoryImages[i].sprite = defaultInvetoryLook;
            }
        }
    }

    
    
}

[Serializable]
public class Item
{
    public float actionReloadSpeed;
    public int damage;
    public int health;
    public bool ranged;
}


