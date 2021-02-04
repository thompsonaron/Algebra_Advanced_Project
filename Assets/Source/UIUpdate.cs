using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Game
{
    [HideInInspector] public Text actionReloadLbl;
    [HideInInspector] public bool inventoryActive;
    [HideInInspector] public bool menuActive;

    public void initUI()
    {
        inventoryActive = false;
        menuActive = false;
        UIGeneratedGameScene.init();
       // Debug.Log(UIGeneratedGameScene.InfoPanel);
        UIGeneratedGameScene.InventoryPanel.SetActive(inventoryActive);
        UIGeneratedGameScene.InfoPanel.SetActive(false);
        UIGeneratedGameScene.WinLosePanel.SetActive(false);
        UIGeneratedGameScene.MenuPanel.SetActive(false);

        actionReloadLbl = UIGeneratedGameScene.ActionReloadLbl.GetComponent<Text>();
    }

    public void UIUpdate()
    {

        // Action reload update
        if (actionReloadTime <= 0f)
        {
            actionReloadLbl.text = "1";
        }
        else
        {
            actionReloadLbl.text = "0";
        }


        // pickup Update
        if (currentTileType == TileType.Sword || currentTileType == TileType.Chest || currentTileType == TileType.DroppedItem)
        {
            UIGeneratedGameScene.InfoPanel.SetActive(true);
        }
        else
        {
            UIGeneratedGameScene.InfoPanel.SetActive(false);
        }

        // inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Inventory");
            inventoryActive = !inventoryActive;
            UIGeneratedGameScene.InventoryPanel.SetActive(inventoryActive);
        }

        // menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuActive = !menuActive;
            UIGeneratedGameScene.MenuPanel.SetActive(menuActive);
        }
    }

    public void ActivateWinUi()
    {
        UIGeneratedGameScene.WinLosePanel.SetActive(true);
        UIGeneratedGameScene.YouLoseLbl.SetActive(false);
        UIGeneratedGameScene.ContinueBtn.SetActive(false);
    }

    public void ActivateLossUI()
    {
        UIGeneratedGameScene.WinLosePanel.SetActive(true);
        UIGeneratedGameScene.YouWinLbl.SetActive(false);
        UIGeneratedGameScene.ContinueBtn.SetActive(false);
    }

    public void UpdatePlayerHealth()
    {
        UIGeneratedGameScene.PlayerHealthLbl.GetComponent<Text>().text = player.health.ToString();
    }

    public void UpdateEnemyHealth()
    {
        UIGeneratedGameScene.EnemyHealthLb.GetComponent<Text>().text = currentTile.additionalHealth.ToString();
    }

    public void UpdatePlayerAttack()
    {
        UIGeneratedGameScene.PlayerDmgInfo.GetComponent<Text>().text = player.attackDamage.ToString();
    }
}
