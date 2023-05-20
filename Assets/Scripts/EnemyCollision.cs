using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public EnemyStats stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
           
            collision.gameObject.GetComponent<PlayerCollision>().TakeDamage(stats.damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 11)
        {

            collision.gameObject.GetComponent<AntHillCollision>().TakeDamage(stats.damage);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        stats.health -= damageAmount;
        
    }

    public void Die()
    {


        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.health<= 0)
        {
            Die();
        }
    }
}
