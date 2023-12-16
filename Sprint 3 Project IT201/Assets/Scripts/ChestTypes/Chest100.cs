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
    public GameObject ChestText;
    public GameObject FloatingText;
    public GameObject FloatingTextInstance;
    public AudioSource ChestOpen;
    // Instances below created in order to reference variables across scripts
    public CreateObject referenceArrow;
    public HealthTracker referenceHealth;
    public FirstPersonController FPS;
    public int chestVal;
    void Start() {
        // Instantaite text within the game which floats above the Chest GameObject,
        // and rotate said text so it faces the same way the Chest GameObject is facing
        // Also sets the text which will display when the chest is interacted with inactive
        Vector3 aboveChestPosition = Chest.position + new Vector3(0f, 2f, 0); 
        FloatingTextInstance = Instantiate(FloatingText, aboveChestPosition, Quaternion.identity);
        FloatingTextInstance.transform.rotation = Chest.rotation * Quaternion.Euler(0,180,0);
        ChestText.SetActive(false);
    }

    void Update() {
        // Checks if the player is within proper distance of the chest, and also checks for key press as well as if 
        // the player has enough currency to use the chest
        if (Vector3.Distance(Player.position, Chest.position) < 10 && Input.GetKeyDown(KeyCode.E) && Int16.Parse(Currency.text) >= chestVal) {
            // Change currency according to the value of the chest
            Currency.text = (Int16.Parse(Currency.text) - chestVal).ToString();

            // Increase health, arrow attack speed, player speed and jump height
            referenceHealth.Health += 50;
            referenceArrow.arrowSpeed -= .05f;
            FPS.JumpHeight += 1f;
            FPS.MoveSpeed += 1f;
            FPS.SprintSpeed += 1f;

            // Play chest opening audio + pop the text onto the screen
            ChestText.SetActive(true);
            ChestOpen.Play();

            // Remove chest object and floating text from the screen, and then remove the new text pop up 
            // quickly after it's popup 
            Destroy(ChestObject);
            Destroy(FloatingTextInstance);
            Destroy(ChestText, 3);
        }
    }
}