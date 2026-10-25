using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    public Image flashImage;
    public float flashSpeed = 5f;
    private float targetAlpha = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        Color c = flashImage.color;
        c.a = Mathf.Lerp(c.a, targetAlpha, Time.deltaTime * flashSpeed);
        flashImage.color = c;
        
    }

    // Update is called once per frame
    public void Flash()
    {
        flashImage.color = new Color(flashImage.color.r, flashImage.color.g, flashImage.color.b , 0.6f);
        targetAlpha = 0f;
        
    }
}
