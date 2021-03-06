﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class Fire : MonoBehaviour
{
    [SerializeField]
    LeanGameObjectPool leanObj;
    [SerializeField]
    Transform p1fire;
    bool spawned;
    float triggerDelay;
    

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.CompareTag("Player1"))
        {
            
            if (Input.GetKeyDown(KeyCode.Keypad0) && !spawned)
            {
                GameObject bullet = Resources.Load("Bullet") as GameObject;
                leanObj.Spawn(p1fire.position, transform.rotation);
                //bullet.transform.position = new Vector3(0, 10, 0);
                leanObj.Despawn(bullet, 2f);
                spawned = true;
                FindObjectOfType<AudioManager>().Fire();
                triggerDelay = 1;
            }
        }
        else if (this.gameObject.CompareTag("Player2"))
        {
            Transform parent = GameObject.FindGameObjectWithTag("Player2").transform;
            if (Input.GetKeyDown(KeyCode.Space) && !spawned)
            {
                GameObject bullet = Resources.Load("Bullet") as GameObject;
                leanObj.Spawn(p1fire.position, transform.rotation);
                //bullet.transform.position = new Vector3(0,10,0);
                leanObj.Despawn(bullet, 2f);
                spawned = true;
                FindObjectOfType<AudioManager>().Fire();
                triggerDelay = 1;
            }
        }
        Reset();
    }

    private void Reset()
    {
        if (spawned && triggerDelay > 0)
        {
            triggerDelay -= Time.deltaTime;
        }
        if (triggerDelay < 0)
        {
            triggerDelay = 0;
            spawned = false;
        }
    }
}
