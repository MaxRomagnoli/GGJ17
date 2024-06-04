using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguiOggetto : MonoBehaviour {

	public GameObject oggetto;
	public Vector3 distanza;
	public float tempo = 1f;

	private float distanzaX;
	private float distanzaY;
	private float distanzaZ;

	void FixedUpdate ()
	{
		distanzaX = oggetto.transform.position.x - distanza.x;
		distanzaX =	Mathf.Lerp ( this.transform.position.x, distanzaX, Time.deltaTime * tempo );
		distanzaY = oggetto.transform.position.y - distanza.y;
		distanzaY =	Mathf.Lerp ( this.transform.position.y, distanzaY, Time.deltaTime * tempo );
		distanzaZ = oggetto.transform.position.z - distanza.z;
		distanzaZ =	Mathf.Lerp ( this.transform.position.z, distanzaZ, Time.deltaTime * tempo );
		this.transform.position = new Vector3 (distanzaX, distanzaY, distanzaZ);
	}
}
