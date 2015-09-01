using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void PowerUpHandler( bool IsPoweredUp, int Value );
	public static event PowerUpHandler OnPoweredUp;

	// Use this for initialization
	void Start () {
		
	}

	void OnGUI() {
		if( GUI.Button( new Rect(5,5,150,40), "Power Up")) {
			if(OnPoweredUp != null) {
				OnPoweredUp(true, 3);
			}
		}

		if( GUI.Button( new Rect(5,50,150,40), "Power Up Over")) {
			if(OnPoweredUp != null) {
				OnPoweredUp(false, 4);
			}
		}

	}

}
