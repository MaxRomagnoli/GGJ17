using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneraOnde : MonoBehaviour {

	public GameObject onda;
	public float forzaMax = 10f;
	public float cumulatoreForza = 0.1f;
	public Slider sliderForza;

	private Onde sOnda;
	private bool prossimaOnda = true;
	[HideInInspector] public float forza;

	// per lo score //
	[HideInInspector] public int numerOndeGenerate = 0;
	public float score = 1000; //punteggio iniziale
	public int malusOnda = 1; //moltiplicatore malus onda

	void Start()
	{
		sOnda = onda.GetComponent<Onde> ();
		sliderForza.maxValue = forzaMax;
	}

	void Update ()
	{
		if ( Input.GetKey ( KeyCode.Mouse0 ))
		{
			Debug.Log ( "Tasto Premuto" );
			forza = forza + cumulatoreForza;
			if ( forza > forzaMax )
				forza = forzaMax;
			sliderForza.value = forza;
		}
		if ( Input.GetKeyUp ( KeyCode.Mouse0 ) && forza > 0 )
		{
			Debug.Log ( "Tasto Alto" );
			if ( prossimaOnda == true )
			{
				prossimaOnda = false;
				sliderForza.value = 0f;
				Genera ();
				Debug.Log ( "Genera Onda" );
			}
		}
	}

	public void SettaProssimaOnda() //funzione chiamata anche da ogni onda con "Onde"
	{
		//forza = 0;
		prossimaOnda = true;
	}

	void Genera()
	{
		RaycastHit tuaNonna;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out tuaNonna, 100f)) //, LayerMask.GetMask("acqua")
		{
			if ( tuaNonna.transform.gameObject.tag == "acqua" )
			{
				numerOndeGenerate++;
				score = score - (forza * malusOnda);
				onda.transform.position = new Vector3 (tuaNonna.point.x, 0f, tuaNonna.point.z);
				sOnda.GeneraOnda (forza);
				forza = 0;
				//Instantiate ( onda, tuaNonna.point, Quaternion.identity );
			}
			else
				SettaProssimaOnda ();
		}
	}
}
