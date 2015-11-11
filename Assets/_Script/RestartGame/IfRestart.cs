using UnityEngine;
using Mono.Data.Sqlite;


public class IfRestart : MonoBehaviour {

    // Use this for initialization
    GameObject[] enemy;
    GameObject[] player;
    private int i = 0;
    public bool Restart = false;
    DbAccess db;

    // Use this for initialization
    void Start()
    {
        
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Restart = EnemyState() | PlayerState();

    }

    bool EnemyState()
    {
        int count = 0;
        bool res = false;
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].GetComponent<EnemyHealth>().currentHealth <= 0) count++;
        }
        if (count == enemy.Length) res = true;
        return res;
    }

    bool PlayerState()
    {
        int count = 0;
        bool res = false;
        for(int i = 0; i < player.Length; i++)
        {
            if (player[i].GetComponent<PlayerHealth>().currentHealth <= 0) count++;
        }
        if (count == player.Length) res = true;
        return res;
    }
}
