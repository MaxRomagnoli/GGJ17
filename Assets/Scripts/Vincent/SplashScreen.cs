using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

    public Image image; 
    Color ab;
    //float a = 0;
    bool b = false;
    bool c = false;

	private AudioSource bling;

	void Start ()
    {
		bling = this.GetComponent<AudioSource> ();
        ab = image.color;
	}

	void Update ()
	{

        if (/**/ b == false)
        	StartCoroutine(TransparencyChanger());
        if (ab.a <= 0)
        {
            StopAllCoroutines();
        }
        if (ab.a <= 0.7 && c == false)
        {

            bling.Play();
            c = true;
        }
	}

    IEnumerator TransparencyChanger()
    {
        b = true;
        Debug.Log(ab.a);
        while (ab.a > 0)
        {
            ab.a -= 0.01f;
            Debug.Log("aaa " + ab.a);
            image.color = ab;
            yield return null;
        }

    }
}
