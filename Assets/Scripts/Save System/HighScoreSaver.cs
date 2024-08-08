using UnityEngine;

public class HighScoreSaver : MonoBehaviour, IHighScoreObserver
{
    private void Start()
    {
        GameManager.Instance.AddHighScoreObserver(this);
    }

    public void OnHighScoreChanged(int newHighScore)
    {
        SaveManager.SaveHighScore(newHighScore);
    }

    private void OnDestroy()
    {
        GameManager.Instance.RemoveHighScoreObserver(this);
    }
}