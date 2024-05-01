using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public int p1MaxHealth = 4;
    public int p2MaxHealth = 4;

    public int p1CurrentHealth;
    public int p2CurrentHealth;

    public GameObject gameOverPlayer1Wins;
    public GameObject gameOverPlayer2Wins;

    public HealthBar p1HealthBar;
    public HealthBar p2HealthBar;
    void Start()
    {
         p1CurrentHealth = p1MaxHealth;
         p2CurrentHealth = p2MaxHealth;
    }

    void Update()
    {
        // Set GameOverScreen When A player Dies
        if(p1CurrentHealth <= 0)
        {
            player1.SetActive(false);
            gameOverPlayer2Wins.SetActive(true);
        }

        if(p2CurrentHealth <= 0)
        {
            player2.SetActive(false);
            gameOverPlayer1Wins.SetActive(true);
        }
    }

    //Update Player's health bar when recieving damage. 
    public void HurtP1()
    {
        p1CurrentHealth -= 1;
        p1HealthBar.SetHealth(p1CurrentHealth);
        
    }

    public void HurtP2()
    {
        p2CurrentHealth -= 1;
        p2HealthBar.SetHealth(p2CurrentHealth);
    }

}
