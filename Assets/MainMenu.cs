using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int newDamage;
    private float newSpeed;
    private int newHealth;
    private int newCoin;
    private int newBoost;

    private void Start()
    {
        newDamage = PlayerPrefs.GetInt("MaxDamage");
        newSpeed = PlayerPrefs.GetFloat("MaxSpeed");
        newHealth = PlayerPrefs.GetInt("MaxHealth");
        newCoin = PlayerPrefs.GetInt("MaxCoin");
        newBoost = PlayerPrefs.GetInt("MaxBoost");

        if (newDamage == 0)
        {
            PlayerPrefs.SetInt("MaxDamage", 40);
        }
        if (newSpeed == 0)
        {
            PlayerPrefs.SetFloat("MaxSpeed", 15f);
        }
        if (newCoin == 0)
        {
            PlayerPrefs.SetInt("MaxCoin", 500);
        }
        if (newBoost == 0)
        {
            PlayerPrefs.SetInt("MaxBoost", 5);
        }

    }
    public void PlayButton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitButton()
    {

        Application.Quit();

    }
}
