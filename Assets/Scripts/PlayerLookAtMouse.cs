using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    #region public
    #endregion

    #region private
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform playerHead;
    [SerializeField] private Transform fakeGun;
    private float mouseX;
    private float mouseY;
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
        playerHead = transform.Find("Sphere");
        fakeGun = transform.Find("FakeGun");

        TurnOffCursor();
    }

    private void Update()
    {
        GetMouseDirection();
        LookByMouse();
    }

    private void GetMouseDirection()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    private void LookByMouse()
    {
        float rotationY = transform.eulerAngles.y;
        float rotationX = playerHead.eulerAngles.x;

        rotationX += -mouseY * rotationSpeed;
        rotationY += mouseX * rotationSpeed;

        LookVertical(rotationX);
        LookHorizontal(rotationY);
    }

    private void LookVertical(float rotation)
    {
        playerHead.eulerAngles = new Vector3(rotation, transform.eulerAngles.y, 0);

        SetGunDirection(playerHead.eulerAngles);
    }

    private void LookHorizontal(float rotation)
    {
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }

    private static void TurnOffCursor()
    {
        Cursor.visible = false;
    }

    private void SetGunDirection(Vector3 rotation)
    {
        fakeGun.eulerAngles = new Vector3(rotation.x + 90, rotation.y, 0);
    }
}
