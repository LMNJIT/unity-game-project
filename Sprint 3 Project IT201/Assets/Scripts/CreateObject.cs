using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateObject : MonoBehaviour
{
    public float distance = 0f;
    public GameObject arrow1;
    public AudioSource arrowNoise;
    public float lastArrowTime = .5f;
    void Update()
    {
        if ((Time.time - lastArrowTime) >= .5f && (Input.GetMouseButton(0) || Input.GetMouseButton(1)))
        {
            arrowNoise.Play();
            
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, distance);

            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(screenCenter);

            InstantiateArrow(clickPosition);
            lastArrowTime = Time.time;
        }
    }

    void InstantiateArrow(Vector3 position)
    {
        // Instantiate arrow with rotation based on the camera's forward direction
        GameObject arrow = Instantiate(arrow1, position, Camera.main.transform.rotation);
        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();

        arrowRb.velocity = Camera.main.transform.forward * 40f;
        arrowRb.useGravity = true;

        Destroy(arrow, 5);
    }
}
