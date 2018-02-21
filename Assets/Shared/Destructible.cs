using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] float hitPoints;
    float damageTaken;

    public event System.Action OnDeath;
    public event System.Action OnDamageReceived;

    public float hitPointsRemaining
    {
        get
        {
            return hitPoints - damageTaken;
        }
    }

    public bool isAlive
    {
        get
        {
            return hitPointsRemaining > 0;
        }
    }

    public virtual void die()
    {
        if (!isAlive)
            return;
        if (OnDeath != null)
            OnDeath();
    }

    public virtual void takeDamage(float damageAmount)
    {
        damageTaken += damageAmount;
        if (OnDamageReceived != null)
            OnDamageReceived();
        if (hitPointsRemaining <= 0)
            die();
    }

    public void reset()
    {
        damageTaken = 0;
    }
}
