using UnityEngine;
using UnityEngine.InputSystem;

public class CatMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    private float tempSpeed;
    private InputAction action;
    private Vector2 moveVector;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isMovingRight = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        action = InputSystem.actions.FindAction("Move");
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        tempSpeed = speed;
    }

    void Update()
    {
        moveVector = action.ReadValue<Vector2>();
        moveVector.Normalize();
        rb.linearVelocity = new Vector2(moveVector.x * speed, moveVector.y * speed);
        if (moveVector == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

        if (moveVector.x > 0)
        {
            isMovingRight = true;
        }
        else if (moveVector.x < 0)
        {
            isMovingRight = false;
        }
        
        //objeyi döndür
        Vector3 newScale = transform.localScale;
        newScale.x = isMovingRight ? Mathf.Abs(newScale.x) : -Mathf.Abs(newScale.x);
        transform.localScale = newScale;
    }
    public void StopMovement()
    {
        speed = 0;
    }
    public void StartMovement()
    {
        speed = tempSpeed;
    }
}
