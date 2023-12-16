using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EC2_MinorHealth : MonoBehaviour
{
    public int difficultyModifier = 1; 
    public int Health = 100;
    public int damage = 20;
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
        if (other.gameObject.tag == "Arrow" || other.gameObject.tag == "Pet") {
            Health -= damage;
            EnemyHit.Play();
        }
    }
}
