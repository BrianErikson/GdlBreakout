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
    private float passedTime;
    private bool startTimer = false;
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
        if (startTimer == true)
        {
            passedTime += Time.deltaTime;
            if(passedTime > gameOverTimer)
            {
                startTimer = false;
                passedTime = 0;

                if (lives <= 0)
                {
                    lives = startLives;
                    LoadLevel(0);
                }
                else
                {
                    LoadLevel(GetCurrentLevel());
                }
            }
        }
    }

    void OnLevelWasLoaded(int level)
    {
        OnNewLevel();
    }

    public void EndGame()
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

        gameOverText.enabled = true;
        startTimer = true;
    }

    public void NextLevel()
    {
        int next = GetNextLevel();
        //Debug.Log(SceneManager.GetAllScenes()[1].name);
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(next);
        }
        else // you won!
        {
            gameOverText.text = "You won!";
            EndGame();
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
