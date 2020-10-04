using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public static int attackDamage = 40;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;



    private void Start()
    {
        // PlayerPrefs.DeleteAll();
        if (attackDamage == 0)
        {
            attackDamage = 40;
            PlayerPrefs.SetInt("MaxDamage", 40);
        }
        else
        {
            attackDamage = PlayerPrefs.GetInt("MaxDamage");
        }


        Debug.Log(attackDamage);
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (karakterKontrol.isDead == false)
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                else
                {
                    karakterKontrol.isDead = true;
                }

            }
        }

    }
    public void Attack()
    {
        //Attack Animasyonu
        animator.SetTrigger("Attack");
        //Attack rangeindeki düşmanları tespit etme
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Combat>().TakeDamage(attackDamage);

        }


    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
