using UnityEngine;
using UnityEngine.UI;
public class HealthLabel : MonoBehaviour
{
    public Image healthImage;
    public void SetHealth(int health) 
    {
        healthImage.fillAmount = health / 100f;
    }
}
