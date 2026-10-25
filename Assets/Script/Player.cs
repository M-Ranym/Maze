using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private float moveX;
    private float moveY;
    private Rigidbody PlayerRb;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private bool isOnGround = true;

    public Joystick joystick;

    public SoundManager soundManager;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // moveX = Input.GetAxis("Horizontal");
        // moveY = Input.GetAxis("Vertical");

        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        Vector3 movement = new Vector3(moveX, 0, moveY);
        PlayerRb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            if (soundManager != null)
                soundManager.PlayJumpSound();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
    }
}