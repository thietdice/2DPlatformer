using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
   private void OnCollisionEnter2D (Collision2D collision)
   {
    if(collision.gameObject.CompareTag("Traps"))
    {
        Die();
    }
   }
   private void Die() 
   {
    anim.SetTrigger("Death");
    rb.bodyType = RigidbodyType2D.Static;
   }

   private void RestartLevel()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
   }
}
