using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortice : MonoBehaviour {

	public GameObject vortice;
	public float distanzaAttivazione = 3f;
	public float riduttoreForzaVortice = 5f;
	private GameObject bottiglia;
	private Rigidbody rigidBottiglia;
	//private float divisoreMagnitude;

	void Start ()
	{
		bottiglia = GameObject.Find ( "Bottle" );
		rigidBottiglia = bottiglia.GetComponent<Rigidbody> ();
		//divisoreMagnitude = this.GetComponent<SphereCollider> ().radius;
	}

	void Update ()
	{
		Vector3 direzioneForza = new Vector3(vortice.transform.position.x - bottiglia.transform.position.x,  0f, vortice.transform.position.z - bottiglia.transform.position.z);
		if ( direzioneForza.magnitude < distanzaAttivazione && rigidBottiglia != null)
		{
			rigidBottiglia.AddForce(direzioneForza / riduttoreForzaVortice, ForceMode.Acceleration);
		}
	}
}
