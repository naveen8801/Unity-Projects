using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikeplatformPrefab;
    public GameObject[] movingplatforms;
    public GameObject breakableplatforms;
    

    public float platform_spawn_timer = 1.8f;
    private float current_platform_spawn_timer;

    private int platform_spawn_count;

    public float min_x = -2f, max_x = 2f;

    // Start is called before the first frame update
    void Start()
    {
        current_platform_spawn_timer = platform_spawn_timer;
    }

    // Update is called once per frame
    void Update()
    {
        spawn_platforms();
    }

    void spawn_platforms()
    {
        current_platform_spawn_timer += Time.deltaTime;

        if (current_platform_spawn_timer >= platform_spawn_timer)
        {
            platform_spawn_count++;
            Vector2 temp = transform.position;
            temp.x = Random.Range(min_x, max_x);
            GameObject newplatform = null;
            if (platform_spawn_count < 2)
            {
                newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if (platform_spawn_count == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newplatform = Instantiate(movingplatforms[Random.Range(0,movingplatforms.Length)], temp, Quaternion.identity);
                }
            }
            else if (platform_spawn_count == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newplatform = Instantiate(spikeplatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platform_spawn_count == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newplatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newplatform = Instantiate(breakableplatforms, temp, Quaternion.identity);
                }
                platform_spawn_count = 0;
            }
            if (newplatform)
            {
                newplatform.transform.parent = transform;
            }
            current_platform_spawn_timer = 0f;
        }
    }

}
