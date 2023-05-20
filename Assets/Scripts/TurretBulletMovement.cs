using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletMovement : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public TurretBulletStats stats;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody.AddForce(stats.shotDirection * stats.shotSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        stats.lifeTime += Time.deltaTime;
        if (stats.lifeTime >= 7)
        {
            Destroy(gameObject);
        }
    }
}
