using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruota : MonoBehaviour {

	public Vector3 rotazione;

	void Update ()
	{
		this.gameObject.transform.Rotate ( rotazione );
	}
}
