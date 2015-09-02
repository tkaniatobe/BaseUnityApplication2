using UnityEngine;
using System.Collections;

public class ApplicationController : MonoBehaviour {

	//Public
	 
	//Private
	private string JSONFilePath = "main";//Name of JSON file in "Assets/Resources" directory.

	private enum Direction {Forward = 0,Backward,None};//For use in changing states.

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
		ApplicationModel.Init();//Must be called first to initialize properties.
		LoadJSON();
		Init();
	}

	void Update() {
		//If Left Arrow is pressed move state back
        if (Input.GetKeyUp("left")) {
        	//Debug.Log("Key Left");
        	UpdateState(Direction.Backward);
        	//DispatchEvent("OnUpdateState");
        }
		//If right Arrow is pressed move state forward
        if (Input.GetKeyDown("right")) {
			//Debug.Log("Key Right");
			UpdateState(Direction.Forward);
			//DispatchEvent("OnUpdateState");
        }
    }
	//------------------------------------------------------------------------------------------------------------------------------------------------------
	// Public Methods


	//------------------------------------------------------------------------------------------------------------------------------------------------------
	// Private Methods

	private void Init() { 

		//Set firts Chapter and Page
		ApplicationModel.Chapter = ApplicationModel.ChapterState.One;
		ApplicationModel.Page = ApplicationModel.PageState.One;		
		UpdateState(Direction.None);//Let UpdateState dispatch event and do nothing else.

		
		//Register Event Listeners
		ApplicationView.OnUpdateChapter += HandleUpdateChapter;
		

		//Dispatch External Event
		DispatchExternalEvent("OnUpdateState");
		//Dispatch Internal Event
		DispatchEvent("OnUpdateState");
	}

	//-------------------------------------------------------------------------------------
	//-------------------------------------------------------------------------------------	
	/// <summary>
	/// Updates State and contains logic for both Page and Chapter.
	/// </summary>
	/// <param name="_direction">Direction.</param>
	private void UpdateState(Direction _direction) { 

		if(_direction == Direction.Forward) { 
			int _pageLength = ApplicationModel.ChapterPageLength[ApplicationModel.Chapter];//Get chapter page length from Dictionary.
			//Debug.Log(_pageLength);			

			//If current page is less the Chapter page length. Increment Page.
			//Else increment Chapter and reset page to 1
			if(ApplicationModel.Page.GetHashCode() < _pageLength) { 
				//NextPage();
				Debug.Log("Page Forward");
				UpdatePage(Direction.Forward);	
			} else { 
				//NextChapter();
				Debug.Log("Chapter Forward");
				UpdateChapter(Direction.Forward);
				//ApplicationModel.Page = ApplicationModel.PageState.One;
			}
		} 

		if(_direction == Direction.Backward) { 
			int _pageLength = ApplicationModel.ChapterPageLength[ApplicationModel.Chapter];//Get chapter page length from Dictionary.

			UpdateChapter(Direction.Backward);//Only updating Chapters Backward. Not Pages
		} 

		//Concatenate CurChapter and CurPage into CurState string. (1,1) or (one,one);
		string _chapterState = (ApplicationModel.Chapter.GetHashCode() + 1).ToString();//
		string _pageState = (ApplicationModel.Page.GetHashCode() + 1).ToString();
		ApplicationModel.CurState = _chapterState + "," + _pageState;

		DispatchEvent("OnUpdateState");//Dispatch Event. Listened to by ApplicationView...
	}

	//-------------------------------------------------------------------------------------	
	/// <summary>
	/// Updates the chapter. Forward or Backward.
	/// </summary>
	/// <param name="_direction">Direction.</param>
	private void UpdateChapter(Direction _direction) {
		int _curChapterValue = ((int)ApplicationModel.Chapter.GetHashCode());//Chapters enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  

		if(_direction == Direction.Forward) { 		
			//Check if ther are any chapters left.
			if(_curChapterValue < (ApplicationModel.ChapterList.Count) - 1) {
				int _nextChapterValue = _curChapterValue + 1;//Set int value for next chapter.
				ApplicationModel.Chapter = ApplicationModel.ChapterList[_nextChapterValue];//Set Chapter
				ApplicationModel.Page = ApplicationModel.PageState.One;	
			}
		}

		if(_direction == Direction.Backward) { 
			//Check if there are any chapters left.
			if(_curChapterValue > 0) {
				int _nextChapterValue = _curChapterValue - 1;//Set int value for next chapter.
				ApplicationModel.Chapter = ApplicationModel.ChapterList[_nextChapterValue];//Set Chapter
				ApplicationModel.Page = ApplicationModel.PageState.One;//Set Page to one.
			} else { 
				ApplicationModel.Page = ApplicationModel.PageState.One;//Set Page to one.
			}
		}
	}

	//-------------------------------------------------------------------------------------	
	/// <summary>
	/// Updates the page. Forward or Backward.
	/// </summary>
	/// <param name="_action">Action.</param>
	private void UpdatePage(Direction _direction) {
		int _curPageValue = ((int)ApplicationModel.Page.GetHashCode());//Pages enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  
		
		if(_direction == Direction.Forward) { 		
			//Check if there are any pages left.
			if(_curPageValue < (ApplicationModel.PageList.Count)) {
				int _nextPageValue = _curPageValue + 1;//Set int value for next page.
				ApplicationModel.Page = ApplicationModel.PageList[_nextPageValue];//Set Page
			}
		}

		if(_direction == Direction.Backward) { 
			if(_curPageValue > 0) {
				int _nextPageValue = _curPageValue - 1;//Set int value for next page.
				ApplicationModel.Page = ApplicationModel.PageList[_nextPageValue];//Set Page
			}
		}
	}

	

	//-------------------------------------------------------------------------------------
	//-------------------------------------------------------------------------------------
	/// <summary>
	/// Load JSON and dispatch event.
	/// </summary>
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

	//-------------------------------------------------------------------------------------
	//-------------------------------------------------------------------------------------
	//Event Handlers
	private void HandleUpdateChapter(ApplicationModel.ChapterState _state) {
		Debug.Log("Event Recieved");
		ApplicationModel.Chapter = _state;
		ApplicationModel.Page = ApplicationModel.PageState.One;
		UpdateState(Direction.None);
	}
}
