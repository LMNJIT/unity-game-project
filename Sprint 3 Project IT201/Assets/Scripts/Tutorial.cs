using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject TutorialText1;
    public GameObject TutorialText2;
    public GameObject TutorialText3;
    public Transform Particle1;
    public Transform Particle2;
    public Transform Particle3;
    public Transform Player;
    void Start() {
        TutorialText1.SetActive(false);
        TutorialText2.SetActive(false);
        TutorialText3.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        TutorialText1.SetActive(false);
        TutorialText2.SetActive(false);
        TutorialText3.SetActive(false);
        if (Vector3.Distance(Player.position,Particle1.position) < 5) {
            TutorialText1.SetActive(true);
        }
        if (Vector3.Distance(Player.position,Particle2.position) < 5) {
            TutorialText2.SetActive(true);
        }
        if (Vector3.Distance(Player.position,Particle3.position) < 5) {
            TutorialText3.SetActive(true);
        }
    }
}
