using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGunScript : MonoBehaviour
{
    public Transform barrelEnd;
    public GameObject bulletPrefab;
    public AntHillStats stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stats.fireDelay += Time.deltaTime;
        if (stats.fireDelay > (60/stats.fireRate) ) 
        {
            stats.fireDelay -= 60/stats.fireRate;
            ShootBullet(stats.damage, stats.shotSpeed, barrelEnd.position, barrelEnd.position - gameObject.transform.position);

        }
    }

    public void ShootBullet(float damage, float shotSpeed, Vector2 shotDirection, Vector2 barrelPosition)
    {
        GameObject bullet = Instantiate(bulletPrefab);
        TurretBulletStats bulletStats = bullet.GetComponent<TurretBulletStats>();
        bullet.transform.position = barrelPosition;
        bulletStats.damage = damage;
        bulletStats.shotSpeed = shotSpeed;
        bulletStats.shotDirection = shotDirection;
    }

   
}
