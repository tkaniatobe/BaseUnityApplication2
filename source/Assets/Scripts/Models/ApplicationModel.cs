using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class ApplicationModel : MonoBehaviour {

	//Public
	public static JSONObject JSON;

	public static Dictionary<ChapterState,ChapterData> ChapterDataDictionary = new Dictionary<ChapterState,ChapterData>();//NOTE: Testing this out...
	public static Dictionary<PageState,PageData> PageDataDictionary = new Dictionary<PageState,PageData>();//NOTE: Testing this out...


	public enum ChapterState {One = 0,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten};
	public enum PageState {One = 0, Two, Three, Four, Five };

	public static ChapterState Chapter;
	public static PageState Page;

	public static Dictionary<ChapterState,int> ChapterPageLength = new Dictionary<ChapterState,int>();
	public static List<ChapterState> ChapterList = new List<ChapterState>();
	public static List<PageState> PageList = new List<PageState>();

	public static int CurChapter;
	public static int CurPage;

	public static string CurState;
	
	private static void UpdateChapterDictionary(ChapterState _chapterState, int _pageCount) { 
		//Create new ChapterData object and set stuff.
		ChapterData _chapterData = new ChapterData();
		_chapterData.PageCount = _pageCount;
		//_chapterData.ID = _id;
		
		//Update dictionary with ChapterState and ChapterData
		ChapterDataDictionary.Add(_chapterState,_chapterData);
	}

	private static void UpdatePageDictionary(PageState _pageState, int _id) { 
		//Create new PageData object and set stuff.
		PageData _pageData = new PageData();
		_pageData.ID = _id;

		
		//Update dictionary with ChapterState and ChapterData
		PageDataDictionary.Add(_pageState,_pageData);
	}

	public static void Init() {

		//NOTE: Testing new system for State iteration.
		UpdateChapterDictionary(ChapterState.One, 2);
		UpdateChapterDictionary(ChapterState.Two, 4);
		UpdateChapterDictionary(ChapterState.Three, 2);
		UpdateChapterDictionary(ChapterState.Four, 2);
		UpdateChapterDictionary(ChapterState.Five, 2);
		UpdateChapterDictionary(ChapterState.Six, 2);
		UpdateChapterDictionary(ChapterState.Seven, 2);
		UpdateChapterDictionary(ChapterState.Eight, 2);
		UpdateChapterDictionary(ChapterState.Nine, 2);
		UpdateChapterDictionary(ChapterState.Ten, 2);

		UpdatePageDictionary(PageState.One,0);
		UpdatePageDictionary(PageState.Two,1);
		UpdatePageDictionary(PageState.Three,2);
		UpdatePageDictionary(PageState.Four,3);
		UpdatePageDictionary(PageState.Five,4);


		ChapterPageLength.Add(ChapterState.One,2);
		ChapterPageLength.Add(ChapterState.Two,4);
		ChapterPageLength.Add(ChapterState.Three,2);
		ChapterPageLength.Add(ChapterState.Four,2);
		ChapterPageLength.Add(ChapterState.Five,2);
		ChapterPageLength.Add(ChapterState.Six,2);
		ChapterPageLength.Add(ChapterState.Seven,2);
		ChapterPageLength.Add(ChapterState.Eight,2);
		ChapterPageLength.Add(ChapterState.Nine,2);
		ChapterPageLength.Add(ChapterState.Ten,2);

		ChapterList.Add(ChapterState.One);
		ChapterList.Add(ChapterState.Two);
		ChapterList.Add(ChapterState.Three);
		ChapterList.Add(ChapterState.Four);
		ChapterList.Add(ChapterState.Five);
		ChapterList.Add(ChapterState.Six);
		ChapterList.Add(ChapterState.Seven);
		ChapterList.Add(ChapterState.Eight);
		ChapterList.Add(ChapterState.Nine);
		ChapterList.Add(ChapterState.Ten);

		PageList.Add(PageState.One);
		PageList.Add(PageState.Two);
		PageList.Add(PageState.Three);
		PageList.Add(PageState.Four);
		PageList.Add(PageState.Five);
	}

	

	/// <summary>
	/// Move forward one chapter. 
	/// </summary>
	/*public static void NextChapter() { 
		switch(Chapter){
				case ChapterState.One:
					Chapter = ChapterState.Two;
					break;
				case ChapterState.Two:
					Chapter = ChapterState.Three;
					break;
				case ChapterState.Three:
					Chapter = ChapterState.Four;
					break;
				case ChapterState.Four:
					Chapter = ChapterState.Five;
					break;
				case ChapterState.Five:
					Chapter = ChapterState.Six;
					break;
				case ChapterState.Six:
					Chapter = ChapterState.Seven;
					break;
				case ChapterState.Seven:
					Chapter = ChapterState.Eight;
					break;
				case ChapterState.Eight:
					Chapter = ChapterState.Nine;
					break;
				case ChapterState.Nine:
					Chapter = ChapterState.Ten;
					break;
			}
	}*/

	/*public static void NextPage() { 
		switch(Page){
				case PageState.One:
					Page = PageState.Two;
					break;
				case PageState.Two:
					Page = PageState.Three;
					break;
				case PageState.Three:
					Page = PageState.Four;
					break;
				case PageState.Four:
					Page = PageState.Five;
					break;
			}
	}*/



}
