using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public Slider slider;      
    public Text valueText;     
    private Coroutine smoothCoroutine;

    public void SetMaxHealth(float max)
    {
        if (slider != null)
        {
            slider.maxValue = max;
            slider.value = max;
        }
        UpdateText(max, max);
    }

    public void SetHealth(float current)
    {
        if (slider == null)
        {
            UpdateText(current, slider != null ? slider.maxValue : current);
            return;
        }

        if (smoothCoroutine != null) StopCoroutine(smoothCoroutine);
        smoothCoroutine = StartCoroutine(SmoothChange(slider.value, current, 0.25f));
    }

    private IEnumerator SmoothChange(float from, float to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            slider.value = Mathf.Lerp(from, to, t);
            UpdateText(slider.value, slider.maxValue);
            yield return null;
        }
        slider.value = to;
        UpdateText(to, slider.maxValue);
        smoothCoroutine = null;
    }

    private void UpdateText(float current, float max)
    {
        if (valueText != null)
        {
            valueText.text = Mathf.CeilToInt(current) + " / " + Mathf.CeilToInt(max);
        }
    }
}
