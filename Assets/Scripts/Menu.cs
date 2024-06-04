using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	private Text txtEgg;
	int egg = 0;

	void Start()
	{
		Time.timeScale = 1;
		txtEgg = GameObject.Find ( "Canvas/Titolo" ).GetComponent<Text>();
	}

	public void CaricaLivelo(string livello)
	{
		SceneManager.LoadScene(livello);
	}

	public void Egg()
	{
		egg++;
		if ( egg >= 20 )
			txtEgg.text = "Tua Nonna" ;

	}
}
