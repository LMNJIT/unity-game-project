using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateObject : MonoBehaviour {
    public float distance = 0f;
    float posX = -1f;
    float posY = -1f;
    float posZ = -1f;
    Rigidbody rb;
  //  public GameObject cylinder;

    // https://docs.unity3d.com/560/Documentation/ScriptReference/UI.Slider-value.html
    // https://pastebin.com/5fhPHtYa
    // altered so it constantly updates the object which displays the current color,
    // only places objects if within a certain limit of the mousePosition,
    // changes shape depending on dropdown chosen,
    // and changes colors depending on sliders
    void Update() {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) {
                    posX = -1f;
                    posY = -1f;
                    posZ = -1f;
                    Vector3 clickPosition = new Vector3(posX, posY, posZ);
                    clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distance));
                    GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                    cylinder.tag = "Primitive";
                // rb.velocity = new Vector3(1, rb.velocity.y, rb.velocity.z);
                    cylinder.transform.position = clickPosition;
                }
            }
}      

