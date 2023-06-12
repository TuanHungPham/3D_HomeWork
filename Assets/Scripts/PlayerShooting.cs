using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private const int LEFT_MOUSE_BUTTON = 0;
    private const int RIGHT_MOUSE_BUTTON = 1;
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
        Aim();
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
    }

    private void Aim()
    {
        if (!Input.GetMouseButton(RIGHT_MOUSE_BUTTON))
        {
            animator.SetBool("Aim", false);
            return;
        }

        animator.SetBool("Aim", true);
    }

    private bool CanShoot()
    {
        if (Input.GetMouseButton(LEFT_MOUSE_BUTTON)) return true;

        return false;
    }
}
