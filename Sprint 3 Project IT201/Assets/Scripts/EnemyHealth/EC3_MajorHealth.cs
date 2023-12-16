using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EC3_MajorHealth : MonoBehaviour
{
    public int difficultyModifier = 1; 
    public int Health = 200;
    public int damage = 50;
    public int EnemyVal;
    int curr;
    public GameObject Enemy;
    public AudioSource EnemyHit;
    public TextMeshProUGUI Currency;

    void Update() {
        // Destroys them if they die and updates currency
        if (Health <= 0) {
            Currency.text = (curr+EnemyVal).ToString();
            Destroy(Enemy);
        }
        curr = int.Parse(Currency.text);
    }

    void OnTriggerEnter (Collider other) {
        // Check that they are being shot by an arrow or attacked by pet
        if (other.gameObject.tag == "Arrow") {
            Health -= damage;
            EnemyHit.Play();
        }
    }
}
