using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SempreSullaBase : MonoBehaviour {

	public GameObject oggettoDaSeguire;

	void FixedUpdate ()
	{
		this.transform.position = new Vector3 (oggettoDaSeguire.transform.position.x, 0f, oggettoDaSeguire.transform.position.z);
	}
}
