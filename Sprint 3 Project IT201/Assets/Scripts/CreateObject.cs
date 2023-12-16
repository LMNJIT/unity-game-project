using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateObject : MonoBehaviour
{
    public GameObject arrow1;
    public AudioSource arrowNoise;
    public float distance = 0f;
    public float lastArrowTime = .5f;
    public float arrowSpeed;
    void Update() {
        // Check that enough time has passed since last time an arrow has been shot
        // and check for mouse press
        if ((Time.time - lastArrowTime) >= arrowSpeed && (Input.GetMouseButton(0) || Input.GetMouseButton(1))) {
            arrowNoise.Play();
            
            // Create a vector3 to represent the center of the player's screen
            // in order to create a loaction for the arrow prefab to instantiate at
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, distance);
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(screenCenter);
            InstantiateArrow(clickPosition);

            // Track time
            lastArrowTime = Time.time;
        }
    }

    void InstantiateArrow(Vector3 position) {
        // Instantiate arrow with rotation based on the camera's forward direction
        GameObject arrow = Instantiate(arrow1, position, Camera.main.transform.rotation);
        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();
        arrowRb.velocity = Camera.main.transform.forward * 40f;
        arrowRb.useGravity = true;

        // Destroy the arrow after a period of 5 seconds
        Destroy(arrow, 5);
    }
}
