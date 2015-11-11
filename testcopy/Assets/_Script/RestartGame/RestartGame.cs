using UnityEngine;

public class RestartGame : MonoBehaviour {

	// Use this for initialization
	public void Start () {
        Application.LoadLevel(Application.loadedLevel);
	}
	
	// Update is called once per frame
}
