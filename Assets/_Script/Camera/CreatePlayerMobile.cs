using UnityEngine;
using System.Collections;

public class CreatePlayerMobile : MonoBehaviour
{
    public GameObject playerObject;
    //private GameObject playerButton;
    //LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.FindGameObjectsWithTag("Player").Length < 10)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Floor")
                {
                    Instantiate(playerObject, hit.point, Quaternion.identity);
                }

            }
        }
    }
}
