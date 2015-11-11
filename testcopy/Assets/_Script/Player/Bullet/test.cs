using UnityEngine;  
using System.Collections;  

public class test : MonoBehaviour  
{  
	Transform target;
    GameObject[] player;
    PlayerMovement playerMovement;
	public float speed = 10;  
	private float distanceToTarget;  
	private bool move = true;
    public int damagePerShoot = 10;

    void Awake() {
        player = GameObject.FindGameObjectsWithTag("Player");
        playerMovement =getTarget(player).GetComponent<PlayerMovement>();
    }

    void Start ()  
	{
        if (playerMovement!= null)
        target = playerMovement.Target;
        if (target != null)
        {
            distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
            StartCoroutine(Shoot());
        }
	}  
	IEnumerator Shoot ()  
	{
        while (move) {
                Vector3 targetPos = target.transform.position;
                this.transform.LookAt(targetPos);
                float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 45;
                this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
                float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
                if (currentDist < 0.5f) move = false;
                this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
                yield return null;
           
		}  
	}

    GameObject getTarget(GameObject[] player) {
        int length = player.Length;
        GameObject res = null;
        float dis = 0;
        for(int i = 0; i < length; i++)
        {
            if (player[i] != null)
            {
                res = player[i];
                dis = Vector3.Distance(transform.position, player[i].transform.position);
                break;
            }
                
        }
        if (res == null) return res;
        for (int i = 0; i < length; i++) {
            if (player[i] != null && player[i].GetComponent<PlayerHealth>().currentHealth > 0
              && Vector3.Distance(transform.position, player[i].transform.position) <= dis)
            {
                dis = Vector3.Distance(transform.position, player[i].transform.position);
                res = player[i];
            }
        }
            return res;
    }
}