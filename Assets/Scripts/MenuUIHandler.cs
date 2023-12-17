using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject nameChange;
    public TextMeshProUGUI NameText;
    public TMP_InputField input;

    private void Start()
    {
        ChangeNameText();
    }

    private void ChangeNameText()
    {
        NameText.text = "PlayerName: "+ScoreManager.Instance.thisPlayer+"\nBestScore\nName: " + ScoreManager.Instance.playerName + "\nScore: " + ScoreManager.Instance.score;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeName()
    {
        nameChange.SetActive(true);
    }

    public void SaveName()
    {
        nameChange.SetActive(false);
        ScoreManager.Instance.thisPlayer = input.text;
        ChangeNameText();
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
