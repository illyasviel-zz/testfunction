using UnityEngine;
using System.Collections;

public class CreatePlayer : MonoBehaviour {
    public GameObject playerObject;
    public bool isTargetSet = false;
    public bool generatePlayer;
    public GameObject Target;
    public float minLength = 2f;
    public int countplayer = -1;

    // private Camera selectedCamera;

    //public float touchTime;
    public Vector2 touchPoint;
    public Vector2 leavePoint;
    public Vector3 generatePos;

    void FixedUpdate()
    {
        int recentlength = GameObject.FindGameObjectsWithTag("Player").Length;
       if (recentlength >= 10)
        {
            return;
        } 
        if(recentlength < 10 && Input.touchCount == 1)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchPoint = Input.GetTouch(0).position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended) 
            {
                leavePoint = Input.GetTouch(0).position;
                if(Vector2.Distance(touchPoint,leavePoint) < minLength)
                {
                    Ray ray = Camera.main.ScreenPointToRay(leavePoint);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if ((hit.collider.name == "Floor") &&
                        GameObject.Find("GameController").GetComponent<IsGameStarted>().GameStart == false)
                        {
                            countplayer++;
                            generatePos = hit.point;
                            Instantiate(playerObject, hit.point, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}
