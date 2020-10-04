using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Player player;
    public Collider2D attackPoint;
    public int damage = 10;
   
   // public Rigidbody2D fizik;
  
    public Animator animator;
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Player"))
        {
                animator.SetTrigger("EnemyAttack");
            if (gameObject.tag=="Boss")
            {
                animator.SetTrigger("Attack");
                damage = 25;
            }
                attackPoint.enabled = false;
                player.takeDamage(damage);
                yield return new WaitForSeconds(3);
                attackPoint.enabled = true;
        }
       /* else if (col.CompareTag("Kose"))
        {
            fizik.AddForce(new Vector2(0, 900));
        }*/

    }
    private void Update()
    {
        OnTriggerEnter2D(attackPoint);
    }
}
