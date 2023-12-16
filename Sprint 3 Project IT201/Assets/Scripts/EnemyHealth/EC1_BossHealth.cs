using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EC1_BossHealth : MonoBehaviour
{
    public int difficultyModifier = 1; 
    public int Health = 300;
    public int damage = 40;
    public int EnemyVal;
    int curr;
    public GameObject Enemy;
    public GameObject BossSlain;
    public GameObject CampBlocker;
    public GameObject ChestText;
    public GameObject TP;
    public AudioSource EnemyHit;
    public TextMeshProUGUI Currency;
    public Transform playerFollow;
    public Transform playerCapsule;
    public Transform MainCamera;
    public HealthTracker referenceHealth;
    public CreateObject referenceArrow;

    void Start() {
        BossSlain.SetActive(false);
        ChestText.SetActive(false);
    }
    void Update() {
        if (Health <= 0) {
            // Increase currency
            Currency.text = (curr+EnemyVal).ToString();

            BossSlain.SetActive(true);

            // Increase player health + arrow attack speed
            referenceHealth.Health += 50;
            referenceArrow.arrowSpeed -= .05f;

            // Text pop up
            ChestText.SetActive(true);
            BossSlain.SetActive(true);

            // Destroy texts after set time + destroy the enemy object
            Destroy(ChestText, 3);
            Destroy(BossSlain, 3);
            Destroy(Enemy);
            Destroy(CampBlocker);
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
