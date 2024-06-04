using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGioco : MonoBehaviour {

	public GameObject menuGameOver;
	public Text txtCausaDistruzione;
	public Text txtPunteggio;
	public Text txtOndeGenerate;

	public GameObject menuPausa;
	public Text txtPunteggio2;
	public Text txtOndeGenerate2;

	public GameObject menuGioco;

	public AudioClip suonoMenuPausa;
	public Image pulsanteMusica;
	public Sprite immagineMusicaOn;
	public Sprite immagineMusicaOff;

	private GeneraOnde sGeneraOnde;
	private AudioSource audioSBottle;
	private AudioSource audioS;
	static bool musicaOn = true;

	void Start ()
	{
		sGeneraOnde = this.GetComponent<GeneraOnde>();
		audioSBottle = GameObject.Find ( "Bottle" ).GetComponent<AudioSource> ();
		audioS = this.GetComponent<AudioSource> ();
		if ( musicaOn == false )
			SpengiMusica ();
	}

	public void GameOver(string causaMorte)
	{
		//Time.timeScale = 0;
		sGeneraOnde.enabled = false;
		txtCausaDistruzione.text = causaMorte;
		int punteggio = Mathf.RoundToInt ( sGeneraOnde.score );
		txtPunteggio.text = "Score: " + punteggio.ToString (); //(punteggioIniziale - (numeroOndeGenerate * malusOnda)).ToString();
		txtOndeGenerate.text = "Waves: " +  sGeneraOnde.numerOndeGenerate.ToString ();
		menuGioco.SetActive ( false );
		menuGameOver.SetActive ( true );
	}

	public void Pausa()
	{
		Time.timeScale = 0;
		sGeneraOnde.enabled = false;
		int punteggio = Mathf.RoundToInt ( sGeneraOnde.score );
		txtPunteggio2.text = "Score: " + punteggio.ToString (); //(punteggioIniziale - (numeroOndeGenerate * malusOnda)).ToString();
		txtOndeGenerate2.text = "Waves: " +  sGeneraOnde.numerOndeGenerate.ToString ();
		menuGioco.SetActive ( false );
		menuPausa.SetActive ( true );
		audioSBottle.clip = suonoMenuPausa;
		audioSBottle.Play ();
	}

	public void RiattivaGioco()
	{
		menuGioco.SetActive ( true );
		menuGameOver.SetActive ( false );
		menuPausa.SetActive ( false );
		sGeneraOnde.enabled = true;
		Time.timeScale = 1;
		audioSBottle.clip = suonoMenuPausa;
		audioSBottle.Play ();
	}

	public void MusicaOnOff()
	{
		musicaOn = !musicaOn;
		if(musicaOn)
		{
			pulsanteMusica.sprite = immagineMusicaOn;
			audioS.volume = 1f;
		}
		else
		{
			SpengiMusica ();
		}
	}

	void SpengiMusica()
	{
		pulsanteMusica.sprite = immagineMusicaOff;
		audioS.volume = 0f;
	}

	public void CaricaLivelo(string livello)
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(livello);
	}

}
