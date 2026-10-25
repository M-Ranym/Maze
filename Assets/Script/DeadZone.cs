using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameManager gameManager;
    public SoundManager soundManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.TakeDamage(1);
            if (soundManager != null)
                soundManager.PlayDamageSound();
        }
    }
}