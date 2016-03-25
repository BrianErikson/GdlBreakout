using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
    public float startForce;
    Rigidbody2D rb;
    public float topSpeed;
    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, startForce));
	}
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.magnitude > topSpeed)
        {
            rb.velocity = rb.velocity.normalized;
            rb.velocity = rb.velocity * topSpeed;
        }
	}
}
