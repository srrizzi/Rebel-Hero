using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private bool moveX;

    [SerializeField]
    private bool moveY;

    [SerializeField]
    private Vector2 offset;

    void LateUpdate()
    {
        Vector3 finalPosition = this.player.position + (Vector3)this.offset;
        finalPosition.z = this.transform.position.z;

        if (!this.moveX)
        {
            finalPosition.x = this.transform.position.x;
        }

        if (!moveY)
        {
            finalPosition.y = transform.position.y;
        }

        finalPosition = Vector3.Lerp(transform.position, finalPosition, moveSpeed * Time.deltaTime);

        transform.position = finalPosition;
    }
}
