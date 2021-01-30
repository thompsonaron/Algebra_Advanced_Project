using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Game
{
    [HideInInspector]
    public Text actionReloadLbl;

    public void initUI()
    {
        UIGeneratedGameScene.init();
        actionReloadLbl = UIGeneratedGameScene.ActionReloadLbl.GetComponent<Text>();
    }

    public void UIUpdate()
    {
        if (actionReloadTime <= 0f)
        {
            actionReloadLbl.text = "1";
        }
        else
        {
            actionReloadLbl.text = "0";
        }
    }
}
