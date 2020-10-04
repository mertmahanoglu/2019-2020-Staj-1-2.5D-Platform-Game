using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    public Animator animator;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;


    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (karakterKontrol.isDead == false)
                {
                    Shoot();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
                else
                {
                    karakterKontrol.isDead = true;
                }
            }
        }

       
    }

    void Shoot() 
    {
        if (karakterKontrol.isDead == false)
        {
            Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            animator.SetTrigger("BowTrigger");
        }
        else
        {
            karakterKontrol.isDead = true;
        }
        
    
    }
}
