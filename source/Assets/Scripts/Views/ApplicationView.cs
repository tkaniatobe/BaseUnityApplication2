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

	//Events
	public delegate void UpdateChapterHandler(ApplicationModel.ChapterState _state);
	public static event UpdateChapterHandler OnUpdateChapter;

	// Use this for initialization
	void Start () {
		//Register Event Listeners
		ApplicationController.OnJSONLoadComplete += HandleJSONLoadComplete;
		ApplicationController.OnUpdateState += HandleUpdateState;
	}

	//UI - temp
	void OnGUI () {   
        // Automatic Layout
		GUI.Label(new Rect(10, 10, 100, 20), CurState);
        
        if (GUI.Button(new Rect(10, 70, 50, 30), "1")) {
			DispatchStateEvent("OnUpdateChapter",ApplicationModel.ChapterState.One);
		}

		if (GUI.Button(new Rect(10, 110, 50, 30), "2")) {
           DispatchStateEvent("OnUpdateChapter",ApplicationModel.ChapterState.Two);
		}

		if (GUI.Button(new Rect(10, 150, 50, 30), "3")) {
           DispatchStateEvent("OnUpdateChapter",ApplicationModel.ChapterState.Three);
		}

		if (GUI.Button(new Rect(10, 190, 50, 30), "4")) {
           DispatchStateEvent("OnUpdateChapter",ApplicationModel.ChapterState.Four);
		}

		if (GUI.Button(new Rect(10, 230, 50, 30), "5")) {
           DispatchStateEvent("OnUpdateChapter",ApplicationModel.ChapterState.Five);
		}

		if (GUI.Button(new Rect(10, 270, 50, 30), "6")) {
           DispatchStateEvent("OnUpdateChapter",ApplicationModel.ChapterState.Six);
		}
		if (GUI.Button(new Rect(10, 310, 50, 30), "7")) {
           DispatchStateEvent("OnUpdateChapter",ApplicationModel.ChapterState.Seven);
		}
		if (GUI.Button(new Rect(10, 350, 50, 30), "8")) {
           DispatchStateEvent("OnUpdateChapter",ApplicationModel.ChapterState.Eight);
		}
		if (GUI.Button(new Rect(10, 390, 50, 30), "9")) {
           DispatchStateEvent("OnUpdateChapter",ApplicationModel.ChapterState.Nine);
		}
		if (GUI.Button(new Rect(10, 430, 50, 30), "10")) {
           DispatchStateEvent("OnUpdateChapter",ApplicationModel.ChapterState.Ten);
		}
    }

 
    // Public Methods ----------------------------------------------------------------------------


	// Private Methods ---------------------------------------------------------------------------

	/// <summary>
	/// Dispatches Events. Internal Events relative to this application
	/// </summary>
	/// <param name="_event">Event.</param>
	private void DispatchStateEvent(string _event,ApplicationModel.ChapterState _state) { 
		switch(_event){
			case "OnUpdateChapter":
				if(OnUpdateChapter != null) {
					OnUpdateChapter(_state);
				}
			break;
		}
	}
	
	//Event Handlers
	private void HandleUpdateState() {
		//Debug.Log("Update State Recieved");
		//Debug.Log(ApplicationModel.Chapter);
		CurState = ApplicationModel.CurState;//Set Variable for UI render
	}

	private void HandleJSONLoadComplete() {
		Debug.Log("JSON Load Complete");
	}
}
