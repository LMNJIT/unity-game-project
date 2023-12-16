using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthTracker : MonoBehaviour
{
    public int Health = 100;
    public int damage;
    public GameObject Enemy;
    public AudioSource EnemyHit;

    void Update() {
        // If the enemy's health reaches 0, they are DESTROYED!!!
        if (Health <= 0) {
            Destroy(Enemy);
        }
    }

    void OnTriggerEnter (Collider other) {
        // Checks that the tag of the object colliding with them is, in fact, an arrow
        // Then it decrements their health by the set damage value and plays audio
        if (other.gameObject.tag == "Arrow") {
            Health -= damage;
            EnemyHit.Play();
        }
    }
}
