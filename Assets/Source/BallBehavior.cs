using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
    public float impactForce = 10f;
    public float startForce;
    public float topSpeed;
    public bool launched { get; private set; }
    
    private Rigidbody2D rb;
    private ScreenShake screenShake;

    public BallBehavior()
    {
        launched = false;
    }

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        screenShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        screenShake.ShakeCamera(impactForce);
    }
}
