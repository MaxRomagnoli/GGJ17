using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onde : MonoBehaviour {

	public AnimationCurve animazioneOnda;
	public float grandezzaOndaMax = 10f;
	public float tempoAttesa = 0.1f;
	public GameObject oggettoDaRidimensionare;
	public float AbbassamentoY = 0.5f;
	public AudioClip[] suoniOnde;
	public ParticleSystem schiuma;

	//private Rigidbody rgdbdy;
	private SphereCollider colliderSfera;
	private MeshRenderer meshSfera;
	private AudioSource audioS;
	private GeneraOnde sGeneraOnde;
	private float grandezzaOndaTemp = 0f;
	//private bool CicloOnda = false;
	private float fTemp;
	private float daUnoAZero;

	void Start ()
	{
		//rgdbdy = this.GetComponent<Rigidbody> ();
		colliderSfera = this.GetComponent<SphereCollider> ();
		meshSfera = this.GetComponentInChildren<MeshRenderer> ();
		audioS = this.GetComponent<AudioSource> ();
		sGeneraOnde = GameObject.Find ( "Game Manager" ).GetComponent<GeneraOnde> ();
		//grandezzaOndaMax = sGeneraOnde.forza;
		//Debug.Log ( "forza: " + sGeneraOnde.forza );
	}

	public void GeneraOnda(float intensita) //richiamato da GeneraOnde.cs
	{
		grandezzaOndaMax = intensita;
		//CicloOnda = true;
		schiuma.startSpeed = intensita;
		schiuma.Emit ( 200 );
		if ( suoniOnde.Length > 0 )
		{
			audioS.clip = suoniOnde [Random.Range ( 0, suoniOnde.Length )];
			audioS.Play ();
		}
		else
			Debug.LogError ( "Non hai messo nessun suono nello script delle onde" );
		StartCoroutine ( IngigantisciOnda () );
	}

	IEnumerator IngigantisciOnda()
	{
		while(grandezzaOndaTemp < grandezzaOndaMax)
		{
			Debug.Log ( "onda" );
			grandezzaOndaTemp = grandezzaOndaTemp + tempoAttesa;
			fTemp = animazioneOnda.Evaluate ( grandezzaOndaTemp / grandezzaOndaMax ) * grandezzaOndaMax;
			daUnoAZero = 1f - (grandezzaOndaTemp / grandezzaOndaMax );
			if ( daUnoAZero < 0 )
				daUnoAZero = 0;
			colliderSfera.radius = fTemp;
			oggettoDaRidimensionare.transform.localScale = new Vector3 (fTemp * 2f, fTemp * 2f, fTemp * 2f); //1f su y precedentemente
			oggettoDaRidimensionare.transform.position = new Vector3(this.transform.position.x, daUnoAZero - AbbassamentoY, this.transform.position.z);
			meshSfera.material.color = new Color(meshSfera.material.color.r, meshSfera.material.color.g, meshSfera.material.color.b, daUnoAZero);
			//meshSfera.material.SetColor("Alabedo", new Color(meshSfera.material.color.r, meshSfera.material.color.g, meshSfera.material.color.b, fTemp));
			//ebug.Log("colore su alpha: " + daUnoAZero);
			//Debug.Log ( grandezzaOndaTemp + " - " + grandezzaOndaMax );
			yield return null;
			//if(grandezzaOndaTemp >= grandezzaOndaMax)
		}
		PreparaPerProssimaOnda ();
	}
	
	void PreparaPerProssimaOnda()
	{
		StopCoroutine ( IngigantisciOnda () ); //davvero necessario?
		//CicloOnda = false;
		colliderSfera.radius = 0f;
		oggettoDaRidimensionare.transform.localScale = new Vector3 (0f, 0f, 0f);
		grandezzaOndaTemp = 0f;
		sGeneraOnde.SettaProssimaOnda ();
		//Destroy ( this.gameObject );
	}
}
