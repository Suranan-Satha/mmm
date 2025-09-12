using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel; // Panel ที่มีข้อความ Game Over

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // ซ่อนตอนเริ่ม
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true); // โชว์ตอน Player ตาย
    }
}
