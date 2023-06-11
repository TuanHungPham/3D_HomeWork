using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region public
    #endregion

    #region private
    [SerializeField] private float moveSpeed;

    [Space(20)]
    [SerializeField] private Transform playerHead;
    [SerializeField] private Rigidbody rb;
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

        playerHead = transform.Find("Sphere");
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

        movingDirection = playerHead.transform.forward * directionY + playerHead.transform.right * directionX;
        movingDirection.Normalize();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + movingDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
