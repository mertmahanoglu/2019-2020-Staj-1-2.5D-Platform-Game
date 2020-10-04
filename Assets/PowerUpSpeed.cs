using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{

    public GameObject boostName;
    Player player;
    
    public CircleCollider2D collider;
    
    public float speedmultiplier = 1.5f;
    public float duration = 4;
    public int damageAmount = 10;
    public int hpBoostAmount = 20;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player")&& (boostName.tag=="SpeedBoost"))
        {

           StartCoroutine(PickUpSpeed());
        }
        else if (col.CompareTag("Player") && (boostName.tag == "DamageBoost"))
        {
            StartCoroutine(PickUpDamage());
        }
        else if (col.CompareTag("Player") && (boostName.tag == "HpBoost"))
        {
            StartCoroutine(PickUpHP());

        }

    }


    IEnumerator PickUpSpeed() 
    {
        karakterKontrol.runKats *= speedmultiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        karakterKontrol.runKats /= speedmultiplier;
        Destroy(gameObject);
    }

    IEnumerator PickUpDamage()
    {
        PlayerCombat.attackDamage += damageAmount;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        PlayerCombat.attackDamage -= damageAmount;
        
        
        Destroy(gameObject);
    }

    IEnumerator PickUpHP()
    {
        player.currentHealth += hpBoostAmount;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        Debug.Log(player.currentHealth);
        yield return new WaitForSeconds(duration);
    }
}
