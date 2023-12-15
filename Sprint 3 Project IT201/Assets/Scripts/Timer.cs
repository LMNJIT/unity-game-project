using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject loss;
    public TextMeshProUGUI lossText;
    public float time = 600;
    /*public EC1_BossHealth referenceEC1B;
    public EC1_MinorHealth referenceEC1Mi;
    public EC1_MajorHealth referenceEC1Ma;
    public EC2_BossHealth referenceEC2B;
    public EC2_MinorHealth referenceEC2Mi;
    public EC2_MajorHealth referenceEC2Ma;
    public EC3_BossHealth referenceEC3B;
    public EC3_MinorHealth referenceEC3Mi;
    public EC3_MajorHealth referenceEC3Ma;*/
    // etc
    // Update is called once per frame
    void Update() {
        if (Time.timeScale > 0f) {
            timerText.text = "Timer: " + Math.Ceiling(time).ToString();

            time -= Time.deltaTime;

            if (time <= 0) {
                timerText.text = "Timer: 0";
                timerText.color = Color.black;
                Time.timeScale = 0f;
                lossText.text = "You lose!";
                loss.SetActive(true);
            }

            if (time < 150) {
                timerText.color = Color.red;
            }

            if (time > 300) {
                timerText.color = Color.yellow;
            }

            if (time > 450) {
                timerText.color = Color.green;
            }
        }
    }
}
