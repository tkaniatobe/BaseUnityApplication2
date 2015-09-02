using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class ApplicationModel : MonoBehaviour {

	//Public
	public static JSONObject JSON;

	public enum ChapterState {One = 0,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten};
	public enum PageState {One = 0, Two, Three, Four, Five }

	public static ChapterState Chapter;
	public static PageState Page;

	public static Dictionary<ChapterState,int> ChapterPageLength = new Dictionary<ChapterState,int>();
	public static List<ChapterState> ChapterList = new List<ChapterState>();
	public static List<PageState> PageList = new List<PageState>();


	public static int CurChapter;
	public static int CurPage;

	public static string CurState;
	
	public static void Init() {
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
		int _curChapterValue = ((int)Chapter.GetHashCode());//Chapters enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  
		
		//Check if ther are any chapters left.
		if(_curChapterValue < (ChapterList.Count)) {
			int _nextChapterValue = _curChapterValue + 1;//Set int value for next chapter.

			Chapter = ChapterList[_nextChapterValue];//Set Chapter	
		}
	}

	/// <summary>
	/// Move backward one chapter. 
	/// </summary>
	public static void PrevChapter() {
		int _curChapterValue = ((int)Chapter.GetHashCode());//get int value of current Chapter
		
		//Check if there are any chapters left.
		if(_curChapterValue < (ChapterList.Count)) {
			int _nextChapterValue = _curChapterValue - 1;//Set int value for next chapter.

			Chapter = ChapterList[_nextChapterValue];//Set Chapter
			Page = PageState.One;//Set Page to one.
		}
	}

	/// <summary>
	/// Move forward one page. 
	/// </summary>
	public static void NextPage() { 
		int _curPageValue = ((int)Page.GetHashCode());//Pages enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  

		//Check if there are any pages left.
		if(_curPageValue < (PageList.Count)) {
			int _nextPageValue = _curPageValue + 1;//Set int value for next page.
			
			Page = PageList[_nextPageValue];//Set Page
		}
	}

	public static void PrevPage() {
		int _curPageValue = ((int)Page.GetHashCode());//Pages enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  

		//
		if(_curPageValue > 0) {
			int _nextPageValue = _curPageValue - 1;//Set int value for next page.
			
			Page = PageList[_nextPageValue];//Set Page
		}
	}*/

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
