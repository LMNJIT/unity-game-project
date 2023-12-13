using System;
using TMPro;
using UnityEngine;

public class BasicChest : MonoBehaviour
{
    public TextMeshProUGUI Currency;
    public Transform Player;
    public Transform Chest;
    public GameObject ChestObject;
    public GameObject FloatingText;
    public GameObject FloatingTextInstance;
    public AudioSource ChestOpen;
    public CreateObject referenceArrow;
    public HealthTracker referenceHealth;

    void Start() {
       FloatingTextInstance = Instantiate(FloatingText, transform.position, Quaternion.identity);
    }

    void Update() {
        if (Vector3.Distance(Player.position, Chest.position) < 10 && Input.GetKeyDown(KeyCode.E) && Int16.Parse(Currency.text) >= 5) {
            Currency.text = (Int16.Parse(Currency.text) - 5).ToString();
            ChestOpen.Play();
            referenceHealth.Health = 100;
            Destroy(ChestObject);
            Destroy(FloatingTextInstance);
        }
    }
}