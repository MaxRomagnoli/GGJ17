using System.Collections;
using UnityEngine;

public class Floater : MonoBehaviour {
	
	public float waterLevel, floatHeight;
	public Vector3 buoyancyCentreOffset;
	public float bounceDamp;

	private Rigidbody rgdbdy;
	
	void Start()
	{
		rgdbdy = this.GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		Vector3 actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
		float forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);
		
		if (forceFactor > 0f && rgdbdy != null)
		{
			Vector3 uplift = -Physics.gravity * (forceFactor - rgdbdy.velocity.y * bounceDamp);
			rgdbdy.AddForceAtPosition(uplift, actionPoint);
			Debug.Log ( "galleggiamento" );
		}
	}
}
