using ClearSky;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float startingHealth;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip dieSound;
    public UIManager manager;
    public float currentHealth { get; private set; }
    private Animator anim;
    private Rigidbody2D rb;
    private int direction = 1;
    private bool dead;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();

    }
    public void TakeDamage( float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
       if (currentHealth > 0) 
        {
            SoundManager.instance.PlaySound(hurtSound);
            anim.SetTrigger("hurt");
            if (direction == 1)
                rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
            else
                rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
        }
       else
        {
            if(!dead)
            {
                SoundManager.instance.PlaySound(dieSound);
                anim.SetTrigger("die");
                GetComponent<SimplePlayerController>().enabled = false;
                dead = true;
                manager.GameOver();

            }    
            
            
        }    

    }
    public void AddHeart(float _value)
    {

        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);

    }
    public void RespawnPlayer()
    {
        dead= false;
        AddHeart(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("idle");

    }
}
