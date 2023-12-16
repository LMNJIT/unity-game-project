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
        // Checks that they're being shot by an arrow
        if (other.gameObject.tag == "Arrow") {
            Health -= damage;
            EnemyHit.Play();
        }
    }
}
