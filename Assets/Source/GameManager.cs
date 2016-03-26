using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    Text gameOverText;
    Text levelText;
    public float gameOverTimer;
    private float passedTime;
    private bool startTimer = false;
    private int level = 1;
    // Use this for initialization
    void Awake()
    {
         DontDestroyOnLoad(gameObject);

    }
    void Start () {
        gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
        gameOverText.enabled = false;
        levelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>();
        levelText.text = "Level" + level;
        levelText.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (startTimer == true)
        {
            passedTime += Time.deltaTime;
            if(passedTime > gameOverTimer)
            {
                startTimer = false;
                LoadLevel(1);
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
        level++;
        LoadLevel(level);
    }
    public void LoadLevel(int level)
    {
        this.level = level;
        Application.LoadLevel("Level" + level);

    }
    void OnLevelWasLoaded(int level)
    {
        gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
        gameOverText.enabled = false;
        levelText = GameObject.FindGameObjectWithTag("LevelText").GetComponent<Text>();
        levelText.text = "Level" + this.level;
        levelText.enabled = true;
    }
}
