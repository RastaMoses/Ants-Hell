using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public float radius = 1f;
    public float attractSpeed = 2f;
    [SerializeField] LayerMask shellsLayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shell"))
        {
            collision.GetComponent<ShellCollisionChecker>().Magnetize(attractSpeed, gameObject, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Shell"))
        {
            collision.GetComponent<ShellCollisionChecker>().DeMagnetize(gameObject);
        }
    }

    public void ChangeRadius(float radius)
    {
        GetComponent<CircleCollider2D>().radius = radius;
    }
}
