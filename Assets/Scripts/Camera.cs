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

    void Update()
    {
        Vector3 finalPosition = this.player.position + (Vector3)this.offset;
        finalPosition.z = this.transform.position.z;

        if (!this.moveX)
        {
            finalPosition.x = this.transform.position.x;
        }

        if (!this.moveY)
        {
            finalPosition.y = this.transform.position.y;
        }

        finalPosition = Vector3.Lerp(this.transform.position, finalPosition, this.moveSpeed * Time.deltaTime);

        this.transform.position = finalPosition;
    }
}
