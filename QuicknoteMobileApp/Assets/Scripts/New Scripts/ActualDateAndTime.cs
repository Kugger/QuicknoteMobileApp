using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualDateAndTime : MonoBehaviour
{
    public Text dataAndTimeText;

    public string ADATday, ADATmonth, ADATyear, ADATfullyear, ADAThour, ADATminute, ADATseconds;

    public void Update()
    {
        var presentDateAndTime = System.DateTime.Now.ToLocalTime();

        ADATday = presentDateAndTime.ToString("dd");
        ADATmonth = presentDateAndTime.ToString("MM");
        ADATyear = presentDateAndTime.ToString("yy");
        ADATfullyear = presentDateAndTime.ToString("yyyy");
        ADAThour = presentDateAndTime.ToString("HH");
        ADATminute = presentDateAndTime.ToString("mm");
        ADATseconds = presentDateAndTime.ToString("ss");

        dataAndTimeText.text = "Today is " + ADATday + "-" + ADATmonth + "-" + ADATyear +
             " | " + ADAThour + ":" + ADATminute + ":" + ADATseconds;
    }
}
