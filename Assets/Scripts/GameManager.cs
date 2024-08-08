using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }  // Singleton Instance

    public Player player;
    public Text scoreText;
    public GameObject PlayButton;
    private int score;
    public GameObject gameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Optional: Keep across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        PlayButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        PipePool.Instance.ResetAllPipes();  // Pipes resetleniyor
        player.ResetPlayer();  // Player pozisyonu sıfırlanıyor
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    
    public void GameOver()
    {
        gameOver.SetActive(true);  
        PlayButton.SetActive(true);
        Pause();
    }
    
    public void ResetGame()
    {
        Play();  // Oyun sahnesini sıfırdan başlatıyor
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}