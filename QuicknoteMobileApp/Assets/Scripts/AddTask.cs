using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddTask : MonoBehaviour
{
    public Dropdown category, type, year, month, day, colour;

    public InputField descripiton;

    string sCategory, sType, sYear, sMonth, sDay, sColour;

    public void createButtonPressed() 
    {
        sCategory = category.options[category.value].text;
        sType = type.options[type.value].text;
        sYear = year.options[year.value].text;
        sMonth = month.options[month.value].text;
        sDay = day.options[day.value].text;
        sColour = colour.options[colour.value].text;

        Debug.Log(sCategory + " " + sType + " " + sYear + " " + sMonth + " " + sDay + " " + sColour);
        Debug.Log(descripiton);
    }
}
