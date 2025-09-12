using UnityEngine;
using UnityEngine.UI;


public class PlayCollectibles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Text textComponent;
    public int gemNumber = 0;
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    private void UpdateText()
    {
        textComponent.text = gemNumber.ToString();
    }

    public void GemCollected()
    {
        gemNumber++;
        UpdateText();
    }
}
