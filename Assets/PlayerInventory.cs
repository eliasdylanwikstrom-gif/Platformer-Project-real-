using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PlayerInventory : MonoBehaviour
{
    public int coins;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinClip;
    public UnityEvent<int> scoreUpdated;


    public void CollectCoin(int amount, AudioClip overrideClip = null) 
    {   
        AudioClip clip = coinClip;
        if (overrideClip != null)
        {
            clip = overrideClip;    
        }
        coins += amount;
        audioSource.clip = clip;
        audioSource.volume = 0.4f;
        audioSource.Play();
    }
    private int currentCoins;
    public int CurrentCoins
    {
        set
        {
            if (currentCoins != value)
            {
                scoreUpdated.Invoke(value);
            }
        }
        get
        {
            return currentCoins;
        }
    }
}
