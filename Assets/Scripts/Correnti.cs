using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correnti : MonoBehaviour {

	public GameObject bottiglia;
	public float velocitaMaxCorrente = 0.3f;
	public float tempoCabioDirezione = 10f;
	public float angoloMaxBottiglia = 0.01f;

	private Vector3 corrente;
	private Floater sFloaterBottiglia;
	private Rigidbody rigidBottiglia;
	private Vector3 angoloBottiglia;
	private float[] arrayCorrenti;

	void Start ()
	{
		sFloaterBottiglia = bottiglia.GetComponent<Floater> ();
		rigidBottiglia = bottiglia.GetComponent<Rigidbody> ();

		arrayCorrenti = new float[4];
		for (int i = 0; i < 4; i++)
			arrayCorrenti [i] = Random.Range ( -velocitaMaxCorrente, velocitaMaxCorrente );

		StartCoroutine ( CambioDirezione () );
		StartCoroutine ( SpostaBottiglia () );
	}

	IEnumerator CambioDirezione()
	{
		bool via = true;
		int i = 0;
		while (via)
		{
			float correnteX = arrayCorrenti[i];
			float correnteZ = arrayCorrenti[i + 1];
			corrente = new Vector3 (correnteX, 0f, correnteZ);

			if ( correnteX >= 0 && correnteZ >= 0)
				angoloBottiglia = new Vector3 (angoloMaxBottiglia, 0f, angoloMaxBottiglia);
			else if ( correnteX < 0 && correnteZ >= 0)
				angoloBottiglia = new Vector3 (-angoloMaxBottiglia, 0f, angoloMaxBottiglia);
			else if ( correnteX >= 0 && correnteZ < 0)
				angoloBottiglia = new Vector3 (angoloMaxBottiglia, 0f, -angoloMaxBottiglia);
			else if ( correnteX < 0 && correnteZ < 0)
				angoloBottiglia = new Vector3 (-angoloMaxBottiglia, 0f, -angoloMaxBottiglia);

			sFloaterBottiglia.buoyancyCentreOffset = angoloBottiglia;

			i++;
			if ( i >= 3 )
				i = 0;

			yield return new WaitForSeconds (tempoCabioDirezione);
		}
	}

	IEnumerator SpostaBottiglia ()
	{
		bool via = true;
		while (via)
		{
			if ( rigidBottiglia != null )
				rigidBottiglia.AddRelativeForce ( corrente );
			yield return new WaitForSeconds (1);
		}
	}
}
