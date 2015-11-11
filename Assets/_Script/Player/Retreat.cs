using UnityEngine;
using System.Collections;

public class Retreat : MonoBehaviour
{

    NavMeshAgent nav;
    GameObject[] player;
    int length;
    Animator ani;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        length = player.Length;
        for (int i = 0; i < length; i++)
        {
            if (player[i].GetComponent<PlayerHealth>().currentHealth > 0)
            {
                player[i].GetComponent<PlayerMovement>().enabled = false;
                nav = player[i].GetComponent<NavMeshAgent>();
                nav.SetDestination(new Vector3(0.0f, 0.0f, -38f));
                nav.stoppingDistance = 0.0f;
                player[i].transform.FindChild("test").GetComponent<Generator>().enabled = false;
            }
        }
    }

        // Update is called once per frame
    void Update () {
        player = GameObject.FindGameObjectsWithTag("Player");
        length = player.Length;
        for (int i = 0; i < length; i++)
        {
            if (player[i].GetComponent<PlayerHealth>().currentHealth < 0 && 
                player[i].GetComponent<NavMeshAgent>().enabled == true)
            {
                nav = player[i].GetComponent<NavMeshAgent>();
                nav.speed = 0f;
                nav.angularSpeed = 0.0f;
            }
        }
    }
}
