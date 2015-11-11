using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;




    Animator anim;
    PlayerHealth playerhealth;
    PlayerMovement playerMovement;
    AudioSource aud;
    NavMeshAgent nav;
    bool isDead;
    bool damaged;
    int damage;
    Image[] image;
    Image healthBar;




    void Awake()
    {
        image = GetComponentsInChildren<Image>();
        foreach (Image item in image)
        {
            if (item.name == "HealthReal")
            {
                healthBar = item;
            }
        }
        currentHealth = startingHealth;
        damage = 10;
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        playerhealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
        nav = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        damaged = false;

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

    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        playerMovement = this.GetComponent<PlayerMovement>();
        isDead = true;
        aud.Play();
        anim.SetTrigger("Die");
        anim.speed = 3.0f;
        nav.enabled = false;
        playerMovement.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("EnemyShot") && currentHealth > 0)
        {
            TakeDamage(damage);
            Destroy(other.gameObject);
        }
    }

      /* public void RestartLevel ()
        {
            Application.LoadLevel ();
        } */
}
