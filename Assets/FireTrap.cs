using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private Player player;
    public Collider2D fireCol;
    public Animator animator;
    public SpriteRenderer renderer;

    bool colActive = true;
    bool playAnim = true;
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private IEnumerator OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            player.takeDamage(1);
            colActive = false;
            fireCol.enabled = false;


            //animator.gameObject.SetActive(false);
            renderer.enabled = false;
            //animator.enabled = false;

            yield return new WaitForSeconds(3);
            //animator.gameObject.SetActive(true);
            //animator.enabled = true;
            renderer.enabled = true;
            fireCol.enabled = true;


        }

    }

    private void Update()
    {
        OnTriggerEnter2D(fireCol);   
    }
}
