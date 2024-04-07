using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TMP_Text totalCoinsText;
    [SerializeField]  private AudioClip Button;
    private void Start()
    {
        // Lấy tổng số coin từ CoinCounter
        int totalCoins = CoinCounter.instance.currentCoins;

        // Hiển thị tổng số coin trên Text hoặc bất kỳ phương tiện nào khác
        totalCoinsText.text = "Tổng Coin: " + totalCoins.ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
