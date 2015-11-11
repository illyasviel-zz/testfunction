using UnityEngine;
using System.Collections;

public class Attrack : MonoBehaviour {

    PlayerHealth playerHealth;
    GameObject player;
    int damage;

    void Awake() {
        damage = 10;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) playerHealth = player.GetComponent<PlayerHealth>();
    } 

    void Update() {
        if (player != null && playerHealth.currentHealth > 0)
        {
            return;
        }
        else {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) playerHealth = player.GetComponent<PlayerHealth>();
        }
    }
    // Update is called once per frame
	void OntriggerEnter (Collider other) {
        if (other.gameObject == player && playerHealth.currentHealth > 0) {
            playerHealth.TakeDamage(damage);
            Destroy(this.gameObject);
        }
	}
}
