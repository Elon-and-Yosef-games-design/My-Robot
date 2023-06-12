using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// this class responsibale on the general player attributes such as his money, his health and such.
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coin;
    [SerializeField] TextMeshProUGUI Exp;


    public int health = 100;
    public int maxHealth = 100;
    public int exp = 0;
    public int coins = 5;

    private void Update()
    {
        coin.text = coins.ToString();
        Exp.text = exp.ToString();
    }
}
