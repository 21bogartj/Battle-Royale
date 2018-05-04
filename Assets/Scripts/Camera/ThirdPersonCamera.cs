using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    [System.Serializable]
    public class CameraRig
    {
        public Vector3 CameraOffset;
        public float Damping; //control the moving speed of camera
        public float CroucingHeight;
    }

    
    // Use this for initialization
    public Player localPlayer;
    Transform cameraLookTarget;
	void Awake () {
		
		cameraLookTarget = localPlayer.transform.Find("cameraLookTarget");

		if (cameraLookTarget == null)
		{
			cameraLookTarget = localPlayer.transform;
		}
	}

    [SerializeField] CameraRig defaultCameraRig;
    [SerializeField] CameraRig aimingCameraRig;
   
    // Update is called once per frame
    void Update () {
        CameraRig cameraRig = defaultCameraRig;
        if (localPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.Aiming
            || localPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AimingAndFiring)
            cameraRig = aimingCameraRig;
        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraRig.CameraOffset.z +
                                                 localPlayer.transform.up * (cameraRig.CameraOffset.y +
                                                 (GameManager.Instance.LocalPlayer.PlayerState.MoveState == PlayerState.EMoveState.Crouching? cameraRig.CroucingHeight: 0)
                                                 ) +
                                                 localPlayer.transform.right * cameraRig.CameraOffset.x;
        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraRig.Damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, cameraRig.Damping * Time.deltaTime);

	}
}
