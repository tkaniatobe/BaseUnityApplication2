using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class ApplicationModel : MonoBehaviour {

	//Public
	public static JSONObject JSON;

	public enum ChapterState {One = 1,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten};
	public enum PageState {One = 1, Two, Three, Four, Five }

	public static ChapterState Chapter;
	public static PageState Page;

	public static Dictionary<ChapterState,int> ChapterPageLength = new Dictionary<ChapterState,int>();
	public static List<ChapterState> ChapterList = new List<ChapterState>();
	public static List<PageState> PageList = new List<PageState>();


	public static int CurChapter;
	public static int CurPage;

	public static string CurState;


	void Start() { 
		Chapter = ChapterState.One;
		Debug.Log(Chapter);
		Debug.Log(Chapter.GetHashCode());

		Page = PageState.One;

		ChapterPageLength.Add(ChapterState.One,3);
		ChapterPageLength.Add(ChapterState.Two,5);
		ChapterPageLength.Add(ChapterState.Three,3);
		ChapterPageLength.Add(ChapterState.Four,3);
		ChapterPageLength.Add(ChapterState.Five,3);
		ChapterPageLength.Add(ChapterState.Six,3);
		ChapterPageLength.Add(ChapterState.Seven,3);
		ChapterPageLength.Add(ChapterState.Eight,3);
		ChapterPageLength.Add(ChapterState.Nine,3);
		ChapterPageLength.Add(ChapterState.Ten,3);

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
	public static void NextChapter() { 
		int _curChapterValue = ((int)Chapter.GetHashCode()) - 1;//Chapters enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  
		
		//Check if ther are any chapters left.
		if(_curChapterValue < (ChapterList.Count - 1)) {
			int _nextChapterValue = _curChapterValue + 1;//Set int value for next chapter.

			Chapter = ChapterList[_nextChapterValue];//Set Chapter	

			/*KeyValuePair<ChapterState,int> item = ChapterPageLength.ElementAt(_nextChapterValue);//Access Next Chapter in Dictionary
			Chapter	= item.Key;//Set next Chapter*/
		}
	}

	/// <summary>
	/// Move backward one chapter. 
	/// </summary>
	public static void PrevChapter() {
		int _curChapterValue = ((int)Chapter.GetHashCode()) - 1;//Chapters enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  
		
		//Check if there are any chapters left.
		if(_curChapterValue < (ChapterList.Count - 1)) {
			int _nextChapterValue = _curChapterValue - 1;//Set int value for next chapter.

			Chapter = ChapterList[_nextChapterValue];//Set Chapter	
		}
	}

	/// <summary>
	/// Move forward one page. 
	/// </summary>
	public static void NextPage() { 
		int _curPageValue = ((int)Page.GetHashCode()) - 1;//Pages enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  

		//Check if there are any pages left.
		if(_curPageValue < (PageList.Count - 1)) {
			int _nextPageValue = _curPageValue + 1;//Set int value for next page.
			
			Page = PageList[_nextPageValue];//Set Page
		}
	}

	public static void PrevPage() {
		int _curPageValue = ((int)Page.GetHashCode()) - 1;//Pages enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  

		//
		if(_curPageValue > 0) {
			int _nextPageValue = _curPageValue - 1;//Set int value for next page.
			
			Page = PageList[_nextPageValue];//Set Page
		}
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

	public static void FirstPage() { 
		Page = PageState.One;
	}


}
