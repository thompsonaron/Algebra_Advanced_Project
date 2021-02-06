using UnityEngine;
public static class UIGeneratedMainMenu{
	public static GameObject Canvas;
	public static GameObject MainMenuPanel;
	public static GameObject BtnPlay;
	public static GameObject BtnPlayText;
	public static GameObject BtnCreate;
	public static GameObject BtnCreateText;
	public static GameObject BtnExit;
	public static GameObject BtnExitText;
	public static GameObject LevelSelectPanel;
	public static GameObject BtnLvl1;
	public static GameObject BtnLvl1Txt;
	public static GameObject BtnLvl2;
	public static GameObject BtnLvl2Txt;
	public static GameObject BtnLvl3;
	public static GameObject BtnLvl3Txt;
	public static GameObject BtnReturn;
	public static GameObject BtnReturnTxt;

	public static void init() {
		Canvas = GameObject.Find("Canvas");
		MainMenuPanel = GameObject.Find("Canvas/MainMenuPanel");
		BtnPlay = GameObject.Find("Canvas/MainMenuPanel/BtnPlay");
		BtnPlayText = GameObject.Find("Canvas/MainMenuPanel/BtnPlay/BtnPlayText");
		BtnCreate = GameObject.Find("Canvas/MainMenuPanel/BtnCreate");
		BtnCreateText = GameObject.Find("Canvas/MainMenuPanel/BtnCreate/BtnCreateText");
		BtnExit = GameObject.Find("Canvas/MainMenuPanel/BtnExit");
		BtnExitText = GameObject.Find("Canvas/MainMenuPanel/BtnExit/BtnExitText");
		LevelSelectPanel = GameObject.Find("Canvas/LevelSelectPanel");
		BtnLvl1 = GameObject.Find("Canvas/LevelSelectPanel/BtnLvl1");
		BtnLvl1Txt = GameObject.Find("Canvas/LevelSelectPanel/BtnLvl1/BtnLvl1Txt");
		BtnLvl2 = GameObject.Find("Canvas/LevelSelectPanel/BtnLvl2");
		BtnLvl2Txt = GameObject.Find("Canvas/LevelSelectPanel/BtnLvl2/BtnLvl2Txt");
		BtnLvl3 = GameObject.Find("Canvas/LevelSelectPanel/BtnLvl3");
		BtnLvl3Txt = GameObject.Find("Canvas/LevelSelectPanel/BtnLvl3/BtnLvl3Txt");
		BtnReturn = GameObject.Find("Canvas/LevelSelectPanel/BtnReturn");
		BtnReturnTxt = GameObject.Find("Canvas/LevelSelectPanel/BtnReturn/BtnReturnTxt");
	}
}
