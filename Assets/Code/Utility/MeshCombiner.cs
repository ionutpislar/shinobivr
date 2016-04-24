using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshCombiner : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		Combine ();
	}

	public void Combine()
	{
		GetGameObjectsRecursive (this.gameObject);
			
		StaticBatchingUtility.Combine (objects.ToArray (), this.gameObject);

		objects.Clear ();
	}

	private List<GameObject> objects = new List<GameObject> ();
	public void GetGameObjectsRecursive(GameObject temp)
	{
		foreach (Transform t in temp.transform) 
		{
			if (t.gameObject.GetComponent<MeshRenderer> () != null) {
				objects.Add (t.gameObject);
				GetGameObjectsRecursive (t.gameObject);
			}
		}
	}
}
