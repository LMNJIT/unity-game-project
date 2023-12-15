using System;
using StarterAssets;
using TMPro;
using UnityEngine;

public class Chest100 : MonoBehaviour
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
    public FirstPersonController FPS;
    public GameObject ChestText;
    public int chestVal;
    void Start() {
        Vector3 aboveChestPosition = Chest.position + new Vector3(0f, 2f, 0); // Adjust the Y value as needed
        FloatingTextInstance = Instantiate(FloatingText, aboveChestPosition, Quaternion.identity);

        // Set the rotation of the floating text to face the same direction as the chest
        FloatingTextInstance.transform.rotation = Chest.rotation * Quaternion.Euler(0,180,0);
        ChestText.SetActive(false);
    }

    void Update() {
        if (Vector3.Distance(Player.position, Chest.position) < 10 && Input.GetKeyDown(KeyCode.E) && Int16.Parse(Currency.text) >= chestVal) {
            Currency.text = (Int16.Parse(Currency.text) - chestVal).ToString();
            ChestOpen.Play();
            referenceHealth.Health += 50;
            referenceArrow.arrowSpeed -= .05f;
            FPS.JumpHeight += 1f;
            FPS.MoveSpeed += 1f;
            FPS.SprintSpeed += 1f;
            Destroy(ChestObject);
            Destroy(FloatingTextInstance);
            ChestText.SetActive(true);
            Destroy(ChestText, 3);
        }
    }
}