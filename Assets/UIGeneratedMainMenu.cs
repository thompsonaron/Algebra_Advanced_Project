using UnityEngine;
public static class UIGeneratedMainMenu{
	public static GameObject Canvas;
	public static GameObject Panel;
	public static GameObject BtnPlay;
	public static GameObject BtnPlayText;
	public static GameObject BtnCreate;
	public static GameObject BtnCreateText;
	public static GameObject BtnExit;
	public static GameObject BtnExitText;

	public static void init() {
		Canvas = GameObject.Find("Canvas");
		Panel = GameObject.Find("Canvas/Panel");
		BtnPlay = GameObject.Find("Canvas/Panel/BtnPlay");
		BtnPlayText = GameObject.Find("Canvas/Panel/BtnPlay/BtnPlayText");
		BtnCreate = GameObject.Find("Canvas/Panel/BtnCreate");
		BtnCreateText = GameObject.Find("Canvas/Panel/BtnCreate/BtnCreateText");
		BtnExit = GameObject.Find("Canvas/Panel/BtnExit");
		BtnExitText = GameObject.Find("Canvas/Panel/BtnExit/BtnExitText");
	}
}
