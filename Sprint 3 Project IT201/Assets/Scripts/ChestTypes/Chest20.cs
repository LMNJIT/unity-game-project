using System;
using TMPro;
using UnityEngine;

public class Chest20 : MonoBehaviour
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
    public int chestVal;
    void Start() {
        // Instantaite text within the game which floats above the Chest GameObject,
        // and rotate said text so it faces the same way the Chest GameObject is facing
        // Also sets the text which will display when the chest is interacted with inactive
        Vector3 aboveChestPosition = Chest.position + new Vector3(.5f, 1.5f, 0);
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

            // Increase arrow attack speed
            referenceArrow.arrowSpeed -= .025f;

            // Play chest opening audio + pop the text onto the screen
            ChestOpen.Play();
            ChestText.SetActive(true);

            // Remove chest object and floating text from the screen, and then remove the new text pop up 
            // quickly after it's popup 
            Destroy(ChestObject);
            Destroy(FloatingTextInstance);
            Destroy(ChestText, 3);
        }
    }
}