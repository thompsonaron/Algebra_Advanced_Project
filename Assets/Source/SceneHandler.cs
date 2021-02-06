using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    public LevelProgressInfo progressInfo;

    private void Start()
    {
        UIGeneratedMainMenu.init();
        UIGeneratedMainMenu.BtnPlay.GetComponent<Button>().onClick.AddListener(() => OpenLvlSelector());
        UIGeneratedMainMenu.BtnCreate.GetComponent<Button>().onClick.AddListener(() => StartCreative());
        UIGeneratedMainMenu.BtnExit.GetComponent<Button>().onClick.AddListener(() => ExitGame());
        UIGeneratedMainMenu.BtnLvl1.GetComponent<Button>().onClick.AddListener(() => StartGame(1));
        UIGeneratedMainMenu.BtnReturn.GetComponent<Button>().onClick.AddListener(() => CloselvlSelector());


        if (progressInfo.level1Completed)
        {
            UIGeneratedMainMenu.BtnLvl2.GetComponent<Button>().onClick.AddListener(() => StartGame(2));
        }
        else
        {
            Debug.Log("NUCOLOR");
            UIGeneratedMainMenu.BtnLvl2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
            UIGeneratedMainMenu.BtnLvl2.GetComponent<Button>().enabled = false;
        }
        if (progressInfo.level2Completed)
        {
            UIGeneratedMainMenu.BtnLvl3.GetComponent<Button>().onClick.AddListener(() => StartGame(3));
        }
        else
        {
            UIGeneratedMainMenu.BtnLvl3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
            UIGeneratedMainMenu.BtnLvl3.GetComponent<Button>().enabled = false;
        }
        CloselvlSelector();
    }

    private void CloselvlSelector()
    {
        UIGeneratedMainMenu.MainMenuPanel.SetActive(true);
        UIGeneratedMainMenu.LevelSelectPanel.SetActive(false);
    }

    private void OpenLvlSelector()
    {
        UIGeneratedMainMenu.MainMenuPanel.SetActive(false);
        UIGeneratedMainMenu.LevelSelectPanel.SetActive(true);
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            Application.Quit();
#endif
    }

    private void StartCreative()
    {
        SceneManager.LoadScene("LevelCreator");
    }

    private void StartGame(int sceneNumber)
    {
        progressInfo.levelToLoad = sceneNumber;
        SceneManager.LoadScene("GameScene");
    }
}
