using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator animator;
	private PlayerAim playerAim {
		get {
			return GameManager.Instance.LocalPlayer.playerAim;
		}
	}

	void Awake () {
        animator = GetComponentInChildren<Animator>();
	}
	
	void Update () {
        animator.SetFloat("Vertical", GameManager.Instance.InputController.Vertical);
        animator.SetFloat("Horizontal", GameManager.Instance.InputController.Horizontal);
        animator.SetBool("isRunning", GameManager.Instance.InputController.Run);
        animator.SetBool("isCrouched", GameManager.Instance.InputController.Crouch);
		animator.SetFloat ("AimAngle", playerAim.GetAngle ());
    }
}
