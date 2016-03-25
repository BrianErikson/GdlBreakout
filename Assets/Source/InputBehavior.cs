using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputBehavior : MonoBehaviour {
    private BallBehavior bb;
    private Text spaceText;
	// Use this for initialization
	void Start () {
        bb = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallBehavior>();
        spaceText = GameObject.FindGameObjectWithTag("SpaceBarText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            bb.Launch();
            spaceText.enabled = false;
        }
	}
}
