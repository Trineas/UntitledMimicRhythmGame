using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBPMChanger : MonoBehaviour
{
    public Animator[] anim;

    public void ChangeBPM()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetFloat("Speed", 4.25f);
        }
    }

    public void StartMoving()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetTrigger("StartMove");
            anim[i].SetFloat("Speed", 1f);
        }
    }
}
