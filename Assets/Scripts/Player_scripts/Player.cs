using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coin;

    public float health = 100;
    public int maxHealth = 100;
    public int exp = 0;
    public int coins = 5;

    public void TakeDamage(float amount)  // Add this method
    {
        Debug.Log("current health: " + health);
        health -= amount;
        if (health < 0) health = 0;
        // Add code here to react to the player's health reaching 0, if desired
    }

    private void Update()
    {
        //coin.text = coins.ToString();
    }
}
