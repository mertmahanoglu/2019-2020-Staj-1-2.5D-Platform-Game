using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpgradeScript : MonoBehaviour
{
   
    public int lastDamage;
    public static int coinCount = 0;
    public GameObject CoinText;
    private void Start()
    {

        //PlayerPrefs.DeleteAll();
         /*PlayerPrefs.SetInt("MaxHealth", 100);
         PlayerPrefs.SetInt("MaxDamage", 40);
       PlayerPrefs.SetFloat("MaxSpeed", 15f);
        PlayerPrefs.SetInt("MaxBoost", 5);*/
        
        lastDamage = PlayerPrefs.GetInt("MaxDamage");
        karakterKontrol.artisMik = PlayerPrefs.GetInt("MaxBoost");
        Player.maxHealth = PlayerPrefs.GetInt("MaxHealth");
        karakterKontrol.runKats = PlayerPrefs.GetFloat("MaxSpeed");
        karakterKontrol.coinCount = PlayerPrefs.GetInt("MaxCoin");
        coinCount = PlayerPrefs.GetInt("MaxCoin");
        CoinText.GetComponent<TextMeshProUGUI>().text = coinCount.ToString();
        Debug.Log(lastDamage);
        Debug.Log(Player.maxHealth);
        Debug.Log(karakterKontrol.runKats);
        Debug.Log(karakterKontrol.artisMik);
    }

    private void Update()
    {
        CoinText.GetComponent<TextMeshProUGUI>().text = coinCount.ToString();
    }
    public void upgradeHealth() 
    {

        int healthCost = 300;
        if (karakterKontrol.coinCount >= healthCost)
        {
            Player.maxHealth += 10;
            PlayerPrefs.SetInt("MaxHealth", Player.maxHealth);
            PlayerPrefs.SetInt("MaxCoin", karakterKontrol.coinCount -= healthCost);
            coinCount = PlayerPrefs.GetInt("MaxCoin");
            CoinText.GetComponent<TextMeshProUGUI>().text = coinCount.ToString();
        }

        else
        {
            Debug.Log("Coin yetersiz");
        }

    }
    public void upgradeDamage()
    {
        int damageCost = 500;
        if (karakterKontrol.coinCount >= damageCost)
        {

            lastDamage += 10;
            PlayerCombat.attackDamage = lastDamage;
            PlayerPrefs.SetInt("MaxDamage", lastDamage);
            PlayerPrefs.SetInt("MaxCoin", karakterKontrol.coinCount -= damageCost);
            coinCount = PlayerPrefs.GetInt("MaxCoin");
            CoinText.GetComponent<TextMeshProUGUI>().text = coinCount.ToString();
        }
        else
        {
            Debug.Log("Coin yetersiz");
        }


    }

    public void upgradeSpeed()
    {
        int speedCost = 400;
        if (karakterKontrol.coinCount >= speedCost)
        {
            karakterKontrol.runKats += 1;
            PlayerPrefs.SetFloat("MaxSpeed", karakterKontrol.runKats);
            PlayerPrefs.SetInt("MaxCoin", karakterKontrol.coinCount -= speedCost);
            coinCount = PlayerPrefs.GetInt("MaxCoin");
            CoinText.GetComponent<TextMeshProUGUI>().text = coinCount.ToString();
        }
        else
        {
            Debug.Log("Coin yetersiz");
        }

    }
    public void coinBoost() 
    {
        int boostCost = 750;
        if (karakterKontrol.coinCount>= boostCost)
        {
            karakterKontrol.artisMik += 5;
            PlayerPrefs.SetInt("MaxBoost", karakterKontrol.artisMik);
            PlayerPrefs.SetInt("MaxCoin", karakterKontrol.coinCount -= boostCost);
            coinCount = PlayerPrefs.GetInt("MaxCoin");
            CoinText.GetComponent<TextMeshProUGUI>().text = coinCount.ToString();
        }
        else
        {
            Debug.Log("Coin yetersiz");
        }
       

    }

}
