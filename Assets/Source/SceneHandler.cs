using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    private void Start()
    {
        UIGeneratedMainMenu.init();
        UIGeneratedMainMenu.BtnPlay.GetComponent<Button>().onClick.AddListener(() => StartGame());
        UIGeneratedMainMenu.BtnCreate.GetComponent<Button>().onClick.AddListener(() => StartCreative());
        UIGeneratedMainMenu.BtnExit.GetComponent<Button>().onClick.AddListener(() => ExitGame());
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

    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
