using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputBehavior : MonoBehaviour {
    public AudioClip cheatUp;
    public AudioClip cheatDown;

    private BallBehavior bb;
    private Text spaceText;
    private GameManager gm;
    private AudioSource cheatUpAudio;
    private AudioSource cheatDownAudio;


	// Use this for initialization
	void Start () {
        bb = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallBehavior>();
        spaceText = GameObject.FindGameObjectWithTag("SpaceBarText").GetComponent<Text>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if (gm.cheats == true)
        {
            SetUpCheatAudio();
            cheatUpAudio.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space) && !bb.launched)
        {
            bb.Launch();
            spaceText.enabled = false;
        }

        if (gm.cheats == true)
        {
            CheatInput();
        }
	}

    private void CheatInput()
    {
        if (cheatUpAudio == null || cheatDownAudio == null)
        {
            SetUpCheatAudio();
            cheatUpAudio.Play();
        }
        
        if (Input.GetKeyUp(KeyCode.N))
        {
            gm.NextLevel();
            cheatUpAudio.Play();
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            gm.EndGame(false);
            cheatDownAudio.Play();
        }

        if (Input.GetKeyUp(KeyCode.Comma))
        {
            gm.AddLives(-1);
            cheatDownAudio.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Period))
        {
            gm.AddLives(1);
            cheatUpAudio.Play();
        }
    }

    private void SetUpCheatAudio()
    {
        cheatUpAudio = gameObject.AddComponent<AudioSource>();
        cheatDownAudio = gameObject.AddComponent<AudioSource>();

        cheatUpAudio.clip = cheatUp;
        cheatUpAudio.playOnAwake = false;

        cheatDownAudio.clip = cheatDown;
        cheatDownAudio.playOnAwake = false;
    }
}
