using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource musicSource;

    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip damageSound;
    public AudioClip gameOverSound;
    public AudioClip winSound;
    public AudioClip startGameSound;
    public AudioClip backgroundMusic;

    void Awake()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.playOnAwake = false;
            musicSource.loop = true;
        }
    }

    void Start()
    {
        PlayOneShot(startGameSound);
        PlayBackgroundMusic();
    }

    public void PlayCoinSound() { PlayOneShot(coinSound); }
    public void PlayJumpSound() { PlayOneShot(jumpSound); }
    public void PlayDamageSound() { PlayOneShot(damageSound); }

    public void PlayGameOverSound()
    {
        PlayOneShot(gameOverSound);
        if (musicSource != null) musicSource.Stop();
    }

    public void PlayWinSound()
    {
        PlayOneShot(winSound);
        if (musicSource != null) musicSource.Stop();
    }

    public void PlayBackgroundMusic()
    {
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            if (!musicSource.isPlaying)
                musicSource.Play();
        }
    }

    private void PlayOneShot(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }

    public void StopAll()
    {
        if (audioSource != null) audioSource.Stop();
        if (musicSource != null) musicSource.Stop();
    }
}