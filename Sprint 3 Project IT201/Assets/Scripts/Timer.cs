using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lossText;
    public TextMeshProUGUI currText;
    public TextMeshProUGUI currCurrText;
    public GameObject loss;
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

    void Update() {
        // Checks that the game isn't paused
        if (Time.timeScale > 0f) {
            // Sets timer text
            timerText.text = "Timer: " + Math.Ceiling(time).ToString();

            // Decrements the time
            time -= Time.deltaTime;

            // Pauses the game and tells the player they lost if time runs out (and changes colors)
            if (time <= 0) {
                timerText.text = "Timer: 0";
                timerText.color = Color.black;
                //currText.color = Color.black;
                //currCurrText.color = Color.black;
                Time.timeScale = 0f;
                lossText.text = "You lose!";
                loss.SetActive(true);
            }

            // Self explantory...
            if (time < 150) {
                timerText.color = Color.red;
                //currText.color = Color.red;
                //currCurrText.color = Color.red;
            }

            if (time > 300) {
                timerText.color = Color.yellow;
                //currText.color = Color.yellow;
                //currCurrText.color = Color.yellow;
            }

            if (time > 450) {
                timerText.color = Color.green;
                currText.color = Color.green;
                currCurrText.color = Color.green;
            }
        }
    }
}
