using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] public  float attractSpeed;
    [SerializeField] float time = 90f;
    [SerializeField] GameObject constructionZone;
    [SerializeField] LayerMask shellsLayers;

    Collider2D[] shellsInRadius;

    void Start()
    {
        shellsInRadius = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius, shellsLayers);
        foreach (Collider2D i in shellsInRadius)
        {
            i.GetComponent<ShellCollisionChecker>().Magnetize(attractSpeed, gameObject, false);
        }
        StartCoroutine(Timer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shell"))
        {
            collision.GetComponent<ShellCollisionChecker>().Magnetize(attractSpeed, gameObject, false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Shell"))
        {
            collision.GetComponent<ShellCollisionChecker>().DeMagnetize(gameObject);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        shellsInRadius = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius, shellsLayers);
        foreach (Collider2D i in shellsInRadius)
        {
            i.GetComponent<ShellCollisionChecker>().DeMagnetize(gameObject);
        }
        Instantiate(constructionZone, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
