using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public int Health = 90;
    public int damage;
    public GameObject LossText;
    public TextMeshProUGUI HealthText;
    public AudioSource PlayerHit;
    void Start() {
        // Self explanatory
        LossText.SetActive(false);
        HealthText.color = Color.green;
    }

    void Update() {
        // Pause the game and tell the player they lost if health reaches 0
        if (Health <= 0) {
            Time.timeScale = 0;
            LossText.SetActive(true);
            HealthText.color = Color.red;
        }

        // Self explanatory
        if (Health <= 50) {
            HealthText.color = Color.yellow;
        }

        // Set health text
        HealthText.text = "Health: " + Health.ToString();
    }

    void OnTriggerEnter (Collider other) {
        // Checks what types of enemy it is and decrements player health accordingly
        if (other.gameObject.tag == "Minor") {
            Health -= 10;
            PlayerHit.Play();
        }
        else if (other.gameObject.tag == "Major") {
            Health -= 20;
            PlayerHit.Play();
        }
        else if (other.gameObject.tag == "Boss") {
            Health -= 40;
            PlayerHit.Play();
        }
    }
}
