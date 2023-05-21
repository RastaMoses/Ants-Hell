using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public EnemyStats stats;
    [SerializeField]
    LayerMask playerLayer;
    [SerializeField]
    LayerMask hiveLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy Collided!");
        if ((playerLayer.value & (1 << collision.gameObject.transform.gameObject.layer)) != 0)
        {
           
            collision.gameObject.GetComponent<PlayerCollision>().TakeDamage(stats.damage);
            Destroy(gameObject);
        }
        else if ((hiveLayer.value & (1 << collision.gameObject.transform.gameObject.layer)) != 0)
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
