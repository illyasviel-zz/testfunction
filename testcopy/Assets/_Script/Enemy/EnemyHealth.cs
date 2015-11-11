using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    //public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public int damage;
    public float timeBetweenAttracks = 0.5f;
  //  public GameObject explosionPrefab;


    Animator anim;
    AudioSource enemyAudio;
    CapsuleCollider capsuleCollider;
    SphereCollider spherecollider;
    Image[] image;
    Image healthBar;

    bool isDead;
    bool damaged;
    bool isSinking;


    void Start()
    {
        image = GetComponentsInChildren<Image>();
        foreach (Image item in image)
        {
            if (item.name == "EnemyHealthReal")
            {
                healthBar = item;
            }
        }

        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        spherecollider = GetComponent<SphereCollider>();
        currentHealth = startingHealth;
        damage = 10;
        enemyAudio = GetComponent<AudioSource>();
    }


 /*   void Update()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }

        if (currentHealth >= 50 && currentHealth <= 100)
        {
            healthBar.color = Color.green;
            healthBar.fillAmount = (float)currentHealth / (float)startingHealth;
        }

        if (currentHealth < 50 && currentHealth >= 30)
        {
            healthBar.color = Color.yellow;
            healthBar.fillAmount = (float)currentHealth / (float)startingHealth;
        }

        if (currentHealth < 30 && currentHealth >= 0)
        {
            healthBar.color = Color.red;
            healthBar.fillAmount = (float)currentHealth / (float)startingHealth;
        }

        if (currentHealth == 0)
        {
            healthBar.fillAmount = 0.0f;
        }

    } */

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            //  GameObject hitEffect = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            TakeDamage(10);
            if (currentHealth >= 50 && currentHealth <= 100)
            {
                healthBar.color = Color.green;
                healthBar.fillAmount = (float)currentHealth / (float)startingHealth;
            }

            if (currentHealth < 50 && currentHealth >= 30)
            {
                healthBar.color = Color.yellow;
                healthBar.fillAmount = (float)currentHealth / (float)startingHealth;
            }

            if (currentHealth < 30 && currentHealth >  0)
            {
                healthBar.color = Color.red;
                healthBar.fillAmount = (float)currentHealth / (float)startingHealth;
            }

            if (currentHealth <= 0)
            {
                healthBar.fillAmount = 0.0f;
            }
        }
    }


    public void TakeDamage(int amount)
    {
        /*if(isDead)
            return;
		*/
        damaged = true;

        currentHealth -= amount;

        if (currentHealth == 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        spherecollider.enabled = false;
        capsuleCollider.enabled = false;

      //  capsuleCollider.isTrigger = true;
       

     //   enemyAudio.Play();

        anim.SetTrigger("Dead");
    }


    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        //  Destroy (gameObject, 2f);
    }
}
