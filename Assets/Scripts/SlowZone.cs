using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    [SerializeField] float speedMultiplier = 0.4f;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float time = 45f;
    [SerializeField] GameObject constructionZone;

    Collider2D[] enemiesInRadius;
    // Start is called before the first frame update
    void Start()
    {
        enemiesInRadius = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius, enemyLayer);
        foreach (Collider2D i in enemiesInRadius)
        {
            //i.GetComponent<EnemyAI>().Slow(speedMultiplier);
        }
        StartCoroutine(Timer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //collision.GetComponent<EnemyAI>().Slow(speedMultiplier);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //collision.GetComponent<EnemyAI>().StopSlow();
        }
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        enemiesInRadius = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius, enemyLayer);
        foreach (Collider2D i in enemiesInRadius)
        {
            //i.GetComponent<EnemyAI>().StopSlow();
        }
        Instantiate(constructionZone, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
