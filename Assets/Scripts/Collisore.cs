using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisore : MonoBehaviour {

	public GameObject bottigliaRotta;
	public AudioClip suonoBottigliaRotta;
	//[HideInInspector] public enum causaMorte { Crashed, Vortex };

	private ParticleSystem effettoBottigliaRotta;
	private MeshRenderer oggettoMesh;
	private AudioSource audioS;
	private MenuGioco menu;

	void Start ()
	{
		effettoBottigliaRotta = this.GetComponent<ParticleSystem> ();
		oggettoMesh = this.GetComponentInChildren<MeshRenderer> ();
		audioS = this.GetComponent<AudioSource> ();
		menu = GameObject.Find ( "Game Manager" ).GetComponent<MenuGioco>();
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ( "entrato" );
		if ( other.tag == "Scoglio" ) //funziona, devi solo aggiungere un trigger in gioco taggato Scoglio
		{
			Debug.Log ( "infranto su scoglio" );
			StartCoroutine( BottigliaDistrutta ("Crashed") );
		}
		if ( other.tag == "Vortice" ) //funziona, devi solo aggiungere un trigger in gioco taggato Scoglio
		{
			Debug.Log ( "risucchiato" );
			StartCoroutine( BottigliaDistrutta ("Sinked") );
		}
		if ( other.tag == "Squalo" ) //funziona, devi solo aggiungere un trigger in gioco taggato Scoglio
		{
			Debug.Log ( "risucchiato" );
			StartCoroutine( BottigliaDistrutta ("Bitten") );
		}
		if ( other.tag == "Spiaggia" ) //funziona, devi solo aggiungere un trigger in gioco taggato Scoglio
		{
			Debug.Log ( "spiaggiata" );
			StartCoroutine( BottigliaDistrutta ("Strandead") );
		}
		if ( other.tag == "Spiaggia2" ) //funziona, devi solo aggiungere un trigger in gioco taggato Scoglio
		{
			Debug.Log ( "vittoria" );
			menu.CaricaLivelo ( "Cut Scene" );
		}
		if ( other.tag == "Area" ) //funziona, devi solo aggiungere un trigger in gioco taggato Scoglio
		{
			Debug.Log ( "riposizionato" );
			this.transform.position = new Vector3 (0f, 2.7f, 0f);
		}
	}

	IEnumerator BottigliaDistrutta(string causaMorte)
	{
		Debug.Log ( "distrutto" );
		audioS.clip = suonoBottigliaRotta;
		audioS.Play ();
		//AudioSource.PlayClipAtPoint ( suonoBottigliaRotta, this.transform.position );
		Destroy ( oggettoMesh );
		Destroy ( this.GetComponent<Rigidbody> () );
		bottigliaRotta.transform.position = this.transform.position;
		bottigliaRotta.transform.rotation = this.transform.rotation;
		bottigliaRotta.SetActive ( true );
		effettoBottigliaRotta.Emit ( 30 );
		yield return new WaitForSeconds (1);
		menu.GameOver(causaMorte);
	}
}
