using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    Text gameOverText;
    public float gameOverTimer;
    private float passedTime;
    private bool startTimer = false;
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
                RestartLevel();
            }
        }
	}
    public void StartLevel()
    {

    }
    public void RestartLevel()
    {
        Application.LoadLevel("Game");
    }
    public void EndGame()
    {
        gameOverText.enabled = true;
        startTimer = true;
    }
    public void NextLevel()
    {

    }
}
