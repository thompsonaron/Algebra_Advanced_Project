using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Game
{
    public void SaveGame()
    {
        SaveData save = new SaveData();
        save.levelData = level;
        save.playerPosX = playerPosX;
        save.playerPosY = playerPosY;
        save.player = player;
        for (int i = 0; i < save.inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                save.inventory[i] = inventory[i].ID;
                Debug.Log("INV ID " + inventory[i].ID);
            }
            else
            {
                save.inventory[i] = -1;
            }
        }
        if (chest != null)
        {
            save.chestID = chest.ID;
        }
        if (helmet != null)
        {
            save.helmID = helmet.ID;
        }
        if (weapon != null)
        {
            save.weaponID = weapon.ID;
        }

        Util.serialize(save, Util.getSavePath(levelProgress.levelToLoad));

        
    }

    public void LoadGame()
    {
        SaveData saveData = Util.deserializeSave(Util.getSavePath(levelProgress.levelToLoad));
        level = saveData.levelData;
        foreach (var item in level.grid)
        {
            Debug.Log(item);
        }
        playerPosX = saveData.playerPosX;
        playerPosY = saveData.playerPosY;
        player = saveData.player;
        //inventory = saveData.inventory;

        for (int i = 0; i < saveData.inventory.Length; i++)
        {
            if (saveData.inventory[i] != -1)
            {
                for (int j = 0; j < scriptableItems.Length; j++)
                {
                    if (scriptableItems[j].ID == saveData.inventory[i])
                    {
                        inventory[i] = scriptableItems[j];
                    }
                }
            }
            else
            {
                inventory[i] = null;
            }
        }

        if (saveData.chestID != -1)
        {
            for (int j = 0; j < scriptableItems.Length; j++)
            {
                if (scriptableItems[j].ID == saveData.chestID)
                {
                    chest = scriptableItems[j];
                }
            }
        }
        if (saveData.helmID != -1)
        {
            for (int j = 0; j < scriptableItems.Length; j++)
            {
                if (scriptableItems[j].ID == saveData.helmID)
                {
                    helmet = scriptableItems[j];
                }
            }
        }
        if (saveData.weaponID != -1)
        {
            for (int j = 0; j < scriptableItems.Length; j++)
            {
                if (scriptableItems[j].ID == saveData.weaponID)
                {
                    weapon = scriptableItems[j];
                }
            }
        }

        playerObject.transform.position = new Vector3(playerPosX, 0f, -playerPosY);
        LoadInventoryImages();
    }

    
}
[Serializable]
public class SaveData
{
    public int[] inventory = new int[16];
    public int helmID = -1;
    public int chestID = -1;
    public int weaponID = -1;
    public Level levelData;
    public int playerPosX, playerPosY;
    public Player player;
}