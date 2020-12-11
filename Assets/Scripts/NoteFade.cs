using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFade : MonoBehaviour
{
    public static NoteFade instance;

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


    IEnumerator FadeNotesIn()
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

    IEnumerator FadeNotesOut()
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

    public void StartFadingNotesIn()
    {
        StartCoroutine("FadeNotesIn");
    }

    public void StartFadingNotesOut()
    {
        StartCoroutine("FadeNotesOut");
    }
}
