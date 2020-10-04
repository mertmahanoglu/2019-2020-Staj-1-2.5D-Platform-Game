using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossAI : MonoBehaviour
{
    public Transform target;
    public Transform enemyGFX;



    public float speed = 200f;
    public float nextWayDistance = 3f;

    Path path;

    int currentWayPoint = 0;
    bool reachedEndOfPath = false;


    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);

    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }

    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (path == null)
            return;
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }


        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
        

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayDistance)
        {
            currentWayPoint++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if (rb.velocity.x <= 0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            
        }
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f);
        if (collision.CompareTag("Kose"))
        {
            rb.AddForce(new Vector2(0, 800));
        }
    }

}
