using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    public GameObject[] enemy;
    public Transform Target;

    private float attrackDistance = 10f;
    public float minDistance;
    //int a = int.MaxValue;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (GetNearestEnemy(enemy) != null)
        {
            Target = GetNearestEnemy(enemy).transform;
            this.transform.rotation = new Quaternion(0.0f, 270f, 0.0f, 0.0f);
            this.transform.LookAt(Target.position);
            //  this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.transform.position - Target.position),Time.deltaTime);
            this.transform.Rotate(0f, -90f, 0f);      
        }
    }

    void LateUpdate()
    {
        float curDistance;
        if (Target != null)
        {
            curDistance = Vector3.Distance(transform.position, Target.position);
            if (curDistance >= attrackDistance)
            {
                agent.SetDestination(Target.position);
                anim.Play("walk");
            }
        }
    }

    GameObject GetNearestEnemy(GameObject[] enemy)
    {
        float nearestDis = float.MaxValue;
        int length = enemy.Length;
        GameObject res = null;
        for (int i = 0; i < length; i++) {
            
            if (enemy[i].GetComponent<EnemyHealth>().currentHealth > 0 &&
               Vector3.Distance(enemy[i].transform.position, transform.position) < nearestDis)
                {
                    res = enemy[i];
                    nearestDis = Vector3.Distance(enemy[i].transform.position, transform.position);
                }  //Vector3.Distance)
        }
        return res;
    }
}