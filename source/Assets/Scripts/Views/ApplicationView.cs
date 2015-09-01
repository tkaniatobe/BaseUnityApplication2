using UnityEngine;
using System.Collections;

public class ApplicationView : MonoBehaviour {

	//Public
	public GameObject Camera;
	public GameObject UI;

	//Private
	private string CurState;
	private GUIStyle GuiStyle = new GUIStyle(); //create a new variable
	//Events

	// Use this for initialization
	void Start () {
		//Setup Event Listeners
		ApplicationController.OnJSONLoadComplete += HandleJSONLoadComplete;
		ApplicationController.OnUpdateState += HandleUpdateState;
	}

	//UI - temp
	void OnGUI () {   
        // Automatic Layout
		GUI.Label(new Rect(10, 10, 100, 20), CurState);
    }

 
    // Public Methods ----------------------------------------------------------------------------


	// Private Methods ---------------------------------------------------------------------------

	//Event Handlers
	private void HandleUpdateState() {
		Debug.Log("Update State Recieved");
		Debug.Log(ApplicationModel.CurState);
		CurState = ApplicationModel.CurState;//Set Variable for UI render
	}

	private void HandleJSONLoadComplete() {
		Debug.Log("JSON Load Complete");
	}
}
