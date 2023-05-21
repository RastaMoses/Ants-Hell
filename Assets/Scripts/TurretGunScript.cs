using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class TurretGunScript : MonoBehaviour
{
    public Transform barrelEnd;
    public GameObject bulletPrefab;
    public AntHillStats stats;
    public GameObject enemySpawner;
    public GameObject enemyList;

    public GameObject outPost;

    public int shotAmount;

    public float range;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("EnemyDirector");
        enemyList = enemySpawner.GetComponent<EnemySpawnDirector>().enemyList;
    }

    // Update is called once per frame
    void Update()
    {
        { 
            Aim();
            

        }
    }

    public void Aim()
    {
        if (enemyList.transform.childCount > 0)
        {
            GameObject closestEnemy = enemyList.transform.GetChild(0).gameObject;
            foreach (Transform enemy in enemyList.transform)
            {
                if (Vector3.Distance(enemy.transform.position, transform.position) < Vector3.Distance(closestEnemy.transform.position, transform.position))
                {
                    closestEnemy = enemy.gameObject;
                }
            }
            transform.LookAt(closestEnemy.transform.position);




            //mainGun.transform.rotation = Quaternion.Euler(aimDirection.x, aimDirection.y, 0);
            transform.right = closestEnemy.transform.position - new Vector3(transform.position.x, transform.position.y);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 90);

            stats.fireDelay += Time.deltaTime;
            if (stats.fireDelay > (60 / stats.fireRate))
            {
                stats.fireDelay -= 60 / stats.fireRate;

                if (Vector3.Distance(closestEnemy.transform.position, transform.position) < range)
                {
                    ShootBullet(stats.damage, stats.shotSpeed, barrelEnd.position - gameObject.transform.parent.position, barrelEnd.position);
                    shotAmount -= 1;
                    if(shotAmount <= 0)
                    {
                        Die();
                    }
                }
            }


        }
    }

    public void Die()
    {
        Instantiate(outPost);
        Destroy(gameObject);
    }


    public void ShootBullet(float damage, float shotSpeed, Vector2 shotDirection, Vector2 barrelPosition)
    {
        

        GameObject bullet = Instantiate(bulletPrefab);
        TurretBulletStats bulletStats = bullet.GetComponent<TurretBulletStats>();
        bullet.transform.position = barrelPosition;
        bullet.transform.localScale *= 1.5f;
        bulletStats.damage = damage;
        bulletStats.shotSpeed = shotSpeed;
        bulletStats.shotDirection = shotDirection;
    }

   
}
