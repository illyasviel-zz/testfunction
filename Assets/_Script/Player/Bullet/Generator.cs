using UnityEngine;

public class Generator : MonoBehaviour
{

     public GameObject test;
     public GameObject weapon2;
     int weaponLevel = 1;
     //  private float distanceToTarget;
     private GameObject player;
     AudioSource aud;
     //    private bool move = true;
     Transform target;


     private float timer;

     public float timeBetweenBullets = 2f;
     public float range = 10f;
     // Use this for initialization
     void Start()
     {
         timer = Time.time;
         aud = GetComponent<AudioSource>();
     }

     // Update is called once per frame
     void LateUpdate()
     {

         float currentDistance;
         // if (player.GetComponent<PlayerMovement>().attacker != null)

         if (GetComponentInParent<PlayerMovement>().Target != null)
         {
             target = GetComponentInParent<PlayerMovement>().Target;
             //timer = Time.time;
             //  if(target)
             currentDistance = Vector3.Distance(target.transform.position, transform.position);

             if (target.GetComponent<EnemyHealth>().currentHealth > 0 && currentDistance <= range
                 && Time.time >= timer && Time.timeScale != 0 && GetComponentInParent<PlayerHealth>().currentHealth > 0)
             {
                 GetComponentInParent<Animator>().Play("attack");
                //GetComponentInParent<Animator>().speed = 3.0f; 
                if (weaponLevel == 1)
                {
                    Instantiate(test, this.transform.position, this.transform.rotation);
                }
                else if(weaponLevel == 2)
                {
                    Instantiate(weapon2, this.transform.position, this.transform.rotation);
                }
                 timer = Time.time + timeBetweenBullets;
                 aud.Play();
             }
         }
     }
 }

   /*  IEnumerator Shoot()
     {
         while (move)
         {
             Vector3 targe   tPos = target.transform.position;
             test.transform.LookAt(targetPos);
             float angle = Mathf.Min(1, Vector3.Distance(test.transform.position, targetPos) / distanceToTarget) * 45;
             this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
             float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
             if (currentDist < 0.5f) move = false;
             this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
             yield return null;

         }
     }*/

//}
