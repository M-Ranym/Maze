using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    public GameObject PanelO;
    public GameObject gameWiiiiiiiiii;
    public SoundManager soundManager;
    public DamageFlash damage;
    public Animator gameOverAnim;
    public Animator gameWin;

    public int score = 0;
    public int health = 5;

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            PanelO.SetActive(true);
            gameOverAnim.Play("oops");
            StartCoroutine(DelayPause());
            
            
            if (soundManager != null)
                soundManager.PlayGameOverSound();
        }else
        {
            damage.Flash();      
        }
        UpdateUI();
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    IEnumerator DelayPause()
    {
        yield return new WaitForSeconds(0.5f);
        PauseGame();
    }

    public void wii()
    {
        if (score >= 4)
        {
            gameWiiiiiiiiii.SetActive(true);
            gameWin.Play("wii");
            StartCoroutine(DelayPause());

            if (soundManager != null)
                soundManager.PlayWinSound();
        }
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        if (soundManager != null)
            soundManager.StopAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (healthText != null) healthText.text = "Health: " + health;
    }
}