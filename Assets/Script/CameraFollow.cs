using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Vector3 offset;

    void LateUpdate()
    {
        transform.position = Player.position + offset;
        transform.LookAt(Player);
    }
}