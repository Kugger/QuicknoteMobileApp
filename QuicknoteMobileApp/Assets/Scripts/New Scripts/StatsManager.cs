using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    int intDay;
    int intMonth;
    int intOldMonth;
    int intNewMonth;
    int intOldYear;
    int intNewYear;

    public GameObject ActualDateAndTimeScript;
    ActualDateAndTime presentDateAndTime;

    int monthIntInfoNow;
    int monthIntInfoPast;

    int yearIntInfoNow;
    int yearIntInfoPast;

    int dif1, dif2;

    public Button encoji1;
    public Button encoji2;
    public Button encoji3;
    public Button encoji4;

    public Image displayEncoji;

    public Button closeAppButton;

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


        /*
        intDay = 1;
        intMonth = 4;
        intOldMonth = 4;
        intNewMonth = 5;
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
        else if (maxDoneValue > 10 & maxDoneValue < 35 & displayed == false)
        {
            nowLevel.text = "2";
            nextLevel.text = "3";
            levelSlider.maxValue = 35;
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
        else if (maxDoneValue > 35 & maxDoneValue < 85 & displayed1 == false)
        {
            nowLevel.text = "3";
            nextLevel.text = "4";
            levelSlider.maxValue = 85;
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
        else if (maxDoneValue > 85 & maxDoneValue < 185 & displayed2 == false)
        {
            nowLevel.text = "4";
            nextLevel.text = "5";
            levelSlider.maxValue = 185;
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


        int dec = PlayerPrefs.GetInt("EncojiChoice");


        switch (dec)
        {
            case 1:
                displayEncoji.sprite = encoji1.GetComponent<Image>().sprite;
                break;
            case 2:
                displayEncoji.sprite = encoji2.GetComponent<Image>().sprite;
                break;
            case 3:
                displayEncoji.sprite = encoji3.GetComponent<Image>().sprite;
                break;
            case 4:
                displayEncoji.sprite = encoji4.GetComponent<Image>().sprite;
                break;
        }


        monthIntInfoNow = PlayerPrefs.GetInt("taskCounterMonth");

        Debug.Log(monthIntInfoNow + " " + monthIntInfoPast);

        if (intDay == 1 & displayed3 == false)
        {
            if (displayed3 == false)
            {
                DisplayInfoPanel.SetActive(true);
                displayText.text = "Congratulations! ";

                if (monthIntInfoPast != 0)
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
                else
                {
                    displayText.text += "In this month you finished " + monthIntInfoNow + " tasks!";
                    //monthIntInfoPast = monthIntInfoNow;
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

                if (yearIntInfoPast != 0)
                {
                    Debug.Log("em i happing?");

                    dif2 = yearIntInfoNow - yearIntInfoPast;

                    if (dif2 == 0)
                        displayText.text += "In this year you finished " + yearIntInfoNow + ". This is the same as last year!";
                    else if (dif2 < 0)
                        displayText.text += "In this year you finished " + yearIntInfoNow + ". This is the less than last year!";
                    else
                        displayText.text += "In this year you finished " + yearIntInfoNow + ". This is the more than last year by " + dif2 + "!";

                    yearIntInfoPast = yearIntInfoNow;
                }
                else
                {
                    displayText.text += "In this year you finished " + yearIntInfoNow + " tasks!";
                    yearIntInfoPast = yearIntInfoNow;
                }

                displayButton.onClick.AddListener(hideDisplayInfo);
                displayed4 = true;
                PlayerPrefs.SetInt("taskCounteerYear", 0);
                intOldYear = intNewYear;
            }            
        }

        //Debug.Log(monthIntInfoNow + " " + monthIntInfoPast);
        //Debug.Log(intDay + " " + intMonth + " " + intNewMonth + " " + intOldMonth + " " + intNewYear + " " + intOldYear);
    }

    void hideDisplayInfo()
    {
        DisplayInfoPanel.SetActive(false);
    }

    public void Encoji1()
    {
        PlayerPrefs.SetInt("EncojiChoice", 1);
        Debug.Log("dzialam" + PlayerPrefs.GetInt("EncojiChoice"));
    }

    public void Encoji2()
    {
        PlayerPrefs.SetInt("EncojiChoice", 2);
    }

    public void Encoji3()
    {
        PlayerPrefs.SetInt("EncojiChoice", 3);
    }

    public void Encoji4()
    {
        PlayerPrefs.SetInt("EncojiChoice", 4);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
