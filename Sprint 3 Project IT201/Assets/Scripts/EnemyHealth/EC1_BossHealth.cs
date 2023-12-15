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
    public GameObject Enemy;
    public AudioSource EnemyHit;
    public TextMeshProUGUI Currency;
    public int EnemyVal;
    int curr;
    public GameObject BossSlain;
    public GameObject CampBlocker;

    void Start() {
        BossSlain.SetActive(false);
    }
    void Update() {
        if (Health <= 0) {
            Currency.text = (curr+EnemyVal).ToString();
            BossSlain.SetActive(true);
            Destroy(BossSlain, 10);
            Destroy(Enemy);
            Destroy(CampBlocker);
        }
        curr = int.Parse(Currency.text);
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Arrow") {
            Health -= damage;
            EnemyHit.Play();
        }
    }
}
