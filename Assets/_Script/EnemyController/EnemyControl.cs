using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

    // Use this for initialization
    
    void Start () {
        GameObject[] enemys;
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < enemys.Length; i++)
        {
            enemys[i].GetComponent<EnemyController>().enabled = true;
        }
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
