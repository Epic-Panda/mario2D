using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

	public Toggle delete;

	public void ExitGame(){
		if(delete.isOn)
		ResetScore();
		
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying=false;
		#else
		Application.Quit();
		#endif
	}

	/// <summary>
	/// Resets the score.
	/// </summary>
	private void ResetScore()
	{
		PlayerPrefs.DeleteAll();
	}
}
