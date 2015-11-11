using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestButtonClick : MonoBehaviour {
    GameObject myButton;
    GameObject[] player;
    Color  temp;
    bool isPlayerButtonOn = false;

    void Start()
    {
        myButton = GameObject.Find("PlayerGenerationButton");
        temp = myButton.GetComponent<Button>().colors.normalColor;
        myButton.GetComponent<Image>().color = Color.yellow;
        isPlayerButtonOn = true;
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length < 10 && isPlayerButtonOn == true)
        {
            myButton.GetComponent<Image>().color = Color.yellow;
        }
        if(GameObject.FindGameObjectsWithTag("Player").Length < 10 && isPlayerButtonOn == false)
        {
            myButton.GetComponent<Image>().color = Color.white;
        }
        if (GameObject.FindGameObjectsWithTag("Player").Length >= 10)
        {
            myButton.GetComponent<Image>().color = Color.white;
            myButton.GetComponent<Button>().interactable= false;
        }
    }

}
