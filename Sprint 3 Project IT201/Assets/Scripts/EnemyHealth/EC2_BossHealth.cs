using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EC2_BossHealth : MonoBehaviour
{
    public int difficultyModifier = 1; 
    public int Health = 450;
    public int damage = 50;
    public int EnemyVal;
    int curr;
    public GameObject Enemy;
    public GameObject ChestText;
    public GameObject BossSlain;
    public GameObject CampBlocker;
    public AudioSource EnemyHit;
    public TextMeshProUGUI Currency;
    public HealthTracker referenceHealth;
    public CreateObject referenceArrow;

    void Start() {
        BossSlain.SetActive(false);
        ChestText.SetActive(false);
    }
    void Update() {
        // Destroys them if they die and updates currency
        if (Health <= 0) {
            Currency.text = (curr+EnemyVal).ToString();

            // Sets appropiate texts active
            BossSlain.SetActive(true);
            ChestText.SetActive(true);

            // Clear out objects to signify death
            Destroy(BossSlain, 3);
            Destroy(Enemy);
            Destroy(CampBlocker);
            Destroy(ChestText, 3);

            // Increase player health and attack speed
            referenceHealth.Health += 50;
            referenceArrow.arrowSpeed -= .05f;
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
