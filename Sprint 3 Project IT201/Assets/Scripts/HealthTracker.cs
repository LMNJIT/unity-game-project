using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public int Health = 100;
    public GameObject LossText;
    void Start()
    {
        LossText.SetActive(false);
    }

    void Update()
    {
        if (Health <= 0) {
            Time.timeScale = 0;
            LossText.SetActive(true);
        }
    }

    void OnCollisionEnter (Collision other) {
        if (other.gameObject.CompareTag("Player"))
            Health = Health - 10;
    }
}
