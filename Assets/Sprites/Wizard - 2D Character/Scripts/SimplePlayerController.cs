using UnityEngine;

namespace ClearSky
{
    public class SimplePlayerController : MonoBehaviour
    {
        [SerializeField] private AudioClip AtkSound;
        [SerializeField] private AudioClip FootSound;
        [SerializeField] private AudioClip JumpSound;
        [SerializeField] private AudioClip HurtSound;
        [SerializeField] private AudioClip DieSound;
        public float movePower = 10f;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Jump();
                Run();

            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }


        void Run()
        {
            
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                
                direction = -1;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                {
                    SoundManager.instance.PlaySound(FootSound);
                    anim.SetBool("isRun", true);
                }    
                   

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                {
                    
                    anim.SetBool("isRun", true);
                }    
                    

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        private int jumpCount = 0;
        public int maxJumpCount = 2; // Số lần nhảy tối đa (bao gồm cả nhảy bình thường và double jump)

        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0) && jumpCount < maxJumpCount)
            {
                SoundManager.instance.PlaySound(JumpSound);
                rb.velocity = Vector2.zero;

                Vector2 jumpVelocity = new Vector2(0, jumpPower);
                rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

                jumpCount++;
                anim.SetBool("isJump", true); // Kích hoạt animation nhảy
            }

            if (rb.velocity.y == 0)
            {
                isJumping = false;
                jumpCount = 0; // Reset jump count when the player lands on the ground
                anim.SetBool("isJump", false); // Tắt animation nhảy khi nhân vật chạm đất
            }
        }

        void Attack()
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SoundManager.instance.PlaySound(AtkSound);
                anim.SetTrigger("attack");
            }
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SoundManager.instance.PlaySound(HurtSound);
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SoundManager.instance.PlaySound(DieSound);
                anim.SetTrigger("die");
                alive = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("idle");
                alive = true;
            }
        }
    }
}