using UnityEngine;
using System.Collections;

public class AndroidTouch : MonoBehaviour
{

    Vector2 m_screenpos = new Vector2();
    private float speed = 10f;
    private float speedmove = 5f;
    float zMax = -10, zMin = -50f;
    //GameObject mainCamera;
    // Use this for initialization
    void Start()
    {
        Input.multiTouchEnabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        MobileInput();

    }

    void MobileInput()
    {
        if (Input.touchCount <= 0)
        {
            return;
        }

        // onr finger touches screen
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                m_screenpos = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Moved)
            {
                float curZ = transform.position.z;
                float xMin = 2.5f*curZ, xMax = 30f, yMax = 50f, yMin = 2f;
                float newX = transform.position.x + (-1 * Input.touches[0].deltaPosition.x * Time.deltaTime * speedmove);
                float newY = transform.position.y + (-1 * Input.touches[0].deltaPosition.y * Time.deltaTime * speedmove);
                
                if (newX < xMax && newX > xMin && newY >yMin && newY < yMax)
                     Camera.main.transform.Translate(new Vector3(-1 * Input.touches[0].deltaPosition.x * Time.deltaTime * speedmove,
                                               -1 * Input.touches[0].deltaPosition.y * Time.deltaTime * speedmove, 0));
            }
            /*	if (Input.touches [0].phase == TouchPhase.Ended && Input.touches [0].phase != TouchPhase.Canceled) {
                    Vector2 pos = Input.touches [0].position;
                    if (Mathf.Abs (m_screenpos.x - pos.x) > Mathf.Abs (m_screenpos.y - pos.y)) {
                        if (m_screenpos.x > pos.x) {
                            Camera.main.transform.Translate()
                        } else {
                            //move right
                        }
                    } else {
                        if (m_screenpos.y > pos.y) {
                            //down
                        } else {
                            //up
                        }
                    }
                }*/
        }
        else if (Input.touchCount > 1)
        {
            Vector2 figure1 = new Vector2();
            Vector2 figure2 = new Vector2();

            Vector2 move1 = new Vector2();
            Vector2 move2 = new Vector2();

            for (int i = 0; i < 2; i++)
            {
                Touch touch = Input.touches[i];

                if (touch.phase == TouchPhase.Ended) break;

                if (touch.phase == TouchPhase.Moved)
                {
                    float mov = 0;
                    if (i == 0)
                    {
                        figure1 = touch.position;
                        move1 = touch.deltaPosition;
                    }

                    else
                    {
                        figure2 = touch.position;
                        move2 = touch.deltaPosition;

                        if (figure1.x > figure2.x) mov = move1.x;
                        else mov = move2.x;

                        if (figure1.y > figure2.y) mov += move1.y;
                        else mov += move2.y;

                        float newZ = transform.position.z + mov * Time.deltaTime * speed;
                        if (newZ > zMin && newZ < zMax)
                        {
                            Camera.main.transform.Translate(0, 0, mov * Time.deltaTime * speed);
                        }
                    }
                }

            }
        }


    }
}
