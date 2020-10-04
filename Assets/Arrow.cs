using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    public int damage = 30;
    void Start()
    {
        if (Input.GetAxisRaw("Horizontal")> 0)
        {
            rb.velocity = transform.right * (-speed);
        }
        else
        {
            rb.velocity = transform.right * speed;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else
        {
            Combat enemy = hitInfo.GetComponent<Combat>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }

        }


    }
    

}
