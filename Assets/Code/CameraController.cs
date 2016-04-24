using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour 
{
	public Transform target;
	public float smoothTime = 0.3F;
	public Vector3 offset;
	public Vector3 target_offset;

	private Vector3 velocity = Vector3.zero;


	void FixedUpdate()
	{
		//Vector3 targetPosition = target.TransformPoint(offset);
		//transform.position = Vector3.SmoothDamp(transform.position, target_offset+targetPosition, ref velocity, smoothTime);
		transform.position = target.position + target_offset;

	//	transform.LookAt (target.position +offset);
	}
}