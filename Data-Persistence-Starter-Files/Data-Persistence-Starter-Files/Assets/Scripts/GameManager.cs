using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string PlayerName;
    public int PlayerScore;
    public int BestScore;
    public string BestScoreName;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
        }
        Load();
    }
    void Start()
    {

    }

    // Update is called once per frame
    public void Setname(Text Pname)
    {
        PlayerName = Pname.text;
    }
    public void SetScores(int score)
    {
        PlayerScore = score;
        if (score > BestScore)
        {
            BestScore = score;
            BestScoreName = PlayerName;
        }
        Save();
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.PlayerScore = PlayerScore;
        data.BestScore = BestScore;
        data.BestScoreName = BestScoreName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = "";
            PlayerScore = 0;
            BestScore = data.BestScore;
            BestScoreName = data.BestScoreName;
        }
        else
        {
            PlayerName = "";
            PlayerScore = 0;
            BestScoreName = "";
            BestScore = 0;
        }

    }
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ExitGame()
    {
        Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int PlayerScore;
        public int BestScore;
        public string BestScoreName;
    }
}
