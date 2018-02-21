using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float timeToLive;
    [SerializeField] float damage;

    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        var destructible = other.transform.GetComponent<Destructible>();
        if (destructible == null)
            return;
        destructible.takeDamage(damage);
    }
}