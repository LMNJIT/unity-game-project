using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EC3_BossHealth : MonoBehaviour
{
    public int difficultyModifier = 1; 
    public int Health = 600;
    public int damage = 50;
    public int EnemyVal;
    int curr;
    public GameObject Enemy;
    public GameObject BossSlain;
    public GameObject CampBlocker;
    public AudioSource EnemyHit;
    public TextMeshProUGUI Currency;

    void Start() {
        BossSlain.SetActive(false);
    }
    void Update() {
        // Destroys them if they die
        if (Health <= 0) {
            // Updates texts
            Currency.text = (curr+EnemyVal).ToString();
            BossSlain.SetActive(true);

            // Clears enemy objects and text object
            Destroy(BossSlain, 3);
            Destroy(Enemy);
            Destroy(CampBlocker);

            // Pauses game since they won
            Time.timeScale = 0;
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
