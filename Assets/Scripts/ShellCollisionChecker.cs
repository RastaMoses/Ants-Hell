using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShellCollisionChecker : MonoBehaviour
{
    public float checkRadius;
    public LayerMask WhatShouldIAvoid;

    private Collider2D _Collider;

    private void Awake()
    {
        TryGetComponent(out _Collider);
    }

    private void Start()
    {
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        // disable collider to avoid hitting itself when checking for collisions
        _Collider.enabled = false;
        while (true)
        {
            // check for collisions
            if (Physics2D.OverlapCircle(transform.position, checkRadius, WhatShouldIAvoid))
            {
                // if found, use RandomPointOnBox and Factory static variables to look for a new position
                transform.position = FindObjectOfType<shellSpawner>().RandomPointOnBox();
            }
            else
            {
                // else enable collider and break the loop
                _Collider.enabled = true;
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
