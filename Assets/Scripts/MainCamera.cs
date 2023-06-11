using UnityEngine;

public class MainCamera : MonoBehaviour
{
    #region public
    #endregion

    #region private
    [SerializeField] private Transform playerHead;
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
        Transform player = GameObject.Find("MainCharacter").transform;
        playerHead = player.Find("Sphere");
    }

    private void LateUpdate()
    {
        FollowPlayer();
        SetPlayerPOV();
    }

    private void FollowPlayer()
    {
        transform.position = playerHead.transform.position;
    }

    private void SetPlayerPOV()
    {
        transform.rotation = playerHead.transform.rotation;
    }
}
