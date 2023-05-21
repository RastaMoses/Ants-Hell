using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHillCollision : MonoBehaviour
{

    public AntHillStats stats;
    public GameObject shop;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TakeDamage(float damageAmount)
    {
        stats.health -= damageAmount;
        Debug.Log(" Hive Health: " + stats.health );
    }

    public void Die()
    {

        //Game Over
        Debug.LogError("Hive Dead!");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            shop.GetComponent<Shop>().EnteredHive();
        }
    }

    // Update is called once per frame

}
