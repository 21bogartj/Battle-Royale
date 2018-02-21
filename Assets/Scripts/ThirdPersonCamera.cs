using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float damping; //control the moving speed of camera
    
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

   
    // Update is called once per frame
    void Update () {
        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraOffset.z +
                                                 localPlayer.transform.up * cameraOffset.y +
                                                 localPlayer.transform.right * cameraOffset.x;
        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);

	}
}
