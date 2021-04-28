using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star_spawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject starprefab;
    public float star_spawn_timer = 2.8f;
    private float current_star_spawn_timer;
    public float min_x = -2.48f, max_x = 2.48f;

    void Start()
    {
        current_star_spawn_timer = star_spawn_timer;
    }

    // Update is called once per frame
    void Update()
    {
        spawn_stars();
    }

    void spawn_stars()
    {
        current_star_spawn_timer += Time.deltaTime;
        Debug.Log(current_star_spawn_timer + " " + star_spawn_timer);

        if (current_star_spawn_timer >= star_spawn_timer)
        {
            Vector2 temp = transform.position;
            temp.x = Random.Range(min_x, max_x);
            GameObject newstar = null;
            newstar = Instantiate(starprefab, temp, Quaternion.identity);
            newstar.transform.parent = transform;
            current_star_spawn_timer = 0f;
        }
    }
}
