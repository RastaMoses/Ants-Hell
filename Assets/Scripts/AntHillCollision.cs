using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHillCollision : MonoBehaviour
{

    public AntHillStats stats;
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
    // Update is called once per frame
    
}
