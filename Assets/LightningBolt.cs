using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    // Use this for initialization

    public Transform a, b;
    [Range(0, 1)]
    public float speed = 0.5f;
    Player player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(a.position, b.position, pingPong);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.takeDamage(20);
        }
    }
}


