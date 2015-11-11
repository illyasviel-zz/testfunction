using UnityEngine;
using System.Collections;

public class StartReplay : MonoBehaviour {
    GameObject[] players;
	
	// Update is called once per frame
	void Update () {
        players = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerMovement>().enabled = true;
        }
	}
}
