using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisattivaSeNonVisto : MonoBehaviour {

	private BoxCollider box;
	private SphereCollider sfera;
	//private MeshRenderer meshR;

	void Start()
	{
		//meshR = this.GetComponent<MeshRenderer> ();
		box = this.GetComponent<BoxCollider> ();
		if ( box == null )
			sfera = this.GetComponent<SphereCollider> ();
	}

	void OnBecameInvisible ()
	{
		//meshR.enabled = false;
		if(box != null)
			box.enabled = false;
		else if (sfera != null)
			sfera.enabled = false;
	}

	void OnBecameVisible ()
	{
		//meshR.enabled = true;
		if(box != null)
			box.enabled = true;
		else if (sfera != null)
			sfera.enabled = true;
	}

	void Update()
	{
		Vector3 position = Camera.main.WorldToViewportPoint ( transform.position );
		if ( position.x < -1f || position.x > 1f || position.y < -1f || position.y > 1f )
			OnBecameInvisible ();
		else
			OnBecameVisible ();
	}
		
}
