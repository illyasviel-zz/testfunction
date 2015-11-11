using UnityEngine;
using System.Collections;

public class PlayerGeneration : MonoBehaviour {

    public GameObject player;
    //Vector3 generatePos;
    Quaternion generateDir;
    // Use this for initialization
	void Start () {
        generateDir = player.transform.rotation;
       Vector3 generatePos = new Vector3(1f, 0, -29.6f);
        Instantiate(player, generatePos, generateDir);
	}
	
	// Update is called once per frame
	
}
