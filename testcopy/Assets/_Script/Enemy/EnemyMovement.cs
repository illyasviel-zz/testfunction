using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public GameObject[] player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
    Animator ani;
    public GameObject curPlayer;
    bool GameStart = false;


    void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        ani = this.GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update ()
    {
        GameStart = GameObject.Find("GameController").GetComponent<IsGameStarted>().GameStart;
        if (player.Length > 0 && GameStart == true)
        {
            curPlayer = GetNearestPlayer(player);
            if (curPlayer != null && GetComponent<EnemyHealth>().currentHealth > 0)
            {
                transform.LookAt(curPlayer.transform);
                if (Vector3.Distance(this.transform.position, curPlayer.transform.position) >= 10f)
                {
                    nav.SetDestination(curPlayer.transform.position);
                    ani.SetBool("isWalking", true);
                    ani.speed = 5f;
                    nav.stoppingDistance = 10f;
                }
                else
                {
                    ani.SetBool("isAttrack", true);
                }
                playerHealth = curPlayer.GetComponent<PlayerHealth>();
                enemyHealth = this.GetComponent<EnemyHealth>();
                

            }
        }
        else
        {
            player = GameObject.FindGameObjectsWithTag("Player");
            if(player != null)
            {
                curPlayer = GetNearestPlayer(player);
                if(curPlayer != null)
                {
                    transform.LookAt(curPlayer.transform);
                    if (Vector3.Distance(this.transform.position, curPlayer.transform.position) >= 10f)
                    {
                        nav.SetDestination(curPlayer.transform.position);
                        ani.SetBool("isWalking", true);
                        ani.speed = 5f;
                        nav.stoppingDistance = 10f;
                    }
                    else
                    {
                        ani.SetBool("isAttrack", true);
                    }
                    playerHealth = curPlayer.GetComponent<PlayerHealth>();
                    enemyHealth = this.GetComponent<EnemyHealth>();
                   // nav = this.GetComponent<NavMeshAgent>();
                }
            }
        }
        if(GetNearestPlayer(player) == null)
        {
            ani.speed = 1f;
            ani.Play("muzzy");
        }
    }

    GameObject GetNearestPlayer(GameObject[] player)
    {
        float minDis = float.MaxValue;
        int length = player.Length;
        GameObject res = null;
        for(int i = 0; i < length; i++)
        {
            float temp = Vector3.Distance(transform.position, player[i].transform.position);
            if (player[i].GetComponent<PlayerHealth>().currentHealth > 0 &&
                temp < minDis && player[i].transform.position.z >= -30)
            {
                res = player[i];
                minDis = temp;
            }
        }
        return res;
    }
}
