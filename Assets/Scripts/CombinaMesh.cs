using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
//[RequireComponent(typeof(MeshCollider))]
public class CombinaMesh : MonoBehaviour {

	public Mesh tempMesh;

	void Start()
	{
		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
		CombineInstance[] combine = new CombineInstance[meshFilters.Length];
		int i = 0;
		while (i < meshFilters.Length)
		{
			combine[i].mesh = meshFilters[i].sharedMesh;
			combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
			meshFilters[i].gameObject.SetActive( false );
			i++;
		}
		Debug.Log ( "Numero di roccie: " + i );
		transform.GetComponent<MeshFilter>().mesh = new Mesh();
		transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
		//tempMesh = (Mesh)UnityEngine.Object.Instantiate ( transform.GetComponent<MeshFilter>().mesh );
		tempMesh = transform.GetComponent<MeshFilter>().mesh;
		//transform.GetComponent<MeshCollider> ().mesh = new Mesh ();
		//transform.GetComponent<MeshCollider>().
		transform.gameObject.SetActive( true );
	}
}

