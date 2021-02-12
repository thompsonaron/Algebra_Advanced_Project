using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.IO;
//using static UIGenerated;

public partial class Game
{
    public GraphicRaycaster raycaster;

    bool isDown;
    bool isHold;
    bool isUp;
    bool isRightClickDown;
    bool isMiddleClickDown;
    PointerEventData pointerData;
    List<RaycastResult> hitObjects;

    public void initRaycast()
    {
        pointerData = new PointerEventData(null);
        hitObjects = new List<RaycastResult>();


        //UIGeneratedGameScene.init();
    }

    public void UpdateRaycast()
    {
        //polling UI pointer data (polling is getting the data every frame (no events))
        isDown = Input.GetMouseButtonDown(0);
        isUp = Input.GetMouseButtonUp(0);
        isRightClickDown = Input.GetMouseButtonDown(1);
        isMiddleClickDown = Input.GetMouseButtonDown(2);
        

        if (isDown)
        {
            isHold = true;
        }
        if (isUp)
        {
            isHold = false;
        }
        hitObjects.Clear();
        pointerData.position = Input.mousePosition;
        raycaster.Raycast(pointerData, hitObjects);


        // LEFT CLICK
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot0))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(0);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot1))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(1);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot2))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(2);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot3))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(3);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot4))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(4);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot5))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(5);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot6))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(6);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot7))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(7);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot8))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(8);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot9))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(9);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot10))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(10);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot11))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(11);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot12))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(12);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot13))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(13);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot14))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(14);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot15))
        {
            SoundManager.instance.Play("Menu");
            EquipItem(15);
        }
        if (isUIElementDown(UIGeneratedGameScene.HelmentSlot))
        {
            SoundManager.instance.Play("Menu");
            UnequipItem(2);
        }
        if (isUIElementDown(UIGeneratedGameScene.WeaponSlot))
        {
            SoundManager.instance.Play("Menu");
            UnequipItem(1);
        }
        if (isUIElementDown(UIGeneratedGameScene.ChestSlot))
        {
            SoundManager.instance.Play("Menu");
            UnequipItem(3);
        }


        // RIGHT CLICK
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot0))
        {
            SoundManager.instance.Play("Menu");
            DropItem(0);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot1))
        {
            SoundManager.instance.Play("Menu");
            DropItem(1);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot2))
        {
            SoundManager.instance.Play("Menu");
            DropItem(2);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot3))
        {
            SoundManager.instance.Play("Menu");
            DropItem(3);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot4))
        {
            SoundManager.instance.Play("Menu");
            DropItem(4);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot5))
        {
            SoundManager.instance.Play("Menu");
            DropItem(5);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot6))
        {
            SoundManager.instance.Play("Menu");
            DropItem(6);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot7))
        {
            SoundManager.instance.Play("Menu");
            DropItem(7);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot8))
        {
            SoundManager.instance.Play("Menu");
            DropItem(8);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot9))
        {
            SoundManager.instance.Play("Menu");
            DropItem(9);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot10))
        {
            SoundManager.instance.Play("Menu");
            DropItem(10);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot11))
        {
            SoundManager.instance.Play("Menu");
            DropItem(11);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot12))
        {
            SoundManager.instance.Play("Menu");
            DropItem(12);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot13))
        {
            SoundManager.instance.Play("Menu");
            DropItem(13);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot14))
        {
            SoundManager.instance.Play("Menu");
            DropItem(14);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot15))
        {
            SoundManager.instance.Play("Menu");
            DropItem(15);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.HelmentSlot))
        {

        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ChestSlot))
        {

        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.WeaponSlot))
        {

        }

        // MIDDLE CLICK
        if (isUIElementDownMiddleClick(UIGeneratedGameScene.HelmentSlot))
        {

        }
        if (isUIElementDownMiddleClick(UIGeneratedGameScene.ChestSlot))
        {

        }
        if (isUIElementDownMiddleClick(UIGeneratedGameScene.WeaponSlot))
        {

        }

        if (isUIElementDown(UIGeneratedGameScene.SaveQuitBtn))
        {
            SoundManager.instance.Play("Menu");
            SaveGame();
            SceneManager.LoadScene("MainMenu");
        }
        if (isUIElementDown(UIGeneratedGameScene.RetryBtn))
        {
            SoundManager.instance.Play("Menu");
            File.Delete(Util.getSavePath(levelProgress.levelToLoad));
            SceneManager.LoadScene("GameScene");
        }
        if (isUIElementDown(UIGeneratedGameScene.QuitBtn))
        {
            SoundManager.instance.Play("Menu");
            File.Delete(Util.getSavePath(levelProgress.levelToLoad));
            SceneManager.LoadScene("MainMenu");
        }
        if (isUIElementDown(UIGeneratedGameScene.LossRetryBtn))
        {
            SoundManager.instance.Play("Menu");
            File.Delete(Util.getSavePath(levelProgress.levelToLoad));
            SceneManager.LoadScene("GameScene");
        }
        if (isUIElementDown(UIGeneratedGameScene.ContinueBtn))
        {
            SoundManager.instance.Play("Menu");
            File.Delete(Util.getSavePath(levelProgress.levelToLoad));
            switch (levelProgress.levelToLoad)
            {
                case 1:
                    levelProgress.level1Completed = true;
                    levelProgress.levelToLoad = 2;
                    break;
                case 2:
                    levelProgress.level2Completed = true;
                    levelProgress.levelToLoad = 3;
                    break;
                case 3:
                    levelProgress.level3Completed = true;
                    SceneManager.LoadScene("MainMenu");
                    break;
                default:
                    break;
            }
            SceneManager.LoadScene("GameScene");
        }
    }

    bool isUIElementDown(GameObject go)
    {
        return isUIElementPressed(go, isDown);
    }

    bool isUIElementDownRightClick(GameObject go)
    {
        return isUIElementPressed(go, isRightClickDown);
    }
    bool isUIElementDownMiddleClick(GameObject go)
    {
        return isUIElementPressed(go, isMiddleClickDown);
    }

    bool isUIElementHold(GameObject go)
    {
        return isUIElementPressed(go, isHold);
    }

    bool isUIElementUp(GameObject go)
    {
        return isUIElementPressed(go, isUp);
    }

    bool isUIElementPressed(GameObject go, bool state)
    {
        bool output = false;
        if (state)
        {
            foreach (var item in hitObjects)
            {
                if (item.gameObject == go)
                {
                    output = true;
                    break;
                }
            }
        }
        return output;
    }
}
