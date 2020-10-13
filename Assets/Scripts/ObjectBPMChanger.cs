using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBPMChanger : MonoBehaviour
{
    public Animator[] anim;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeBPM()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetFloat("Speed", 2f);
        }
    }

    public void StartMoving()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetFloat("Speed", 1f);
        }
    }
}
