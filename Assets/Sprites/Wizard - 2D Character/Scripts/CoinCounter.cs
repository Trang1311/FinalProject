using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coin;
    public int currentCoins = 0; 
    private bool isIncreasing = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        coin.text = "Coins: " + currentCoins.ToString();
    }

    public void Increase(int i)
    {
        if (!isIncreasing) // Kiểm tra xem đã tăng giá trị coins trong frame này chưa
        {
            isIncreasing = true; // Đánh dấu rằng đang tăng giá trị coins
            currentCoins += i;
            coin.text = "Coins: " + currentCoins.ToString();
            isIncreasing = false; // Đánh dấu rằng đã hoàn thành tăng giá trị coins trong frame này
        }
    }
}
