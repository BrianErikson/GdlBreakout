using UnityEngine;
using System.Collections;

public class BrickHolderBehavior : MonoBehaviour {
    GameManager gm;
	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(gameObject.transform.childCount < 1)
        {
            gm.NextLevel();
        }
	}
}
