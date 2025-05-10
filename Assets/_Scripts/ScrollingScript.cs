using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    Renderer sprite;
    public float speed;
    Vector2 offset;
    float distance;
    private AudioSource source;
    void Start()
    {
        sprite = GetComponent<Renderer>();
        source=GetComponent<AudioSource>();
        source.volume=PlayerPrefs.GetFloat("MusicSlider", .5f);
    }

    // Update is called once per frame
    void Update()
    {
        distance+=Time.deltaTime*speed;
        sprite.material.SetTextureOffset("_MainTex", Vector2.right * distance);
        
    }
}
