using System.IO;
using UnityEngine;

[System.Serializable]
class SaveData
{
    public string highscore;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(Instance);
    }

    public void SaveHighscore(string data)
    {
        SaveData saveData = new SaveData();
        saveData.highscore = data;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public string LoadHighscore()
    {
        string highscore = "0";
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highscore = data.highscore;
        }
        return highscore;
    }
}
