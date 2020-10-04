using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelGecis : MonoBehaviour
{

    public string levelName;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            SceneManager.LoadScene(levelName);
        }
    }
    
}
