using UnityEngine;
using System.Collections;

public class ApplicationController : MonoBehaviour {

	//Public
	 
	//Private
	private string JSONFilePath = "main";//Name of JSON file in "Assets/Resources" directory.

	//Events
	public delegate void JSONLoadCompleteHandler();
	public static event JSONLoadCompleteHandler OnJSONLoadComplete;

	public delegate void UpdateStateHandler();
	public static event UpdateStateHandler OnUpdateState;

	/*public delegate void UpdateMoveStateForwardHandler();
	public static event UpdateMoveStateForwardHandler OnMoveStateForward;

	public delegate void UpdateMoveStateBackHandler();
	public static event UpdateMoveStateBackHandler OnMoveStateBack;*/

	// Use this for initialization
	void Start () {
		LoadJSON();
		InitApp();
	}

	void Update() {
		//If Left Arrow is pressed move state back
        if (Input.GetKeyUp("left")) {
        	//Debug.Log("Key Left");
        	UpdateState("back");
        	DispatchEvent("OnUpdateState");
        }
		//If right Arrow is pressed move state forward
        if (Input.GetKeyDown("right")) {
			//Debug.Log("Key Right");
			UpdateState("forward");
			DispatchEvent("OnUpdateState");
        }
    }

	// Public Methods ----------------------------------------------------------------------------


	// Private Methods ---------------------------------------------------------------------------

	private void InitApp() { 
		//Set numerical value of current chapter and page.

		UpdateState("start");

		//Dispatch External Event
		DispatchExternalEvent("OnUpdateState");
		//Dispatch Internal Event
		DispatchEvent("OnUpdateState");
	}

	
	private void UpdateState(string _action) { 
		

		//Set first Chapter/Page. Called at Start()
		if(_action == "start") {
			ApplicationModel.Chapter = ApplicationModel.ChapterState.One;
			ApplicationModel.Page = ApplicationModel.PageState.One;
		}


		if(_action == "forward") { 
			int _pageLength = ApplicationModel.ChapterPageLength[ApplicationModel.Chapter];//Get chapter page length from Dictionary.
			
			//If current page is less the Chapter page length. Increment Page.
			//Else increment Chapter and reset page to 1
			if(ApplicationModel.Page.GetHashCode() < _pageLength) { 
				ApplicationModel.NextPage();	
			} else { 
				ApplicationModel.NextChapter();
				ApplicationModel.FirstPage();
			}
		} 

		if(_action == "back") { 
			int _pageLength = ApplicationModel.ChapterPageLength[ApplicationModel.Chapter];//Get chapter page length from Dictionary.
			
			//If current page is less the Chapter page length. Increment Page.
			//Else increment Chapter and reset page to 1
			if(ApplicationModel.Page.GetHashCode() > 1) { 
				ApplicationModel.PrevPage();	
			} else { 
				ApplicationModel.PrevChapter();
				ApplicationModel.FirstPage();
			}
		} 

		//Concatenate CurChapter and CurPage into CurState string. (1,1) or (one,one);
		ApplicationModel.CurState = ApplicationModel.Chapter.GetHashCode().ToString() + "," + ApplicationModel.Page.GetHashCode().ToString();
	}

	private void LoadJSON() { 
		TextAsset file = Resources.Load(JSONFilePath) as TextAsset;//Load JSON file From Resources directory
		JSONObject _jsonObject = new JSONObject(file.ToString());

		ApplicationModel.JSON = _jsonObject;//Set JSON variable in Model

		AccessData(_jsonObject);//Decode JSON

		DispatchEvent("OnJSONLoadComplete");
	}

	//access data (and Debug.Log)
	private void AccessData(JSONObject obj){

		
		//Debug Tests...
		/*
		//Debug.Log(obj.type);
		//Debug.Log(obj.list);
		*/


		//Modules
		JSONObject modules = obj["modules"];

		//Loop through Modules
		for (int i = 0; i < modules.Count; i++) {
			Debug.Log(modules.keys[i]);
		}


		//ClusterUI Module
		JSONObject clusterUI = obj["modules"]["clusterUi"];

		//Loop through Interests action/triggers
		for (int i = 0; i < clusterUI["interests"].Count; i++) {
			Debug.Log(clusterUI["interests"][i]["action"]);
			Debug.Log(clusterUI["interests"][i]["trigger"]);
			//Debug.Log(clusterUI["interests"][i].keys[0]);
			//Debug.Log(clusterUI["interests"][i].keys[1]);
		}
	



			//Reference from JSONObject tutorial....
			/*switch(obj.type){
				case JSONObject.Type.OBJECT:
					for(int i = 0; i < obj.list.Count; i++){
						string key = (string)obj.keys[i];
						JSONObject j = (JSONObject)obj.list[i];
						Debug.Log(obj.list.Count);
						Debug.Log(key);
						//accessData(j);
					}
					break;
				case JSONObject.Type.ARRAY:
					foreach(JSONObject j in obj.list){
						accessData(j);
					}
					break;
				case JSONObject.Type.STRING:
					Debug.Log(obj.str);
					break;
				case JSONObject.Type.NUMBER:
					Debug.Log(obj.n);
					break;
				case JSONObject.Type.BOOL:
					Debug.Log(obj.b);
					break;
				case JSONObject.Type.NULL:
					Debug.Log("NULL");
					break;
			}*/
	}

	/// <summary>
	/// Handles events recieved from Modules.
	/// </summary>
	private void HandleExternalEvent() { 

	}	

	/// <summary>
	/// Dispatches Events to External Applications.
	/// </summary>
	/// <param name="_event">Event.</param>
	private void DispatchExternalEvent(string _event) { 
		switch(_event){
			case "test":
				//
			break;
		}
	}

	/// <summary>
	/// Dispatches Events. Internal Events relative to this application
	/// </summary>
	/// <param name="_event">Event.</param>
	private void DispatchEvent(string _event) { 
		switch(_event){
			case "OnJSONLoadComplete":
				if(OnJSONLoadComplete != null) {
					OnJSONLoadComplete();
				}
			break;
			case "OnUpdateState":
				if(OnUpdateState != null) {
					OnUpdateState();
				}
			break;
		}
	}

}
