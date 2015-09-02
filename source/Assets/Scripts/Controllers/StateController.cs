using UnityEngine;
using System.Collections;

public static class StateController {
    /*public static int Sum(int number1, int number2) {
        return number1 + number2;
    }*/

	public static void NextChapter() { 
		int _curChapterValue = ((int)ApplicationModel.Chapter.GetHashCode());//Chapters enum values are 1-10. Dictionary is 0-9. Offsetting value by one.  
		
		//Check if ther are any chapters left.
		if(_curChapterValue < (ApplicationModel.ChapterList.Count)) {
			int _nextChapterValue = _curChapterValue + 1;//Set int value for next chapter.

			ApplicationModel.Chapter = ApplicationModel.ChapterList[_nextChapterValue];//Set Chapter	

			ApplicationModel.Chapter = ApplicationModel.ChapterList[20];

			/*KeyValuePair<ChapterState,int> item = ChapterPageLength.ElementAt(_nextChapterValue);//Access Next Chapter in Dictionary
			Chapter	= item.Key;//Set next Chapter*/
		}
	}

	


}
