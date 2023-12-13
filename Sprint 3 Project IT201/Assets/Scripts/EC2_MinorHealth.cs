using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EC2_MinorHealth : MonoBehaviour
{
    public int Health = 100;
    public int damage = 20;
    public GameObject Enemy;
    public AudioSource EnemyHit;

    void Update() {
        if (Health <= 0) {
            Destroy(Enemy);
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Arrow") {
            Health -= damage;
            EnemyHit.Play();
        }
    }
}
