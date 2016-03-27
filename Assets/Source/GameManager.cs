using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    Text gameOverText;
    Text levelText;
    public float gameOverTimer;
    private float passedTime;
    private bool startTimer = false;
   
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
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
                LoadLevel(0);
            }
        }
	}

    public void EndGame()
    {
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

    void OnLevelWasLoaded(int level)
    {
        OnNewLevel();
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
