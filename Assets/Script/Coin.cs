using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float floatSpeed = 2f;
    public float floatHeight = 0.5f;

    public GameManager gameManager;
    public SoundManager soundManager;
    public GameObject coinEffectPrefab;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(1);
            if (soundManager != null)
                soundManager.PlayCoinSound();
                Instantiate(coinEffectPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}