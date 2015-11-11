using UnityEngine;
using UnityEngine.UI;

public class PlayerNumText : MonoBehaviour {

    private static int RemainNum;
    private Text text;
    // Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
        RemainNum = 10;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = (RemainNum - GameObject.FindGameObjectsWithTag("Player").Length).ToString();
	}
}
