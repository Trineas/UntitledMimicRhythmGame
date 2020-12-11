using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFade : MonoBehaviour
{
    public static ButtonFade instance;

    private SpriteRenderer[] rend;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rend = GetComponentsInChildren<SpriteRenderer>();
        /*Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;*/
    }


    IEnumerator FadeButtonsIn()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            for (float f = 0.05f; f <= 1; f += 0.05f)
            {
                Color c = rend[i].material.color;
                c.a = f;
                rend[i].material.color = c;
                yield return new WaitForSeconds(0.05f);
            }

        }
    }

    IEnumerator FadeButtonsOut()
    {
        for (int i = 0; i < rend.Length; i++) 
        {
            for (float f = 1f; f >= -0.05f; f -= 0.05f)
            {
                Color c = rend[i].material.color;
                c.a = f;
                rend[i].material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    public void StartFadingButtonsIn()
    {
        StartCoroutine("FadeButtonsIn");
    }

    public void StartFadingButtonsOut()
    {
        StartCoroutine("FadeButtonsOut");
    }
}
