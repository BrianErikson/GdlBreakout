using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
    public float startForce;
    public float topSpeed;
    public bool launched { get; private set; }
    
    private Rigidbody2D rb;

    public BallBehavior()
    {
        launched = false;
    }

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.magnitude > topSpeed)
        {
            rb.velocity = rb.velocity.normalized;
            rb.velocity = rb.velocity * topSpeed;
        }
	}

    public void Launch()
    {
        if (!launched)
        {
            launched = true;
            rb.AddForce(new Vector2(0, startForce));
        }
    }
}
