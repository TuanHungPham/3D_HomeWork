using UnityEngine;
using TMPro;
using TigerForge;

public class AmmoUI : MonoBehaviour
{
    private TMP_Text ammoUI;
    private RocketLauncher rocketLauncher;

    private void Awake()
    {
        ammoUI = GetComponent<TMP_Text>();
        rocketLauncher = GameObject.Find("Rocket Launcher").GetComponent<RocketLauncher>();
    }

    private void Start()
    {
        ShowAmmo();
        EventManager.StartListening("PlayerShooting", ShowAmmo);
    }

    private void ShowAmmo()
    {
        ammoUI.text = rocketLauncher.ammo.ToString();
    }
}
