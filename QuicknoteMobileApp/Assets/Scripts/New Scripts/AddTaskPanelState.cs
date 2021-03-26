using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTaskPanelState : MonoBehaviour
{
    public GameObject ActualDateAndTimeScript;
    ActualDateAndTime presentDateAndTime;

    public GameObject TaskManagerScript;
    CreateTask minValues;

    public Text dayText, monthText, yearText, hourText, minuteText;

    public InputField TitleField, DescriptionField;

    public void OnEnable()
    {
        presentDateAndTime = ActualDateAndTimeScript.GetComponent<ActualDateAndTime>();

        dayText.text = presentDateAndTime.ADATday;
        monthText.text = presentDateAndTime.ADATmonth;
        yearText.text = presentDateAndTime.ADATfullyear;
        hourText.text = presentDateAndTime.ADAThour;
        minuteText.text = presentDateAndTime.ADATminute;

        minValues = TaskManagerScript.GetComponent<CreateTask>();

        minValues.minDay = int.Parse(presentDateAndTime.ADATday);
        minValues.minMonth = int.Parse(presentDateAndTime.ADATmonth);
        minValues.minYear = int.Parse(presentDateAndTime.ADATfullyear);
        minValues.minHour = int.Parse(presentDateAndTime.ADAThour);
        minValues.minMinute = int.Parse(presentDateAndTime.ADATminute);
    }
}
