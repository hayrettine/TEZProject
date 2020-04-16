﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlatformMovement : MonoBehaviour
{
    public NavMeshAgent nav;
    public Transform leftCorner;
    public Transform rightCorner;
    public Transform upCorner;
    public Transform downCorner;
    Vector3 target;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 6f)
        {
            SetTarget();
            timer = 0;
        }


    }
    void SetTarget()
    {
        float xPos = Random.Range(leftCorner.position.x, rightCorner.position.x);
        float zPos = Random.Range(downCorner.position.z, upCorner.position.z);
        target = new Vector3(xPos, transform.position.y, zPos);
        nav.SetDestination(target);
    }
    public void ResetPlatform()
    {
        this.transform.position =  new Vector3(0,0.5f,0);
        SetTarget();
        Debug.Log("Platform reset!!");
    }
}