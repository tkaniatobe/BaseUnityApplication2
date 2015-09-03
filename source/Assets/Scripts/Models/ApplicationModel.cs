using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//Enums. Outside of class for global access
public enum ChapterState {One = 0,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten};
public enum PageState {One = 0, Two, Three, Four, Five };

public class ApplicationModel : MonoBehaviour {

	//Public
	public static JSONObject JSON;//Set after JSON is loaded
	
	//Lists containing data for use with ChapterState and PageState state changes.
	//Used in controller to iterate through states sequentially
	public static List<ChapterData> ChapterDataList = new List<ChapterData>();
	public static List<PageData> PageDataList = new List<PageData>();

	public static ChapterState Chapter;
	public static PageState Page;

	public static string CombinedState;//Used to concatenate a string and dispatch to modules. (1,1) (2,1) etc...

	public static void Init() {

		//NOTE: Testing new system for State iteration.
		UpdateChapterList(ChapterState.One, 2);
		UpdateChapterList(ChapterState.Two, 4);
		UpdateChapterList(ChapterState.Three, 2);
		UpdateChapterList(ChapterState.Four, 2);
		UpdateChapterList(ChapterState.Five, 2);
		UpdateChapterList(ChapterState.Six, 2);
		UpdateChapterList(ChapterState.Seven, 2);
		UpdateChapterList(ChapterState.Eight, 2);
		UpdateChapterList(ChapterState.Nine, 2);
		UpdateChapterList(ChapterState.Ten, 2);

		UpdatePageList(PageState.One);
		UpdatePageList(PageState.Two);
		UpdatePageList(PageState.Three);
		UpdatePageList(PageState.Four);
		UpdatePageList(PageState.Five);

	}
	
	//Sets Chapter Data and adds to ChapterDataList
	private static void UpdateChapterList(ChapterState _chapterState, int _pageCount) { 
		//Create new ChapterData object and set stuff.
		ChapterData _chapterData = new ChapterData();
		_chapterData.State = _chapterState;
		_chapterData.PageCount = _pageCount;
		_chapterData.ID = (int)_chapterState.GetHashCode();//Get ID from enum HashCode 0-9
		
		//Update dictionary with ChapterState and ChapterData
		ChapterDataList.Add(_chapterData);
	}

	//Sets Page Data and adds to PageDataList
	private static void UpdatePageList(PageState _pageState) { 
		//Create new PageData object and set stuff.
		PageData _pageData = new PageData();
		_pageData.State = _pageState;
		_pageData.ID = (int)_pageState.GetHashCode();//Get ID from enum HashCode 0-4

		
		//Update dictionary with ChapterState and ChapterData
		PageDataList.Add(_pageData);
	}


}
