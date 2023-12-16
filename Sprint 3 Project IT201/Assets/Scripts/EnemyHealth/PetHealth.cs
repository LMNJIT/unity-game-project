using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetHealth : MonoBehaviour
{
    public int difficultyModifier = 1; 
    public int Health = 600;
    public int damage = 20;
    int curr;
    public GameObject Pet;
    public AudioSource PetHit;
    public TextMeshProUGUI Currency;

    void Update() {
        // Destroys them if they die and updates currency
        if (Health <= 0) {
            Destroy(Pet);
        }
        curr = int.Parse(Currency.text);
    }

    void OnTriggerEnter (Collider other) {
        // Checks what types of enemy it is and decrements player health accordingly
        if (other.gameObject.tag == "Minor") {
            Health -= 10;
            PetHit.Play();
        }
        else if (other.gameObject.tag == "Major") {
            Health -= 20;
            PetHit.Play();
        }
        else if (other.gameObject.tag == "Boss") {
            Health -= 40;
            PetHit.Play();
        }
    }
}
