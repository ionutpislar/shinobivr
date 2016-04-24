using UnityEngine;
using System.Collections;

public class CharacterControllerMain : MonoBehaviour 
{

	private Animator anim;
	public float jump_power;
	private Vector3 mm_initial;

	public void Awake()
	{
		mm_initial = transform.position;
	}

	// Use this for initialization
	void Start () 
	{
		anim = gameObject.GetComponent<Animator> ();
		OnHit ();
	}

	void Update () 
	{
		float speed = Input.GetAxis ("Horizontal");
		BackgroundAnimator.instance.SetSpeed (speed);
		anim.SetFloat ("speed", speed);

		AnimatorClipInfo[] anim_state = anim.GetCurrentAnimatorClipInfo (0);

		if (Input.GetMouseButtonDown(0)) 
		{
			Debug.Log (anim_state [0].clip.name);
			if (anim_state [0].clip.name != "knowdown")
			{
				ShootProjectile ();
			}

		}

		Vector3 temp1 = anim.deltaPosition;

		temp1.y += -3.6f * Time.deltaTime;

		if (Input.GetButton ("Jump") && GetComponent<CharacterController>().isGrounded) 
		{
			anim.SetBool ("jump", true);
			StartCoroutine(DoJump());
		}

		GetComponent<CharacterController>().Move(temp1);					
		transform.rotation = anim.rootRotation;
	
		Vector3 temp = transform.position;
		temp.z = mm_initial.z;

		transform.position = temp;
	}

	private IEnumerator DoJump()
	{
		yield return new WaitForSeconds (0.1f);

		anim.SetBool ("jump", true);
	}


	public void ShootProjectile()
	{
		StartCoroutine(RunShootProjecileAnim ());
	}

	public void OnHit()
	{
		StartCoroutine (RunHitAnim ());
	}



	private IEnumerator RunShootProjecileAnim()
	{
		if (anim.GetBool ("shoot") == false) {
			anim.SetBool ("shoot", true);
			yield return new WaitForSeconds (0.1f);
			anim.SetBool ("shoot", false);
		}

		yield return null;
	}

	private IEnumerator RunHitAnim()
	{
		if (anim.GetBool ("hit") == false) {
			anim.SetBool ("hit", true);
			yield return new WaitForSeconds (0.1f);
			anim.SetBool ("hit", false);
		}

		yield return null;
	}
}
