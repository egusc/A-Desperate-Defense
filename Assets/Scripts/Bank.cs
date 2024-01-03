using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{

    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    TMP_Text goldCounter;

    void Awake()
    {
        currentBalance = startingBalance;
        goldCounter = FindObjectOfType<GoldCounter>().GetComponent<TMP_Text>();
        UpdateGoldCounterText();
    }
    

    public int CurrentBalance { 
        get { return currentBalance; }
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateGoldCounterText();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if(currentBalance < 0)
        {
            //Lose game
            ReloadScene();
        }
        UpdateGoldCounterText();
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void UpdateGoldCounterText()
    {
        goldCounter.text = "Gold: " + currentBalance.ToString();
    }


}
