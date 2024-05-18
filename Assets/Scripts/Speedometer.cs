using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{
    public TMP_Text speedText;
    public Car_Controller carController;
    // Update is called once per frame
    void Update()
    {
        int speed = Mathf.RoundToInt(GetCarSpeed()); // Rotunjim viteza la întreg
        speedText.text =  speed + " km/h";
    }

    float GetCarSpeed()
    {
        float carSpeed = carController.Car_Speed_KPH;

        
        return carSpeed; 
    }
}