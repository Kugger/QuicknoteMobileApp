using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataTest : MonoBehaviour
{
    public Text dataText;

    void Update()
    {
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy   HH:mm");

        dataText.text = "Today is " + time;
    }
}
