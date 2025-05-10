using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpColor : MonoBehaviour
{
    private Material material;
    private SpriteRenderer sprite;
    public Color[] colors;
    [SerializeField][Range(0f, 5f)] float lerpTime = 5;
    int colorIndex;
    float t = 0;
    void Start()
    {
       
        if (TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
        {
            material = mesh.material;
        }
        else if (TryGetComponent<SpriteRenderer>(out SpriteRenderer spr))
        {
            sprite = spr;
        }
    }


    void Update()
    {
         if(sprite)sprite.color = Color.Lerp(sprite.color, colors[colorIndex], lerpTime * Time.deltaTime);

         if(material)  material.color = Color.Lerp(material.color, colors[colorIndex], lerpTime * Time.deltaTime);
        
        t = Mathf.Lerp(t, 1, lerpTime * Time.deltaTime);

        if (t > 0.9f)
        {
            t = 0;
            colorIndex++;
            colorIndex = (colorIndex >= colors.Length) ? 0 : colorIndex;

        }




    }
}
