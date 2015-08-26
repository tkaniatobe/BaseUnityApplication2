using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SectionManager : MonoBehaviour {

	//public List<GameObject> Sections = new List<GameObject> ();

	public GameObject MainMenuObj;
	public GameObject SecondaryMenuObj;

	// Use this for initialization
	public void Start() {
		Init ();
	}

	//Public Methods -------------------------------------
	public void Init() { 
		MainMenuSection.OnPlayClicked += HandlePlayClicked; 
	}
		
	//Private Methods -------------------------------------
	private void HandlePlayClicked() { 
		Debug.Log ("Event Recieved");
	}

}
