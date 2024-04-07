using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip heal;
    private bool collected = false; // Biến để kiểm tra xem collectable đã được sử dụng chưa

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collected && collision.CompareTag("Player")) // Kiểm tra nếu collectable chưa được sử dụng và va chạm với player
        {
            SoundManager.instance.PlaySound(heal);
            collision.GetComponent<Heart>().AddHeart(healthValue);
            collected = true; // Đánh dấu collectable đã được sử dụng
            gameObject.SetActive(false); // Tắt collectable
        }
    }
}
