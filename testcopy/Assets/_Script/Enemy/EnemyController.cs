using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public GameObject shot;
    public Transform ShotSpawn;
    GameObject player;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    NavMeshAgent nav;
    Animator ani;
    float fireRate;
    private float nextFire;

    void Awake()
    {
        nav = this.GetComponent<NavMeshAgent>();
        ani = this.GetComponent<Animator>();
        enemyHealth = this.GetComponent<EnemyHealth>();
        if(GetComponent<EnemyMovement>().curPlayer != null)
        {
            player = GetComponent<EnemyMovement>().curPlayer;
        }
        if (player != null) playerHealth = player.GetComponent<PlayerHealth>();
    }
    void Start()
    {
        fireRate = 0.5f;
        nextFire = Time.time;
    }


    void Update()
    {
        
        if (GameObject.Find("GameController").GetComponent<IsGameStarted>().GameStart == true && player != null 
            && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && Time.time > nextFire)
        {
            if (player.transform.position.z > -30)
            {
                float dis = Vector3.Distance(transform.position, player.transform.position);
                if (dis <= 15f)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, ShotSpawn.position, ShotSpawn.rotation);
                }
            }
            else if(player.transform.position.z <= -30)
            {
                nav.enabled = false;
                ani.SetBool("isIdle", true);
            }
        }
        else
        {
            if(GetComponent<EnemyMovement>().curPlayer != null)
            {
                player = GetComponent<EnemyMovement>().curPlayer;
            }
            if (player != null) playerHealth = player.GetComponent<PlayerHealth>();
        }
    }
}