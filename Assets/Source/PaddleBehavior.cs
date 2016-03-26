using UnityEngine;
using System.Collections;

public class PaddleBehavior : MonoBehaviour {
    public float speed;
    Rigidbody2D ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(translation, 0);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            Vector2 point = coll.contacts[0].point;
            float offset = gameObject.transform.worldToLocalMatrix.MultiplyPoint(new Vector3(point.x, point.y)).x;
            float angle = offset * -2.72f; //16.5*2.72 = 45 degrees
            float speed = ball.velocity.magnitude;
            ball.velocity = new Vector2(0, 1);
            ball.velocity = Quaternion.Euler(0, 0, angle) * ball.velocity;
            ball.velocity *= speed;
        }
    }
}
