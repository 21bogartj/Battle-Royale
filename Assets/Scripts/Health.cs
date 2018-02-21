using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructible {

    public override void die()
    {
        base.die();
        print("die");
    }

    public override void takeDamage(float damageAmount)
    {
        base.takeDamage(damageAmount);
        print("ramaining damage = " + hitPointsRemaining);
    }
}
