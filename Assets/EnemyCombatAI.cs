using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyCombatAI : MonoBehaviour
{
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;
     public Player player;
    public Animator animator;

    public Transform target;
    public float chaseRange;
    public float attackRange;
    public int damage;
    float lastAttackTime;
    public float attackDelay;

    private void Start()
    {
        currentPatrolIndex = 0;
        
    }

    private void Update()
    {
        float playerDist = Vector3.Distance(transform.position, target.position);

        if (playerDist<attackRange)
        {
            if (Time.time>lastAttackTime+attackDelay)
            {
                animator.SetTrigger("EnemyAttack");
                player.takeDamage(20);
                lastAttackTime = Time.time;
            }
          
        }
    }


}
