using UnityEngine;
using System.Collections;

public class BackgroundAnimator : MonoBehaviour 
{
	public static BackgroundAnimator instance;
	public float drop_speed;

	public void Awake()
	{
		instance = this;
	}

	public void SetSpeed(float speed)
	{
		transform.eulerAngles += new Vector3 (0, Time.deltaTime * drop_speed * -speed, 0);
	}
		

}
