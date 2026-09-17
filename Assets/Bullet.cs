using System.Reflection.Metadata;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage = 1;
    public Factions targetFaction = Factions.Enemies;
    float timer = 0.2f;
    void Update()
    {
        Vector2 scaledRight = Vector2.right;
        scaledRight.x *= Mathf.Sign(transform.localScale.x);
        GetComponent<Rigidbody2D>().linearVelocity = scaledRight * 20.0f;

      
        timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            if (health.faction == targetFaction)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
