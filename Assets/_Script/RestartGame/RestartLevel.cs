using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {

    public GameObject restartbutton;
    bool showButton = false;
//    public GameObject replayButton;

    // Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<IfRestart>().Restart == true)
        {
            showButton = true;
            restartbutton.SetActive(true);
        //    replayButton.SetActive(true);
        }
    }
}
