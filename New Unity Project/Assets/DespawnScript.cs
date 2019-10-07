﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnScript : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Awake()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 10f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
