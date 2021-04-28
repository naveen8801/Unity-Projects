using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_script : MonoBehaviour

{
    public float move_speed = 2f;
    public float bound_Y = 6f;
    public bool mooving_paltform_right, moving_platform_left, breakable, is_spike, is_platform;
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        if (breakable)
        {
            anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;
        if(temp.y >= bound_Y)
        {
            gameObject.SetActive(false);
        }
    }

    void breakableDectivate()
    {
        Invoke("DeactivateGameObject",0.32f);
    }

    void DeactivateGameObject()
    {
        // ice break sounds
        gameObject.SetActive(false);
        SoundManager.instance.IceBreakSound();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (is_spike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.DeathSound();
                Score.scoreValue = 0;
                GameManager.instance.RestartGame();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (breakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("break");
            }
            if (is_platform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (moving_platform_left)
            {
              
                target.gameObject.GetComponent<player_movement>().PlatformMove(-1f);
            }
            if (mooving_paltform_right)
            {
               
                target.gameObject.GetComponent<player_movement>().PlatformMove(1f);
            }
        }
    }
}
