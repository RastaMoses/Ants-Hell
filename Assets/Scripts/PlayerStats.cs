using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float health;
    public float movementSpeed;
    public float movementAcceleration;
    public int shells;
    public float carryCapacity = 15;
    public GameObject Inventory;

    float baseSpeed;
    public float maxHP;
    public bool immune;


    public void Buff(float speedMultiplier)
    {
        health = maxHP;
        baseSpeed = movementSpeed;
        movementSpeed = movementSpeed * speedMultiplier;
        immune= true;
    }
    public void Debuff()
    {
        movementSpeed = baseSpeed;
        immune= false;
    }


    // Start is called before the first frame update
    void Start()
    {
        maxHP = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
