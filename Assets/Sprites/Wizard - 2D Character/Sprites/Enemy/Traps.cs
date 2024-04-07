using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField] private float damage;
    private List<Collider2D> collidingObjects = new List<Collider2D>(); // Danh sách các đối tượng đang va chạm với trap

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Thêm đối tượng vào danh sách va chạm
            collidingObjects.Add(other);

            // Trừ máu cho nhân vật
            other.GetComponent<Heart>().TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Loại bỏ đối tượng khỏi danh sách va chạm
            collidingObjects.Remove(other);
        }
    }

    // Kiểm tra xem nhân vật còn tiếp xúc với trap không
    private bool IsPlayerColliding(Collider2D playerCollider)
    {
        return collidingObjects.Contains(playerCollider);
    }
}
