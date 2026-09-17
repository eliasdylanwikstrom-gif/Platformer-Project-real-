using UnityEngine;

public class EnemyMelee : MonoBehaviour

{
    public Factions targetFaction = Factions.Enemies;
    [SerializeField] int damage = 25;
    [SerializeField] float attackCooldown = 1.0f;
    float timer;
    Health targetHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health == null)
        {
            return;
        }
        targetHealth = health;
        DealDamage();
        timer = attackCooldown;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print("left trigger");
        Health health = collision.gameObject.GetComponent<Health>();
        if (health == targetHealth)
        {
            targetHealth = null;
        }
        

    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            DealDamage();
            timer = attackCooldown;
        }
    }
    private void DealDamage() 
    {
        if (targetHealth != null)
        {
            if (targetHealth.faction == targetFaction)
            {
                targetHealth.TakeDamage(damage);
            }
        }
    }
}
