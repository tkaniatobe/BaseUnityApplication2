using UnityEngine;
using System.Collections;

public class EventListener : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}

	void OnEnable() {
		EventManager.OnPoweredUp += OnPoweredUp;
	}

	void OnDisalbe() { 
		EventManager.OnPoweredUp -= OnPoweredUp;
	}

	private void OnPoweredUp( bool IsPoweredUp, int Value) { 
		Debug.Log( IsPoweredUp);
		Debug.Log( Value );	
	}

}
