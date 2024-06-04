using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    public string nextScene = "Livello";
	public Image immagineScena;
	public Sprite[] immagini;
	//public bool caricaInBackground = false;
	//AsyncOperation variabile;

	void Start()
	{
		//if ( caricaInBackground )
			//CaricaInBackground ();
		if ( immagini.Length > 0 )
			StartCoroutine ( cambiaImmagini () );
	}
	
	IEnumerator cambiaImmagini()
	{
		//bool via = true;
		int i = 0;
		while (i <= immagini.Length) //sempre vero, quindi lo fa all'infinito
		{
			yield return new WaitForSeconds (3);
			i++;
			if ( i == immagini.Length )
				CaricaLivello ();
			else
				immagineScena.sprite = immagini [i];
		}
	}

	/*void CaricaInBackground()
	{
		//SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.
		variabile.allowSceneActivation = false;
		variabile = SceneManager.LoadSceneAsync(nextScene);
	}*/

	public void CaricaLivello() //richama alla fine dell'animazione nella scena Intro
    {
		//if(caricaInBackground)
			//variabile.allowSceneActivation = true;
		//else
			SceneManager.LoadScene(nextScene);
    }

	/*public void skip()
	{
		if ( variabile.isDone )
			variabile.allowSceneActivation = true;
	}*/
}
