using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] float rateOfFire;
    [SerializeField] Projectile projectile;
    float nextFireAllowed;
    WeaponReloader reloader;

    [HideInInspector]
    public Transform muzzle;

    public bool canFire; //check player for fire. if nextFireAllowed based on rate of fire, return a boolean called this
    private void Awake()
    {
        muzzle = transform.Find("Muzzle");
        reloader = GetComponent<WeaponReloader>();
    }

    public void Reload()
    {
        if (reloader == null)
            return;
        reloader.Reload();
    }

    //virtual mean we can override it in the whole project
    public virtual void Fire() {
        canFire = false;
        if (Time.time < nextFireAllowed)
            return;
        if (reloader) //if the weapon doesn't have reloader don't check
        {
            if (reloader.IsReloading)
                return;
            if (reloader.ShotsRemainingInClip == 0)
                return;
            reloader.TakeFromClip(1);
        }
        // create bullet
        Instantiate(projectile, muzzle.position, muzzle.rotation);
        nextFireAllowed = Time.time + rateOfFire;
        canFire = true;
    }
}
