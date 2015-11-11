using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HealthColor : MonoBehaviour
{

    Transform player;
    PlayerHealth playerhealth;
    PlayerMovement playerMovement;

    Image image;

    public int maxhealth = 100;
    public int curhealth;



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerhealth = player.GetComponent<PlayerHealth>();
        image = GameObject.FindGameObjectWithTag("HealthReal").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        curhealth = playerhealth.currentHealth;
        if (curhealth >= 50 && curhealth <= 100)
        {
            image.color = Color.green;
            image.fillAmount = (float)curhealth / (float)maxhealth;
        }

        if (curhealth < 50 && curhealth >= 30)
        {
            image.color = Color.yellow;
            image.fillAmount = (float)curhealth / (float)maxhealth;
        }

        if (curhealth < 30 && curhealth > 0)
        {
            image.color = Color.red;
            image.fillAmount = (float)curhealth / (float)maxhealth;
        }


    }
}
