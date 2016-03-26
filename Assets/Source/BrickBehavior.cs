using UnityEngine;
using System.Collections;

public class BrickBehavior : MonoBehaviour {
    public Sprite[] sprites;

    [Tooltip("Cannot be a higher value than the length of the array of sprites")]
    public int health;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        if (health > sprites.Length)
        {
            health = sprites.Length;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            audioSource.Play();
            health--;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                UpdateSprite();
            }
        }
    }

    private void UpdateSprite()
    {
        if (health >= 0 && health <= sprites.Length)
        {
            spriteRenderer.sprite = sprites[health - 1];
        }
    }
}
