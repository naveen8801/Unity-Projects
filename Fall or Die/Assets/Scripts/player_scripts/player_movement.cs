using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D mybody;
    public float movespeed = 2f;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            mybody.velocity = new Vector2(movespeed, mybody.velocity.y);
        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            mybody.velocity = new Vector2(-movespeed, mybody.velocity.y);
        }
    }

    public void PlatformMove(float x)
    {
        mybody.velocity = new Vector2(x, mybody.velocity.y);
    }
}
