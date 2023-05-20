using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public bool zigzag = false;
    public float zigzagIntervalSpeed = 2f;
    public float zigzagDegree = 30f;

    Path path;
    int currentWaypoint = 0;
    bool reachEndOfPath = false;
    bool zigzagDir = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb= GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        
        if (zigzag) { StartCoroutine(ZigZagCD()); }
    }

    void UpdatePath()
    {
        if (seeker.IsDone()) { seeker.StartPath(rb.position, target.position, OnPathComplete); }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) { return; }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachEndOfPath= true;
            return;
        }
        else
        {
            reachEndOfPath= false;
        }

        Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        if(zigzag)
        {
            if (zigzagDir) { dir = Quaternion.Euler(0, 0, zigzagDegree) * dir; }
            else { dir = Quaternion.Euler(0, 0, -zigzagDegree) * dir; }
        }
        Vector2 force= dir * speed * Time.fixedDeltaTime;

        rb.AddForce(force);

        var velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        float angleInRadian = Mathf.Atan2(velocity.y, velocity.x);
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, (Mathf.Rad2Deg * angleInRadian)-90));
        gameObject.transform.rotation = rotation;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //transform.LookAt(target.position);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint= 0;
        }
    }

    IEnumerator ZigZagCD()
    {   
        while(true)
            {
                yield return new WaitForSeconds(zigzagIntervalSpeed);
                zigzagDir = !zigzagDir;
            }
    }
}
