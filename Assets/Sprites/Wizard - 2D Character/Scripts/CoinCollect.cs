using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int value;
    [SerializeField] private AudioClip coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(coin);
            gameObject.SetActive(false);
            Destroy(gameObject);
            CoinCounter.instance.Increase(value);
            
            
        }
    }
}
