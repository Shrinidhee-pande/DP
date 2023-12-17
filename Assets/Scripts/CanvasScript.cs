using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public void MainMenu()
    {
        ScoreManager.Instance.SaveGame();
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        ScoreManager.Instance.SaveGame();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ScoreManager.Instance.SaveGame();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
