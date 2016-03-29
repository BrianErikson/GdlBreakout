using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BottomBehavior : MonoBehaviour {
    GameManager gm;
	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            Destroy(coll.gameObject);
            gm.EndGame(false);
        }
    }
}
