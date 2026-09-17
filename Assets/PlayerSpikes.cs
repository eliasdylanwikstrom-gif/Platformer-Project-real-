using System;
using UnityEngine;

public class PlayerSpikes : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Health health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision) // Fix Later: Rework As "I Do Towards You"
    {
        if (collision.gameObject.tag == "Damage")
        {
            rb.AddForce(Vector2.up * 12.0f, ForceMode2D.Impulse);
            health.TakeDamage(25);
            
        }
    }
}
