using UnityEngine;
using System.Collections;

public class ApplicationController : MonoBehaviour {

	//Public
	 
	//Private
	private string JSONFilePath = "mainJSON";//Name of JSON file in "Assets/Resources" directory.

	private enum Direction {Forward = 0,Backward,None};//For use in changing states.

	//Events
	public delegate void JSONLoadCompleteHandler();
	public static event JSONLoadCompleteHandler OnJSONLoadComplete;

	public delegate void UpdateStateHandler();
	public static event UpdateStateHandler OnUpdateState;


	// Use this for initialization
	void Start () {
		ApplicationModel.Init();//Must be called first to initialize properties.
		LoadJSON();
		Init();
	}
	/// <summary>
	/// Checking for keyboard input
	/// </summary>
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
	// PUBLIC METHODS


	//------------------------------------------------------------------------------------------------------------------------------------------------------
	// PRIVATE METHODS

	private void Init() { 

		//Set firts Chapter and Page
		ApplicationModel.Chapter = ChapterState.One;
		ApplicationModel.Page = PageState.One;		
		UpdateState(Direction.None);//Let UpdateState dispatch event and do nothing else.

		
		//Register Event Listeners
		ApplicationView.OnUpdateChapter += HandleUpdateChapter;
		

		//Dispatch External Event
		DispatchExternalEvent("OnUpdateState");
		//Dispatch Internal Event
		DispatchEvent("OnUpdateState");
	}


	//-------------------------------------------------------------------------------------
	//--------------------STATE MANAGEMENT START-------------------------------------------
	/// <summary>
	/// Updates State and contains logic for both Page and Chapter.
	/// </summary>
	/// <param name="_direction">Direction.</param>
	private void UpdateState(Direction _direction) { 

		if(_direction == Direction.Forward) { 
				
			//Get Current Chapter int based on enum hashcode
			int _curChapterNumber = ((int)ApplicationModel.Chapter.GetHashCode());
			int _pageLength = ApplicationModel.ChapterDataList[_curChapterNumber].PageCount;

			//If current page is less than Chapter page length. Increment Page.
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
			UpdateChapter(Direction.Backward);//Only updating Chapters Backward. Not Pages
		} 

		//Concatenate CurChapter and CurPage into CurState string. (1,1) or (one,one);
		string _chapterState = (ApplicationModel.Chapter.GetHashCode() + 1).ToString();//
		string _pageState = (ApplicationModel.Page.GetHashCode() + 1).ToString();
		ApplicationModel.CombinedState = _chapterState + "," + _pageState;

		DispatchEvent("OnUpdateState");//Dispatch Event. Listened to by ApplicationView...
	}

	//-------------------------------------------------
	/// <summary>
	/// Updates the chapter. Forward or Backward.
	/// </summary>
	/// <param name="_direction">Direction.</param>
	private void UpdateChapter(Direction _direction) {
		int _curChapterNumber = ((int)ApplicationModel.Chapter.GetHashCode());//Chapters enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  

		if(_direction == Direction.Forward) { 		
			//Check if ther are any chapters left.
			if(_curChapterNumber < (ApplicationModel.ChapterDataList.Count) - 1) {
				int _nextChapterNumber = _curChapterNumber + 1;//Set int value for next chapter.
				ApplicationModel.Chapter = ApplicationModel.ChapterDataList[_nextChapterNumber].State;//Set Chapter
				ApplicationModel.Page = PageState.One;	
			}
		}

		if(_direction == Direction.Backward) { 
			//Check if there are any chapters left.
			if(_curChapterNumber > 0) {
				int _nextChapterNumber = _curChapterNumber - 1;//Set int value for next chapter.
				ApplicationModel.Chapter = ApplicationModel.ChapterDataList[_nextChapterNumber].State;//Set Chapter
				ApplicationModel.Page = PageState.One;//Set Page to one.
			} else { 
				ApplicationModel.Page = PageState.One;//Set Page to one.
			}
		}
	}

	//--------------------------------------------------
	/// <summary>
	/// Updates the page. Forward or Backward.
	/// </summary>
	/// <param name="_action">Action.</param>
	private void UpdatePage(Direction _direction) {
		int _curPageNumber = ((int)ApplicationModel.Page.GetHashCode());//Pages enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  
		
		if(_direction == Direction.Forward) { 		
			//Check if there are any pages left.
			if(_curPageNumber < (ApplicationModel.PageDataList.Count)) {
				int _nextPageValue = _curPageNumber + 1;//Set int value for next page.
				ApplicationModel.Page = ApplicationModel.PageDataList[_nextPageValue].State;//Set Page
			}
		}

		if(_direction == Direction.Backward) { 
			if(_curPageNumber > 0) {
				int _nextPageValue = _curPageNumber - 1;//Set int value for next page.
				ApplicationModel.Page = ApplicationModel.PageDataList[_nextPageValue].State;//Set Page
			}
		}
	}



	//--------------------JSON LOAD/PARSE START--------------------------------------------
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

	/// <summary>
	/// Parses JSON data
	/// </summary>
	/// <param name="obj">Object.</param>
	private void AccessData(JSONObject obj){

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
			//Debug Tests...
		
		//Debug.Log(obj.type);
		//Debug.Log(obj.list);
		

	}


	//--------------------EVENT SENDERS----------------------------------------------------
	//-------------------------------------------------------------------------------------

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

	//--------------------EVENT RECIEVERS--------------------------------------------------
	//-------------------------------------------------------------------------------------

	private void HandleUpdateChapter(ChapterState _state) {
		Debug.Log("Event Recieved");
		ApplicationModel.Chapter = _state;
		ApplicationModel.Page = PageState.One;
		UpdateState(Direction.None);
	}

	/// <summary>
	/// Handles events recieved from Modules.
	/// </summary>
	private void HandleExternalEvent() { 

	}	
}
