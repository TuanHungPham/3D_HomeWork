using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region public
    #endregion

    #region private
    [SerializeField] private float moveSpeed;

    [Space(20)]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 movingDirection;
    private float directionX;
    private float directionY;
    #endregion

    private void Awake()
    {
        LoadComponents();
    }

    private void Reset()
    {
        LoadComponents();
    }

    private void LoadComponents()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetMovingDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetMovingDirection()
    {
        directionX = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");

        movingDirection = transform.forward * directionY + transform.right * directionX;
        movingDirection.Normalize();
    }

    private void Move()
    {
        if (directionX == 0 && directionY == 0)
        {
            animator.SetBool("Run", false);
            return;
        }

        rb.MovePosition(transform.position + movingDirection * moveSpeed * Time.fixedDeltaTime);
        animator.SetBool("Run", true);
    }
}
