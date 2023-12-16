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
    int curr;
    public GameObject Pet;
    public AudioSource PetHit;

    void Update() {
        // Destroys them if they die 
        if (Health <= 0) {
            Destroy(Pet);
        }
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
