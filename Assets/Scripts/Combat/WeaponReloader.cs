using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloader : MonoBehaviour
{
    [SerializeField] int maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField] int clipSize;

    int shotsFiredInClip;
    int ammo = 40;
    bool isReloading;

    public int ShotsRemainingInClip
    {
        get
        {
            return clipSize - shotsFiredInClip;
        }
    }

    public bool IsReloading
    {
        get
        {
            return isReloading;
        }
    }

    public void Reload()
    {
        if (isReloading)
            return;
        print("Start Reloading");
        GameManager.Instance.Timer.add(ExecuteToReload, reloadTime);
        isReloading = true;
    }

    void ExecuteToReload()
    {
        isReloading = false;
        ammo -= shotsFiredInClip;
        shotsFiredInClip = 0;
        if (ammo < 0)
        {
            shotsFiredInClip += -ammo;
            ammo = 0;
        }
        print("Reloaded");
    }

    public void TakeFromClip(int amount)
    {
        shotsFiredInClip += amount;
    }
}
