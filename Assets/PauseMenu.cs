using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenue : MonoBehaviour
{
    public GameObject container;

    public void ResumeButton() 
    {
        container.SetActive(true);
        Time.timeScale = 1;
    }
    public void MainMenuButton() 
    {
        SceneManager.LoadScene("");
    }
    public void OnMenu() 
    {
        container.SetActive(true);
        Time.timeScale = 0;
    }
}
