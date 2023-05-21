using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] float attractSpeed;
    [SerializeField] float time = 90f;
    [SerializeField] GameObject constructionZone;
    [SerializeField] LayerMask shellsLayers;

    Collider2D[] shellsInRadius;

    void Start()
    {
        shellsInRadius = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius, shellsLayers);
        foreach (Collider2D i in shellsInRadius)
        {
            //i.GetComponent<EnemyAI>().Magnet(attractSpeed, transform.position);
        }
        StartCoroutine(Timer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shell"))
        {
            //collision.GetComponent<Shell>().Magnet(attractSpeed, transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Shell"))
        {
            //collision.GetComponent<Shell>().StopMagnet();
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        shellsInRadius = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius, shellsLayers);
        foreach (Collider2D i in shellsInRadius)
        {
            //i.GetComponent<Shell>().StopMagnet();
        }
        Instantiate(constructionZone, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
