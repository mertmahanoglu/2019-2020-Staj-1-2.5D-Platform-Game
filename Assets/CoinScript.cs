using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject coinText;
    private void Start()
    {
        coinText = GameObject.FindGameObjectWithTag("CoinText");
    }
    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
           
        }
    }
}
