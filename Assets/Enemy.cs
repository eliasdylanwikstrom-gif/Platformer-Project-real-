using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10.0f;
    [SerializeField] Transform flip;
    [SerializeField] Transform edgeDetect;
    [SerializeField] bool isGrounded = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(edgeDetect.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));
        isGrounded = rb.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (hit.collider == null && isGrounded)
        {
            Flip();
        }
        Vector2 scaledRight = Vector2.right * flip.localScale.x;
        rb.linearVelocityX = scaledRight.x * movementSpeed;
    }
    public void Flip()
    {
        Vector3 newFlipScale = flip.localScale;
        newFlipScale.x *= -1.0f;
        flip.localScale = newFlipScale;
    }

}