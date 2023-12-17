using System;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string playerName;
    public string thisPlayer;
    public int score;


    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
    }

    [Serializable]
    class SaveData
    {
        public string name;
        public string thisPlayer;
        public int score;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.score = score;
        data.thisPlayer = thisPlayer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.name;
            score = data.score;
            thisPlayer = data.thisPlayer;
        }
    }
}
