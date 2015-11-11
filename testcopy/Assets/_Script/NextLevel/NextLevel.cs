using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

   /* GameObject[] enemy;
    private int i = 0;
    public bool loadNextLevel = false;
    Label label;

    // Use this for initialization
	void Start () {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        label = transform.GetComponent<Label>();
    }
	
	// Update is called once per frame
	void Update () {
        loadNextLevel = nextlevel();
        if (loadNextLevel == true)
        {
            label.enabled = true;
        }
        
	}

    bool nextlevel() {
        int count = 0;
        bool res = false;
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].GetComponent<EnemyHealth>().currentHealth <= 0) count++;
        }
        if (count == enemy.Length) res = true;
        return res;
    } */

    void Start()
    {
        Application.LoadLevel("test2");
    }
}
