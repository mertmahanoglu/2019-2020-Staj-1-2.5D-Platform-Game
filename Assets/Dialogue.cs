using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    int index;
    public float typeSpeed;
    public GameObject continueButton;
    public GameObject characterBalloon;
    public GameObject bossBalloon;
    public string sceneName;


    private void Start()
    {
        Debug.Log(index);
        characterBalloon.SetActive(true);
        
        StartCoroutine(Type());

    }
    IEnumerator Type() 
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
       
    }

    private void Update()
    {
        continueButton.SetActive(false);
        if (textDisplay.text==sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    public void nextSentence() 
    {
        continueButton.SetActive(false);
        if (index<sentences.Length-1)
        {

                
                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
            if (index==0|| index == 2 || index == 5 || index == 6 )
            {
                characterBalloon.SetActive(true);
                bossBalloon.SetActive(false);
                Debug.Log(index);
                Debug.Log("Character;");
            }
            else if (index == 1 || index == 3 || index == 4)
            {
                characterBalloon.SetActive(false);
                bossBalloon.SetActive(true);
                Debug.Log("Boss;");
            }

        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            SceneManager.LoadScene(sceneName);
        }
    
    }
}
