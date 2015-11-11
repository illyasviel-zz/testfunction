using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform player;
    //public GameObject Camera;
    Vector3 offSet;
    public float smoothing = 5f;
	
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 pos = new Vector3(player.position.x + 1, player.position.y + 15, player.position.z - 22);
        Quaternion Dir = player.rotation;
        offSet = transform.position - player.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = player.position + offSet;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}