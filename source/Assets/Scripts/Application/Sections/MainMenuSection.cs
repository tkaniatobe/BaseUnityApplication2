using UnityEngine;
using System.Collections;

public class MainMenuSection : BaseSection {

	public delegate void ClickAction ();
	public static event ClickAction OnPlayClicked;
	// Use this for initialization
	public void Start () {
	
	}

	public void HandleButtonClick() { 
		if (OnPlayClicked != null) { 
			OnPlayClicked ();
		}
	}
}
