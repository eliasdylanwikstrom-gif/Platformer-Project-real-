using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent<int> healthUpdated;
    public UnityEvent died;
    private AudioSource audioSource;

    /*[SerializeField]
    List<DamageTypes> resistances = new List<DamageTypes>();
    
    [SerializeField]
    List<DamageTypes> weaknesses = new List<DamageTypes>();*/

    [SerializeField] GameObject parent;
    [SerializeField] int maxHealth = 5;
    [SerializeField] SpriteRenderer spriteRenderer;


    private int _currentHealth;
    public Factions faction;

    public int CurrentHealth
    {
        set
        {
            if (_currentHealth != value)
            {
                healthUpdated.Invoke(value);
            }
            if (value > _currentHealth)
            {
                //Healing Animation Here
            }
            if (value < _currentHealth)
            {
                //Damage Animation Here
            }
            _currentHealth = value;
        }
        get
        {
            return _currentHealth;
        }
    }

    private void Start()
    {
        _currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
      
        CurrentHealth -= damage;
        StartCoroutine(BlinkRed());
        //audioSource.Play();
        //healthUpdated.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            died.Invoke();
            Destroy(parent);
        }

    }
    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    public void PlaySFX(AudioClip audioClip, float volume = 1f)
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}

/*public enum Factions
{
    Players,
    Enemies
}*/