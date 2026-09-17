using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletPoint;
    public void OnAttack() 
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.position, Quaternion.Euler(0f, 0f, 0f));

        Vector3 scale = bullet.transform.localScale;
        scale.x *= Mathf.Sign(transform.lossyScale.x); // -1 eller 1

        bullet.transform.localScale = scale;
    }
}
