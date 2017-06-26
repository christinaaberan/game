using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3(0,15,-35);
	public float xTilt = 20;

	Vector3 destination = Vector3.zero;
	CharacterController charController;
	float rotateVel = 0;

	void Start()
	{
		SetCameraTarget (target);
	}

	void SetCameraTarget(Transform t)
	{
		target = t;

		if (target != null) {
			if (target.GetComponent<CharacterController> ()) {
				charController = target.GetComponent<CharacterController> ();
			} else
				Debug.LogError ("The camera's target needs a character controller");
		} else
			Debug.LogError ("Your camera needs a target");
	}

	void LateUpdate()
	{
		MoveToTarget ();
		LookAtTarget ();
	}

	void MoveToTarget()
	{
		destination = charController.TargetRotation * offsetFromTarget;
		destination += target.position;
		transform.position = destination;

	}

	void LookAtTarget()
	{
		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
		transform.rotation = Quaternion.Euler (xTilt, eulerYAngle, 0);
	}
}
