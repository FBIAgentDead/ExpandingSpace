﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject[] obj1;
    public Transform _player;
    public float spawnMin = 20;
    public float spawnMax = 40;
    private float playerRange;
    bool doIt = true;
    // Use this for initialization
    void Start () {
        playerRange = _player.position.x + 30;
	}
    private void Update()
    {
        if(_player.position.x >= playerRange && doIt == true)
        {
           Spawn();
        }
    }
    void Spawn() {
        Vector2 spawnLocation = new Vector2(transform.position.x, transform.position.y - Random.Range(1, 8));
        GameObject holes = Instantiate(obj1[Random.Range(0, obj1.GetLength(0))], spawnLocation, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
        doIt = false;
                
    }

}
