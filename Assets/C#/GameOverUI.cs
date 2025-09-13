using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel; 

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); 
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true); 
    }
}
