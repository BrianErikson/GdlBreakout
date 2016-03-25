using UnityEngine;
using System.Collections;

public class PaddleBehavior : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(translation, 0);
    }
}
