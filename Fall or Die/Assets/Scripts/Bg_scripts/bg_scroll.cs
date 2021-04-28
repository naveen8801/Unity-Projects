using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_scroll : MonoBehaviour
{
    public float scroll_speed = 0.3f;
    private MeshRenderer mes_Renderer;

    // Start is called before the first frame update
    void Awake()
    {
        mes_Renderer = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = mes_Renderer.sharedMaterial.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scroll_speed;

        mes_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);

    }
}
