using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public int startLives = 3;
    public float gameOverTimer;
    public bool cheats = false;

    Text gameOverText;
    Text levelText;
    private float gameEndPassedTime;
    private bool startEndGameTimer = false;
    private int lives;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            lives = startLives;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        OnNewLevel();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (startEndGameTimer == true)
        {
            gameEndPassedTime += Time.deltaTime;
            if(gameEndPassedTime > gameOverTimer)
            {
                startEndGameTimer = false;
                gameEndPassedTime = 0;
                
                lives = startLives;
                LoadLevel(0);
            }
        }
    }

    void OnLevelWasLoaded(int level)
    {
        OnNewLevel();
    }

    public void EndGame(bool won)
    {
        if (!won)
        {
            lives--;
            gameOverText.text = lives + " tries left!";
            if (lives <= 0)
            {
                gameOverText.text = "Game Over!";
            }
            else if (lives == 1)
            {
                gameOverText.text = "1 try left!";
            }
        }

        gameOverText.enabled = true;
        startEndGameTimer = true;
    }

    public void NextLevel()
    {
        int next = GetNextLevel();
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(next);
        }
        else // you won!
        {
            gameOverText.text = "You won!";
            EndGame(true);
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void AddLives(int amount)
    {
        if (lives + amount > 0)
        {
            lives += amount;
        }
    }

    private void OnNewLevel()
    {
        gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
        gameOverText.enabled = false;
        levelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>();
        levelText.text = "Level " + (GetCurrentLevel() + 1);
        levelText.enabled = true;
    }

    private int GetCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private int GetNextLevel()
    {
        return SceneManager.GetActiveScene().buildIndex + 1;
    }
}
