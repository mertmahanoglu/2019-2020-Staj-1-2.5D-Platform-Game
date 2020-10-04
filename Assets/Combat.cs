using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator animator;
    public int maxHealt = 100;
    public int currentHealth;
    public EnemyHealthBar healthBar;
    public GameObject coin;
    
    void Start()
    {
        if (gameObject.tag=="Boss")
        {
            maxHealt = 500;
            
        }
        currentHealth = maxHealt;
        healthBar.SetMaxHealth(maxHealt);
        
    }
    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        // Damage yeme animasyonu
        animator.SetTrigger("Hurt");
        if (currentHealth<=0)
        {
            Die();
        }
        
    }
    public void Die() 
    {
        //Ölme Animasyonu
        Debug.Log("Enemy Died");
        animator.SetBool("Death", true);
        gameObject.SetActive(false);
        Instantiate(coin, transform.position,Quaternion.identity);
    }

    
}
