﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public static BeatScroller instance;

    public float beatTempo;
    public bool hasStarted;

    void Start()
    {
        instance = this;
        beatTempo = beatTempo / 60f;  
    }


    void Update()
    {
        if (hasStarted)
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        } 
    }
}
