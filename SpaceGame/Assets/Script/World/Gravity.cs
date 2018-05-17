﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    //makes the variables and arrays it for multiple object use
    public GameObject[] planet;
    public GameObject[] blackHole;
    public float gravity = 30f;
    private bool grounded = false;

    private Rigidbody2D rig2d;

	// Use this for initialization
	void Start () {
        //gets the objects
        rig2d = GetComponent<Rigidbody2D>();
        rig2d.collisionDetectionMode = 0;
    }
	
	// Update is called once per frame
	void Update () {
        planet = GameObject.FindGameObjectsWithTag("Planet");
        blackHole = GameObject.FindGameObjectsWithTag("BlackHole");
        //this is used for the planet gravity pull

        for (int i = 0; i < planet.Length; i++)
        {
            Vector2 offset = planet[i].transform.position - transform.position;
            
            float gravitysqr = offset.sqrMagnitude;
                
                if (gravitysqr > 0.001f && gravitysqr < 5)
                {
                    transform.up = -offset;
                    rig2d.AddForce(gravity * offset.normalized / gravitysqr);
                    grounded = true;
                }else if(gravitysqr > 5){
                    grounded = false;
                }
            
        }
        //this is used for the blackhole pull and range
        for (int i = 0; i < blackHole.Length; i++)
        {
            
            float gravity2 = 70;
            Vector2 offset2 = blackHole[i].transform.position - transform.position;

            float gravitysqr2 = offset2.sqrMagnitude;
            Debug.Log(grounded);
            if (gravitysqr2 > 0.001f && gravitysqr2 < 100 && grounded == false)
            { 
                rig2d.AddForce(gravity2 * offset2.normalized / gravitysqr2);
            }
        }
    }

}