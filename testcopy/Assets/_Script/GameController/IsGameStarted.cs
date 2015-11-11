using UnityEngine;
using System.Collections;

public class IsGameStarted : MonoBehaviour {

    public bool GameStart = false;
    EnemyHealth enemyHealth;
    public GameObject[] enemy;

    // Use this for initialization
	void Start () {
        GameStart = true;
        enemyHealth = GetComponent<EnemyHealth>();
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	// Update is called once per frame
/*	void Update()
    {
       if(GameObject.Find("Player").GetComponent<PlayerMovement>().nextlevel == true)
        Application.LoadLevel("test2");
    }    */
    void Update()
    {
        int count = 0;
        for(int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].GetComponent<EnemyHealth>().currentHealth == 0) {
                count++;
            }
        }
//        if (count == enemy.Length) Application.LoadLevel("tests");

    }
}
