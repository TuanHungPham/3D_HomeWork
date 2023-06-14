using UnityEngine;
using TigerForge;

public class PlayerShooting : MonoBehaviour
{
    private const int LEFT_MOUSE_BUTTON = 0;
    private Animator animator;

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
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (!CanShoot())
        {
            animator.SetBool("Fire", false);
            return;
        }

        animator.SetBool("Fire", true);
        EventManager.EmitEvent("PlayerShooting");
    }

    private bool CanShoot()
    {
        if (Input.GetMouseButton(LEFT_MOUSE_BUTTON)) return true;

        return false;
    }
}
