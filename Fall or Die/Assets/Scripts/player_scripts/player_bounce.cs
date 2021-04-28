using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bounce : MonoBehaviour
{

    public float min_x = -2.6f;
    public float max_x = 2.6f;
    public float min_y = -5.6f;

    private bool out_of_bounds;

    // Update is called once per frame
    void Update()
    {
        check();
    }

    void check()
    {
        Vector2 temp = transform.position;
        if (temp.x > max_x)
        {
            temp.x = max_x;
        }
        if (temp.x < min_x)
        {
            temp.x = min_x;
        }
        transform.position = temp;
        if (temp.y < min_y)
        {
            if (!out_of_bounds)
            {
                out_of_bounds = true;

                SoundManager.instance.DeathSound();
                Score.scoreValue = 0;
                GameManager.instance.RestartGame();

                // Death 
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "TopSpikes")
        {
           transform.position = new Vector2(1000f, 1000f);
            
           SoundManager.instance.DeathSound();
            Score.scoreValue = 0;
            GameManager.instance.RestartGame();
        }
        if (target.tag == "star")
        {

            SoundManager.instance.StarSound();
            Score.scoreValue += 1;
            Destroy(target.gameObject);

        }
    }
}
