using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    Text gameOverText;
    public float gameOverTimer;
    private float passedTime;
    private bool startTimer = false;
    private int level = 1;
    // Use this for initialization
    void Start () {
        gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
        gameOverText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if(startTimer == true)
        {
            passedTime += Time.deltaTime;
            if(passedTime > gameOverTimer)
            {
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
}
