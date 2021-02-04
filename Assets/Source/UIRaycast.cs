using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
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
            EquipItem(0);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot1))
        {
            EquipItem(1);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot2))
        {
            EquipItem(2);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot3))
        {
            EquipItem(3);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot4))
        {
            EquipItem(4);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot5))
        {
            EquipItem(5);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot6))
        {
            EquipItem(6);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot7))
        {
            EquipItem(7);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot8))
        {
            EquipItem(8);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot9))
        {
            EquipItem(9);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot10))
        {
            EquipItem(10);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot11))
        {
            EquipItem(11);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot12))
        {
            EquipItem(12);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot13))
        {
            EquipItem(13);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot14))
        {
            EquipItem(14);
        }
        if (isUIElementDown(UIGeneratedGameScene.ItemSlot15))
        {
            EquipItem(15);
        }
        if (isUIElementDown(UIGeneratedGameScene.HelmentSlot))
        {
            UnequipItem(2);
        }
        if (isUIElementDown(UIGeneratedGameScene.WeaponSlot))
        {
            UnequipItem(1);

        }
        if (isUIElementDown(UIGeneratedGameScene.ChestSlot))
        {
            UnequipItem(3);
        }


        // RIGHT CLICK
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot0))
        {
            DropItem(0);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot1))
        {
            DropItem(1);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot2))
        {
            DropItem(2);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot3))
        {
            DropItem(3);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot4))
        {
            DropItem(4);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot5))
        {
            DropItem(5);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot6))
        {
            DropItem(6);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot7))
        {
            DropItem(7);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot8))
        {
            DropItem(8);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot9))
        {
            DropItem(9);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot10))
        {
            DropItem(10);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot11))
        {
            DropItem(11);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot12))
        {
            DropItem(12);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot13))
        {
            DropItem(13);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot14))
        {
            DropItem(14);
        }
        if (isUIElementDownRightClick(UIGeneratedGameScene.ItemSlot15))
        {
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
