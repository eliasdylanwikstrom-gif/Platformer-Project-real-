using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpforce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private int extraJumps;
    private bool isGrounded;
    public int extraJumpsValue = 1;
    public AudioClip hurtClip;
    private AudioSource audioSource;
    [SerializeField] Animator animator;
    public AudioClip jumpClip;

    [SerializeField] float clampVel = 30.0f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform flip;
    public LayerMask groundLayer;

    Vector2 inputDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        extraJumps = extraJumpsValue;
    }
    void Update()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }
        float moveInput = inputDir.x;
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, clampVel);
        SetAnimation();
    }
    public void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            PlaySFX(jumpClip);
        }
        else if (extraJumps > 0)
        {
            rb.linearVelocityY = 0.0f;
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            extraJumps--;
            PlaySFX(jumpClip);
        }
    }
    public void OnMove(InputValue value)
    {
        inputDir = value.Get<Vector2>();
        float moveInput = inputDir.x;
        if (moveInput != 0f)
        {
            flip.localScale = new Vector3(moveInput, 1f, 1f);
        }
    }
    public void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void SetAnimation()
    {
        string animName = "Player_";
        bool isIdle = (inputDir.x == 0);
        bool hasVelocityUp = rb.linearVelocityY > 0;
        string groundedAnimEnd = isIdle ? "Idle" : "Run";// bool ? trueValue : falseValue;
        string airborneAnimEnd = hasVelocityUp ? "Jump" : "Fall";

        string animEnd = isGrounded ? groundedAnimEnd : airborneAnimEnd;
        animName += animEnd;


        animator.Play(animName);
    }
    public void PlaySFX(AudioClip audioClip, float volume = 1f)
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}