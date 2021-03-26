using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public Text UnfinishedTaskValueText;
    public Text FinishedTaskValueText;
    public Text DeletedTaskValueText;

    int maxDoneValue;
    int maxDeletedValue;

    public Slider levelSlider;
    public Text nowLevel;
    public Text nextLevel;

    public GameObject DisplayInfoPanel;
    public Text displayText;
    public Button displayButton;

    bool displayed;
    bool displayed1;
    bool displayed2;
    bool displayed3;
    bool displayed4;

    public int intDay;
    public int intMonth;
    public int intOldMonth;
    public int intNewMonth;
    public int intOldYear;
    public int intNewYear;

    public GameObject ActualDateAndTimeScript;
    ActualDateAndTime presentDateAndTime;

    public int monthIntInfoNow;
    public int monthIntInfoPast;

    public int yearIntInfoNow;
    public int yearIntInfoPast;

    public int dif1, dif2;

    public Button encoji1;
    public Button encoji2;
    public Button encoji3;
    public Button encoji4;

    void Start()
    {
        var presentDateAndTime = System.DateTime.Now.ToLocalTime();

        intDay = int.Parse(presentDateAndTime.ToString("dd"));
        intMonth = int.Parse(presentDateAndTime.ToString("MM"));
        intOldMonth = int.Parse(presentDateAndTime.ToString("MM"));

        int tempMonth = int.Parse(presentDateAndTime.ToString("MM"));

        if (tempMonth < 12)
            intNewMonth = tempMonth + 1;
        else if (tempMonth == 12)
            intNewMonth = 1;

        intOldYear = int.Parse(presentDateAndTime.ToString("yyyy"));
        intNewYear = intOldYear + 1;

        /* do testow
        intDay = 1;
        intMonth = 1;
        intOldMonth = 1;
        intNewMonth = 1;
        */
    }

    // Update is called once per frame
    void Update()
    {
        int unifinishedTasksAmonut = PlayerPrefs.GetInt("unifinishedTasksAmonut");
        UnfinishedTaskValueText.text = unifinishedTasksAmonut.ToString();

        PlayerPrefs.SetInt("maxDoneValue", int.Parse(FinishedTaskValueText.text));
        //PlayerPrefs.SetInt("maxDoneValue", -1);
        maxDoneValue = PlayerPrefs.GetInt("doneValueAdd");
        FinishedTaskValueText.text = maxDoneValue.ToString();

        PlayerPrefs.SetInt("maxDeletedValue", int.Parse(DeletedTaskValueText.text));
        //PlayerPrefs.SetInt("maxDeletedValue", -1);
        maxDeletedValue = PlayerPrefs.GetInt("deletedValueAdd");
        DeletedTaskValueText.text = maxDeletedValue.ToString();

        //intDisplayed = PlayerPrefs.GetInt("intDisplayed");


        if (maxDoneValue < 10)
        {
            nowLevel.text = "1";
            nextLevel.text = "2";
            levelSlider.maxValue = 10;
            levelSlider.value = maxDoneValue;

            encoji2.interactable = false;
            encoji3.interactable = false;
            encoji4.interactable = false;
        }
        else if (maxDoneValue > 10 & maxDoneValue < 25 & displayed == false)
        {
            nowLevel.text = "2";
            nextLevel.text = "3";
            levelSlider.maxValue = 25;
            levelSlider.value = maxDoneValue;

            if (displayed == false)
            {
                DisplayInfoPanel.SetActive(true);
                displayed = true;
                displayText.text = "Now you are 2nd level! Congratulations! You unlocked new Encoji!";
                displayButton.onClick.AddListener(hideDisplayInfo);
            }

            encoji2.interactable = true;
            encoji3.interactable = false;
            encoji4.interactable = false;
        }
        else if (maxDoneValue > 25 & maxDoneValue < 50 & displayed1 == false)
        {
            nowLevel.text = "3";
            nextLevel.text = "4";
            levelSlider.maxValue = 50;
            levelSlider.value = maxDoneValue;

            if (displayed1 == false)
            {
                DisplayInfoPanel.SetActive(true);
                displayed1 = true;
                displayText.text = "Now you are 3rd level! Congratulations! You unlocked new Encoji!";
                displayButton.onClick.AddListener(hideDisplayInfo);
            }

            encoji3.interactable = true;
            encoji4.interactable = false;
        }
        else if (maxDoneValue > 50 & maxDoneValue < 100 & displayed2 == false)
        {
            nowLevel.text = "4";
            nextLevel.text = "5";
            levelSlider.maxValue = 100;
            levelSlider.value = maxDoneValue;

            if (displayed2 == false)
            {
                DisplayInfoPanel.SetActive(true);
                displayed2 = true;
                displayText.text = "Now you are 4th level! Congratulations! You unlocked new Encoji!";
                displayButton.onClick.AddListener(hideDisplayInfo);
            }

            encoji4.interactable = true;
        }


        monthIntInfoNow = PlayerPrefs.GetInt("taskCounterMonth");

        if (intDay == 1 & displayed3 == false)
        {
            if (displayed3 == false)
            {
                DisplayInfoPanel.SetActive(true);
                displayText.text = "Congratulations! ";

                if (monthIntInfoPast == 0)
                {
                    displayText.text += "In this month you finished " + monthIntInfoNow + " tasks!";
                    monthIntInfoPast = monthIntInfoNow;
                }
                else
                {
                    dif1 = monthIntInfoNow - monthIntInfoPast;

                    if (dif1 == 0)
                        displayText.text += "In this month you finished " + monthIntInfoNow + ". This is the same as last month!";
                    else if (dif1 < 0)
                        displayText.text += "In this month you finished " + monthIntInfoNow + ". This is the less than last month!";
                    else
                        displayText.text += "In this month you finished " + monthIntInfoNow + ". This is the more than last month by " + dif1 + "!";

                    monthIntInfoPast = monthIntInfoNow;
                }

                displayButton.onClick.AddListener(hideDisplayInfo);
                displayed3 = true;
                PlayerPrefs.SetInt("taskCounteerMonth", 0);
                intOldMonth = intNewMonth;
            }
        }

        yearIntInfoNow = PlayerPrefs.GetInt("taskCounterYear");

        if (intDay == 1 & intMonth == 1 & displayed4 == false)
        {
            if (displayed4 == false)
            {
                DisplayInfoPanel.SetActive(true);
                displayText.text = "Congratulations! ";

                if (yearIntInfoPast == 0)
                {
                    displayText.text += "In this year you finished " + yearIntInfoNow + " tasks!";
                    yearIntInfoPast = yearIntInfoNow;
                }
                else
                {
                    dif2 = yearIntInfoNow - yearIntInfoPast;

                    if (dif2 == 0)
                        displayText.text += "In this year you finished " + yearIntInfoNow + ". This is the same as last year!";
                    else if (dif2 < 0)
                        displayText.text += "In this year you finished " + yearIntInfoNow + ". This is the less than last year!";
                    else
                        displayText.text += "In this year you finished " + yearIntInfoNow + ". This is the more than last year by " + dif2 + "!";

                    yearIntInfoPast = yearIntInfoNow;
                }

                displayButton.onClick.AddListener(hideDisplayInfo);
                displayed4 = true;
                PlayerPrefs.SetInt("taskCounteerYear", 0);
                intOldYear = intNewYear;
            }            
        }

        //Debug.Log(intDay + " " + intMonth + " " + intNewMonth + " " + intOldMonth + " " + intNewYear + " " + intOldYear);
    }

    void hideDisplayInfo()
    {
        DisplayInfoPanel.SetActive(false);
    }
}
