using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] float rateOfFire;
    [SerializeField] Projectile projectile;
    float nextFireAllowed;

    [HideInInspector]
    public Transform muzzle;

    public bool canFire; //check player for fire. if nextFireAllowed based on rate of fire, return a boolean called this
    private void Awake()
    {
        muzzle = transform.Find("Muzzle");
    }

    //virtual mean we can override it in the whole project
    public virtual void Fire() {
        canFire = false;
        if (Time.time < nextFireAllowed)
            return;
        // create bullet
        Instantiate(projectile, muzzle.position, muzzle.rotation);
        nextFireAllowed = Time.time + rateOfFire;
        canFire = true;
    }
}
