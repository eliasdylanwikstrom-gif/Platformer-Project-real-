using UnityEngine;
using UnityEngine.Events;
public class Coin : MonoBehaviour
{
    [SerializeField] int coinValue = 1;
    [SerializeField] AudioClip overrideCoinClip = null;
    private object player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerInventory playerInv = collision.gameObject.GetComponent<PlayerInventory>();
            playerInv.CollectCoin(coinValue, overrideCoinClip);
            //player.coins += 1;
            //player.PlaySFX(coinClip, 0.4f);
            Destroy(gameObject);
        }
    }

}