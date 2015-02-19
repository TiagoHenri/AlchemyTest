using UnityEngine;
using System.Collections;

//script responsavel pelas açoes de clicks no menu
public class LoadOnClick : MonoBehaviour {
	
	public GameObject ImageLoading;

	public void LoadScene(int Level)
	{
		ImageLoading.SetActive(true);
		StartCoroutine(waitSeconds(5));
		Application.LoadLevel(Level);
	
	}

	public void options()
	{

		
	}

	public void Exit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	IEnumerator waitSeconds(int time) 
	{
		yield return new WaitForSeconds(time);
	}
}
