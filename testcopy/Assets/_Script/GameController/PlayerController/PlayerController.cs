using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    GameObject[] players;
    // Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerMovement>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
