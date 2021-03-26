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


    string minutesTest;

    void Start()
    {
        minutesTest = System.DateTime.Now.ToLocalTime().ToString("mm");

        Debug.Log("Minutes at awake: " + minutesTest);
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
        }


    }

    void hideDisplayInfo()
    {
        DisplayInfoPanel.SetActive(false);
    }
}
