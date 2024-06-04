using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrentationScript : MonoBehaviour {

	public enum OrientamentoSchermo
	{
		Automatico,
		Verticale,
		Orizzontale,
		OrizzontaleSinistra,
		OrizzontaleDestra
	}

	public OrientamentoSchermo orientamento;

	void Start ()
	{
		switch ( orientamento )
		{
			case OrientamentoSchermo.Automatico:
				Screen.orientation = ScreenOrientation.AutoRotation;
				break;
			case OrientamentoSchermo.Verticale:
				Screen.orientation = ScreenOrientation.Portrait;
				break;
			case OrientamentoSchermo.Orizzontale:
				Screen.orientation = ScreenOrientation.Landscape;
				break;
			case OrientamentoSchermo.OrizzontaleSinistra:
				Screen.orientation = ScreenOrientation.LandscapeLeft;
				break;
			case OrientamentoSchermo.OrizzontaleDestra:
				Screen.orientation = ScreenOrientation.LandscapeRight;
				break;
		}
	}
}
