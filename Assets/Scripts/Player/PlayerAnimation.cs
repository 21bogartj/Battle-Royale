using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator animator;

	void Awake () {
        animator = GetComponentInChildren<Animator>();
	}
	
	void Update () {
        animator.SetFloat("Vertical", GameManager.Instance.InputController.Vertical);
        animator.SetFloat("Horizontal", GameManager.Instance.InputController.Horizontal);
        animator.SetBool("isRunning", GameManager.Instance.InputController.Run);
    }
}
