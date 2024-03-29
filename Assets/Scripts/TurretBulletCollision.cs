using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletCollision : MonoBehaviour
{

    public TurretBulletStats stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Something!");
        if (collision.gameObject.layer == 10)
        {
            if (!stats.piercing)
            {
                Destroy(gameObject);
            }
            collision.gameObject.GetComponent<EnemyCollision>().TakeDamage(stats.damage);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
