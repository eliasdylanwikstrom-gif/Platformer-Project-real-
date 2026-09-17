using System.Collections;
using UnityEngine;

using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Events;
using NUnit.Framework;

public class Player : MonoBehaviour
{
    //public float jumpforce = 10f;
    public int health = 100; //make a new "health" script 
   
    public AudioClip hurtClip;
    private AudioSource audioSource;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;
   
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
       audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision) // Fix Later: Rework As "I Do Towards You"
    {
        if (collision.gameObject.tag == "Damage")
        {
            PlaySFX(hurtClip);
            health -= 25;
            
            //rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            StartCoroutine(BlinkRed());

            if (health <= 0) 
            {
                Die();
            }
        }
    }
    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    private void Die()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void PlaySFX(AudioClip audioClip, float volume = 1f) 
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}