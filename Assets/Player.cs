using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public static int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthBar;
   

    
    private void Start()
    {
        maxHealth = PlayerPrefs.GetInt("MaxHealth");
        //PlayerPrefs.DeleteAll(); //Sıfırlamak için
        if (maxHealth==0)
        {
            maxHealth = 100;
            PlayerPrefs.SetInt("MaxHealth", 100);
            maxHealth = PlayerPrefs.GetInt("MaxHealth");
            currentHealth = maxHealth;
        }
        else
        {
            maxHealth = PlayerPrefs.GetInt("MaxHealth");

            healthBar.SetMaxHealth(maxHealth);
            currentHealth = maxHealth;

        }
         
    }
    // Update is called once per frame
    public void takeDamage(int damage) 
    {

        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        if (currentHealth<=0)
        {
            Die();

        }
    
    }

    void Die() 
    {
        animator.SetTrigger("Die");
        karakterKontrol.isDead = true;
    }
    void Respawn() 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = GameObject.FindWithTag("Respawn").transform.position;
            karakterKontrol.isDead = false ;
            currentHealth = maxHealth;
            healthBar.setHealth(currentHealth);
            
        }

    }

    private void Update()
    {
        Respawn();

        
    }


}
