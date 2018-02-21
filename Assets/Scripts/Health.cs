using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructible {

    [SerializeField] private float timeToRespawn;

    public override void die()
    {
        base.die();
        GameManager.Instance.Respawner.Respawn(gameObject, timeToRespawn);
    }

    void OnEnable()
    {
        reset();
    }

    public override void takeDamage(float damageAmount)
    {
        base.takeDamage(damageAmount);
        print("ramaining damage = " + hitPointsRemaining);
    }
}
