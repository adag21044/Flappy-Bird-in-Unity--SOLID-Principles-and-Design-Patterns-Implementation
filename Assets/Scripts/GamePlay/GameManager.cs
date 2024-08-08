using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Player player;
    public Text scoreText;
    public Text highScoreText;
    public GameObject playButton;
    public GameObject gameOver;
    [SerializeField]private int score;
    [SerializeField]private int highScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Application.targetFrameRate = 60;
        Pause();
        LoadHighScore();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        PipePool.Instance.ResetAllPipes();
        player.ResetPlayer();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    
    public void GameOver()
    {
        gameOver.SetActive(true);  
        playButton.SetActive(true);
        Pause();

        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }

        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void ResetGame()
    {
        Play();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void SaveHighScore()
    {
        SaveManager.SaveHighScore(highScore);
    }

    private void LoadHighScore()
    {
        highScore = SaveManager.LoadHighScore();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}