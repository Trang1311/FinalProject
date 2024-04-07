using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private AudioClip slimemove;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private SpriteRenderer spriteRenderer;

    private float cooldownTimer = Mathf.Infinity;
    

    private Animator anim;
    private Heart playerHealth;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }
    private void Update()
    {
        // Di chuyển slime
        if (movingLeft)
        {
            // Di chuyển sang trái nếu chưa đạt đến biên trái
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                // Đạt biên trái, đảo ngược hướng di chuyển
                movingLeft = false;
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            // Di chuyển sang phải nếu chưa đạt đến biên phải
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                // Đạt biên phải, đảo ngược hướng di chuyển
                movingLeft = true;
                spriteRenderer.flipX = true;
            
            }
        }

        // Cập nhật cooldown và tấn công nếu có người chơi trong tầm nhìn
        cooldownTimer += Time.deltaTime;
        if (PlayerinSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
            }
        }
    }

    // Hàm đảo ngược hình ảnh của slime

    private bool PlayerinSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center +transform.right * range * transform.localScale.x, 
            new Vector3( boxCollider.bounds.size.x * range, boxCollider.bounds.size.y , boxCollider.bounds.size.z),
            0, Vector2.left, 0,playerLayer);
        if(hit.collider!= null)
        {
            playerHealth =hit.transform.GetComponent<Heart>();
        }
        return hit.collider != null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Heart>().TakeDamage(damage);
        }
    }
}


