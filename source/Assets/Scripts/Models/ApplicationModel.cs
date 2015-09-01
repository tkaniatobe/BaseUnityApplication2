using UnityEngine;
using System.Collections;


public class ApplicationModel : MonoBehaviour {

	//Public
	public static JSONObject JSON;

	public enum Chapter {One = 1,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten};
	public enum Page {One = 1, Two, Three, Four, Five }

	public static int CurChapter;
	public static int CurPage;

	public static string CurState;

	void Start() { 
		/*Debug.Log(Chapter.One.GetType());
		Debug.Log(Chapter.One.GetHashCode());
		Debug.Log(Chapter.Two.GetHashCode());
		Debug.Log(Chapter.Three.GetHashCode());

		Debug.Log(Page.One.GetHashCode());
		Debug.Log(Page.Two.GetHashCode());
		Debug.Log(Page.Three.GetHashCode());
		Debug.Log(Page.Four.GetHashCode());*/
	}

}
