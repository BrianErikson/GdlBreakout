﻿using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour {
    public float impactForce = 10f;
    public float startForce;
    public float topSpeed;
    public bool launched { get; private set; }
    public float angleConstraint = 20;
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
        float angle = Mathf.Atan2(rb.velocity.y,rb.velocity.x)*Mathf.Rad2Deg;
        //leftside contraints
        if (angle >= 180 - angleConstraint)
        {
            SetAngle(160f);
        }
        else if (angle <= -179 + angleConstraint)
        {
            SetAngle(-160f);
        }
        //rightside contraints
        else if (angle <= 0 && angle >= -angleConstraint)
        {
            SetAngle(-20f);
        }
        else if (angle >= 0 && angle <= angleConstraint)
        {
            SetAngle(20f);
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
        if(coll.gameObject.tag == "Brick")
        {
            screenShake.ShakeCamera(impactForce);
        }
    }
    private void SetAngle(float angle)
    {
        float speed = rb.velocity.magnitude;
        rb.velocity = new Vector2(0, 1);
        rb.velocity = Quaternion.Euler(new Vector3(0, 0, angle)) * rb.velocity;
        rb.velocity *= speed;
    }
}
