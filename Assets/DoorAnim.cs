using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{

   
   
    public SpriteRenderer renderer;
    
    public Animator animator;

    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        animator.enabled = false;
        renderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            renderer.enabled = true;
            animator.enabled = true;

        }

    }
   
}
