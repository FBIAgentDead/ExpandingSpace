﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSave : MonoBehaviour {

    public Transform _plyr;
    private Transform blackHole;
    private GameObject[] warning;
    private float destroy;

    private void Awake()
    {
        warning = GameObject.FindGameObjectsWithTag("Warning");
        blackHole = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        destroy = _plyr.position.x - 5;
        if(blackHole.position.x < destroy)
        {
            Destroy(this.gameObject);
            for(int i = 0; i < warning.Length; i++)
            {
                warning[i].SetActive(false);
            }
            return;
        }
    }
}
