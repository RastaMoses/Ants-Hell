using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShellCollisionChecker : MonoBehaviour
{
    public float checkRadius;
    public LayerMask WhatShouldIAvoid;

    private Collider2D _Collider;
    Rigidbody2D rb;

    GameObject magnetTarget;
    float magnetSpeed;

    bool magnetized = false;

    List<GameObject> magnetList = new List<GameObject>();
    private void Awake()
    {
        TryGetComponent(out _Collider);
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Start()
    {
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        // disable collider to avoid hitting itself when checking for collisions
        _Collider.enabled = false;

        int counter = 3;
        int noLocationCounter = 20;
        while (true)
        {
            
            // check for collisions
            if (Physics2D.OverlapCircle(transform.position, checkRadius, WhatShouldIAvoid))
            {
                counter--;
                noLocationCounter--;
                // if found, use RandomPointOnBox and Factory static variables to look for a new position
                transform.position = FindObjectOfType<shellSpawner>().RandomPointOnBox();
                Debug.Log("relocating shell");
            }
            else
            {
                // else enable collider and break the loop
                _Collider.enabled = true;
                GetComponent<SpriteRenderer>().enabled = true;
                yield break;
            }

            if (counter <= 0)
            {
                if (noLocationCounter <= 0) { yield return null; }
                yield return new WaitForEndOfFrame();
                counter = 3;
            }
                
        }
    }

    private void Update()
    {
        if(magnetized)
        {
            rb.velocity = Vector3.MoveTowards(transform.position, magnetTarget.transform.position, magnetSpeed * Time.deltaTime);
        }
    }

    public void Magnetize(float attractSpeed, GameObject target, bool player)
    {
        magnetList.Add(target);
        if(player || !magnetized)
        {
            magnetTarget = target;
            magnetSpeed = attractSpeed;
            magnetized= true;
        }
    }

    public void DeMagnetize(GameObject target)
    {
        if (magnetList.Contains(target)) 
        {
            magnetList.Remove(target);
        }
        if (magnetList.Count > 0)
        {
            if (target.GetComponent<PlayerMagnet>())
            {
                Magnetize(target.GetComponent<PlayerMagnet>().attractSpeed, target, true);
            }
            else
            {
                Magnetize(target.GetComponent<Magnet>().attractSpeed, target, false);
            }
        }
        else
        {
            magnetized = false;

        }
    }
}
