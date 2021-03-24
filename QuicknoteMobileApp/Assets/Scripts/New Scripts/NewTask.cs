using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTask : MonoBehaviour
{
    public string objTitle;
    public string objDescription;
    public string objDay;
    public string objMonth;
    public string objYear;
    public string objHour;
    public string objMinute;
    public int objIndex;
    public Color objColor;

    private Text[] itemTexts;
    private Image itemImage;

    void Start()
    {
        itemTexts = GetComponentsInChildren<Text>();
        itemImage = GetComponentInChildren<Image>();

        if (objDay.Length == 1)
            objDay = '0' + objDay;

        if (objMonth.Length == 1)
            objMonth = '0' + objMonth;

        if (objHour.Length == 1)
            objHour = '0' + objHour;

        if (objMinute.Length == 1)
            objMinute = '0' + objMinute;

        itemTexts[0].text = objTitle;
        itemTexts[1].text = objDescription;
        itemTexts[2].text = objDay + "-" + objMonth + "-" + objYear + "   " + objHour + ":" + objMinute;
        //itemTexts[3].text = objIndex.ToString();
        itemImage.color = objColor;
    }

    public void SetObjectInfo(string title, string desc, Color color, string day, string month, string year, string hour, string minute, int index)
    {
        this.objTitle = title;
        this.objDescription = desc;
        this.objColor = color;
        this.objIndex = index;

        this.objDay = day;
        this.objMonth = month;
        this.objYear = year;
        this.objHour = hour;
        this.objMinute = minute;
    }
}
