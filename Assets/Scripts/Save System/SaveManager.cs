using UnityEngine;
using System.IO;

public static class SaveManager
{
    private static string filePath = Application.persistentDataPath + "/highscore.json";

    public static void SaveHighScore(int score)
    {
        HighScoreData data = new HighScoreData { highScore = score };
        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(filePath, json);
    }

    public static int LoadHighScore()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);
            return data.highScore;
        }
        else
        {
            return 0; // Eğer dosya yoksa 0 dön
        }
    }
}