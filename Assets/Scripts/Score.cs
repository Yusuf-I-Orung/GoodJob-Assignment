using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public SpawnHair hairControllerH;
    public SpawnHair hairControllerL;
    private int hairNumber = -1;
    public ArmAnimController ArmAnimController;

    // Update is called once per frame
    void Update()
    {
        hairNumber = hairControllerH.Hairs.Count + hairControllerL.Hairs.Count;
        scoreText.text = "Hair left: " + hairNumber;
        if (hairNumber == 0)
        {
            ArmAnimController.state = "clean";
        }
    }

}
