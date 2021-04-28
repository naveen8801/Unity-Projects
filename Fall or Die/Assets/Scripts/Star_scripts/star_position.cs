using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star_position : MonoBehaviour
{
    // Start is called before the first frame update

    public float move_speed = 2f;
    public float bound_Y = 6f;

    void Update()
    {
        move();
    }

    void move()
    {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;
        if (temp.y >= bound_Y)
        {
            gameObject.SetActive(false);
        }
    }

    
}
