using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TakeDamage(float damageAmount)
    {
        stats.health -= damageAmount;
        Debug.Log(" Player Health: " + stats.health);

    }

    public void Die()
    {

        //Teleport Back
        Debug.LogError("Player Dead!");
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player collided!");
        if (collision.gameObject.layer == 8)
        {
            stats.shells += 1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == 12)
        {
            stats.shells += 5;
            Destroy(collision.gameObject);
        }
    }

}
