using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class CreateTask : MonoBehaviour
{
    [Header("Transforms")]
    public Transform contentFromScrollview;

    [Header("GameObjects")]
    public GameObject addTaskPanel;
    public GameObject taskItemPrefab;
    public GameObject ActualDateAndTimeScript;
    public GameObject invalidDateAndTimeText;

    [Header("Inputs")]
    public InputField TitleField;
    public InputField DescriptionField;
    public ToggleGroup ColorToggleGroup;

    [Header("Date and Time Texts")]
    public Text dayText;
    public Text monthText;
    public Text yearText;
    public Text hourText;
    public Text minuteText;

    [Header("Up Buttons")]
    public Button dayButtonUp;
    public Button monthButtonUp;
    public Button yearButtonUp;
    public Button hourButtonUp;
    public Button minuteButtonUp;

    [Header("Down Buttons")]
    public Button dayButtonDown;
    public Button monthButtonDown;
    public Button yearButtonDown;
    public Button hourButtonDown;
    public Button minuteButtonDown;

    [Header("Colors")]
    public Color hardMint = new Color(0f, 111f, 73f, 1f);
    public Color modernSuit = new Color(67f, 117f, 219f, 1f);
    public Color bookCover = new Color(219f, 67f, 82f, 1f);
    public Color flatPlum = new Color(120f, 36f, 184f, 1f);
    public Color woodPecker = new Color(111f, 69f, 14f, 1f);
    public Color sandCastle = new Color(219f, 168f, 66f, 1f);

    [Header("Create Button")]
    public Button CreateTaskButton;

    [Space(10)]

    public bool disabledButton;
    public bool leapYear;
    public bool nowDay, nowMonth, nowHour;

    public Color selectedColor;

    private Toggle selectedToggle;

    int intDay = 1, intMonth = 1, intYear = 1980, intHour = 00, intMinute = 00;

    public int minDay = 1;
    public int minMonth = 1;
    public int minYear = 1980;
    public int minHour = 00;
    public int minMinute = 00;

    int maxDay = 31;
    int maxMonth = 12;
    int maxHour = 23;
    int maxMinute = 59;

    // private int presentDay = 1, presentMonth = 1, presentYear = 1, presentHour = 1, presentMinute = 1;

    // sciezka do pliku gdzie bedziemy przechowywac nasze taski
    string filePath;

    private List<NewTask> tasksList = new List<NewTask>();

    string jsonFileName = "TaskFile.json";

    int doneValue;
    int deletedValue;

    public int taskCounterMonth;
    public int taskCounterYear;

    // tymczasowa klasa
    public class NewTaskList
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

        public NewTaskList(string title, string desc, Color color, string day, string month, string year, string hour, string minute, int index)
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

    void Start()
    {
        // sciezka do pliku z danymi do taskow, wedlug internetow powinno dzialac z systemem android
        // filePath = Application.persistentDataPath + "/checklist.txt";
        filePath = Path.Combine(Application.persistentDataPath, jsonFileName);

        readTaskFromJson();

        dayText.text = System.DateTime.Now.ToString("dd");
        monthText.text = System.DateTime.Now.ToString("MM");
        yearText.text = System.DateTime.Now.ToString("yyyy");
        hourText.text = System.DateTime.Now.ToString("HH");
        minuteText.text = System.DateTime.Now.ToString("mm");

        intDay = int.Parse(dayText.text);
        intMonth = int.Parse(monthText.text);
        intYear = int.Parse(yearText.text);
        intHour = int.Parse(hourText.text);
        intMinute = int.Parse(minuteText.text);

        minDay = intDay;
        minMonth = intMonth;
        minYear = intYear;
        minHour = intHour;
        minMinute = intMinute;
    }

    void saveTaskToJson()
    {
        string fileContent = "";
        string fileCrypted = "";

        for (int i = 0; i < tasksList.Count; i++)
        {
            NewTaskList temp = new NewTaskList(tasksList[i].objTitle, tasksList[i].objDescription, tasksList[i].objColor, tasksList[i].objDay,
                tasksList[i].objMonth, tasksList[i].objYear, tasksList[i].objHour, tasksList[i].objMinute, tasksList[i].objIndex);
            fileContent += JsonUtility.ToJson(temp) + "\n";
        }
        byte[] bytesCrypted = Encoding.UTF8.GetBytes(fileContent);
        fileCrypted = Convert.ToBase64String(bytesCrypted);

        System.IO.File.WriteAllText(filePath, fileCrypted);
    }

    void readTaskFromJson()
    {
        string fileCrypted = "";
        string fileDecrypted = "";

        fileCrypted = System.IO.File.ReadAllText(filePath);

        byte[] bytesDecrypted = Convert.FromBase64String(fileCrypted);
        fileDecrypted = Encoding.UTF8.GetString(bytesDecrypted);

        string[] splitTextContent = fileDecrypted.Split('\n');

        foreach (string textContent in splitTextContent)
        {
            if (textContent.Trim() != "")
            {
                NewTaskList temp = JsonUtility.FromJson<NewTaskList>(textContent.Trim());
                CreateButtonPressed(temp.objTitle, temp.objDescription, temp.objColor, temp.objDay, temp.objMonth, temp.objYear, temp.objHour, temp.objMinute, temp.objIndex);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        // sprawdzanie czy rok jest przestepny
        if (intYear % 4 == 0)
        {
            if (intYear % 100 == 0)
            {
                if (intYear % 400 == 0)
                    leapYear = true;
                else
                    leapYear = false;
            }
            else
                leapYear = true;
        }
        else
            leapYear = false;

        // ograniczanie minimum dnia
        if (minDay >= intDay & minMonth == intMonth & minYear == intYear)
        {
            nowDay = true;
            dayButtonDown.interactable = false;
        }
        else if (intDay == 1)
        {
            nowDay = false;
            dayButtonDown.interactable = false;
        }
        else
        {
            nowDay = false;
            dayButtonDown.interactable = true;
        }

        // ograniczanie maksimum dnia
        switch (intMonth)
        {
            case 1:
                maxDay = 31;
                break;
            case 2:
                maxDay = 28;
                break;
            case 3:
                maxDay = 31;
                break;
            case 4:
                maxDay = 30;
                break;
            case 5:
                maxDay = 31;
                break;
            case 6:
                maxDay = 30;
                break;
            case 7:
                maxDay = 31;
                break;
            case 8:
                maxDay = 31;
                break;
            case 9:
                maxDay = 30;
                break;
            case 10:
                maxDay = 31;
                break;
            case 11:
                maxDay = 30;
                break;
            case 12:
                maxDay = 31;
                break;
        }

        if (intMonth == 2 & leapYear == true)
            maxDay = 29;


        if (maxDay <= intDay)
        {
            dayText.text = maxDay.ToString();
            dayButtonUp.interactable = false;
        }
        else
            dayButtonUp.interactable = true;


        // ograniczanie minimum miesiaca
        if (minMonth >= intMonth & minYear == intYear)
        {
            if (nowDay == true)
            {
                intDay = minDay;
                dayText.text = minDay.ToString();
            }
            nowMonth = true;
            monthButtonDown.interactable = false;
        }
        else if (intMonth == 1)
        {
            nowMonth = false;
            monthButtonDown.interactable = false;
        }
        else
        {
            nowMonth = false;
            monthButtonDown.interactable = true;
        }


        // ograniczanie maksimum miesiaca
        if (maxMonth <= intMonth & minYear == intYear)
            monthButtonUp.interactable = false;
        else if (intMonth == 12)
            monthButtonUp.interactable = false;
        else
            monthButtonUp.interactable = true;


        // ograniczanie minimum roku
        if (minYear >= intYear)
        {
            if (nowMonth == true)
            {
                intMonth = minMonth;
                monthText.text = minMonth.ToString();
            }
            yearButtonDown.interactable = false;
        }
        else
            yearButtonDown.interactable = true;


        // ograniczanie minimum godzin
        if (minHour >= intHour & minDay == intDay & minMonth == intMonth & minYear == intYear)
        {
            nowHour = true;
            hourText.text = minHour.ToString();
            hourButtonDown.interactable = false;
        }
        else if (intHour == 00)
        {
            nowHour = false;
            hourButtonDown.interactable = false;
        }
        else
        {
            nowHour = false;
            hourButtonDown.interactable = true;
        }

        // ograniczanie maksimum godzin
        if (maxHour <= intHour)
            hourButtonUp.interactable = false;
        else
            hourButtonUp.interactable = true;


        // ograniczanie minimum minut
        if (minMinute >= intMinute & minDay == intDay & minMonth == intMonth & minYear == intYear & minHour == intHour)
        {
            intMinute = minMinute;
            minuteText.text = intMinute.ToString();
            minuteButtonDown.interactable = false;
        }
        else if (intMinute == 00)
            minuteButtonDown.interactable = false;
        else
            minuteButtonDown.interactable = true;

        // ograniczanie maksimum minut
        if (maxMinute <= intMinute)
            minuteButtonUp.interactable = false;
        else
            minuteButtonUp.interactable = true;


        if (addTaskPanel.activeSelf)
        {
            // zbieranie ktory color toggle zostal wybrany
            foreach (var toggle in ColorToggleGroup.ActiveToggles())
            {
                if (toggle.isOn)
                    selectedToggle = toggle;
            }

            // wybieranie koloru z wybranego toggle w AddTaskPanel
            selectedColor = selectedToggle.GetComponentInChildren<Image>().color;
        }


        PlayerPrefs.SetInt("unifinishedTasksAmonut", tasksList.Count);

        doneValue = PlayerPrefs.GetInt("maxDoneValue");

        deletedValue = PlayerPrefs.GetInt("maxDeletedValue");

        taskCounterMonth = PlayerPrefs.GetInt("taskCounterMonth");

        taskCounterYear = PlayerPrefs.GetInt("taskCounterYear");
    }

    public void CreateNewTask()
    {
        string temp = TitleField.text;
        string temp2 = DescriptionField.text;
        Color temp3 = selectedColor;
        CreateButtonPressed(temp, temp2, temp3, intDay.ToString(), intMonth.ToString(), intYear.ToString(), intHour.ToString(), intMinute.ToString());
    }

    public void CreateButtonPressed(string objTitle, string objDescription, Color objColor, string objDay, string objMonth, string objYear, string objHour, string objMinute, int objIndex = 0)
    {
        // inicjalizowanie tasku uzywajac przygotowanego prefabu
        GameObject task = Instantiate(taskItemPrefab);
        // dodatnie taskowi "porzadku"
        task.transform.SetParent(contentFromScrollview);
        // tworzenie tasku
        NewTask taskObject = task.GetComponent<NewTask>();

        // indeksowanie tasków
        int index = 0;
        if (tasksList.Count == 0)
            index = 0;
        else
            index = tasksList.Count;

        // ustawiamy jaki tytul, opis, kolor, date i index taskowi 
        taskObject.SetObjectInfo(objTitle, objDescription, objColor, objDay, objMonth, objYear, objHour, objMinute, index);

        // znajdujemy componenty tekstu i wsadzamy je w liste
        Text[] textsInTask = taskObject.GetComponentsInChildren<Text>();

        // nadajemy kazdemu odpowiednia wartosc podana przez uzytkownia
        textsInTask[0].text = objTitle;
        textsInTask[1].text = objDescription;
        //textsInTask[2].text = index.ToString();
        textsInTask[2].text = objDay + "-" + objMonth + "-" + objYear + "   " + objHour + ":" + objMinute;

        // nadajemy kolor obrazkowi w prefabie
        Image ImageColor = taskObject.GetComponentInChildren<Image>();
        ImageColor.color = selectedColor;

        tasksList.Add(taskObject);

        // resetujemy wartosci 
        TitleField.text = "";
        DescriptionField.text = "";

        intDay = minDay;
        intMonth = minMonth;
        intYear = minYear;
        intHour = minHour;
        intMinute = minMinute;

        Button[] buttonsInTask = taskObject.GetComponentsInChildren<Button>();

        NewTask temp = taskObject;
        buttonsInTask[0].onClick.AddListener((delegate { DoneButtonPressed(temp); }));
        buttonsInTask[1].onClick.AddListener((delegate { DeleteButtonPressed(temp); }));

        // zapisujemy do pliku
        saveTaskToJson();
    }


    void DoneButtonPressed(NewTask task)
    {
        tasksList.Remove(task);

        doneValue++;
        PlayerPrefs.SetInt("doneValueAdd", doneValue);

        taskCounterMonth++;
        PlayerPrefs.SetInt("taskCounterMonth", taskCounterMonth);

        taskCounterYear++;
        PlayerPrefs.SetInt("taskCounterYear", taskCounterYear);

        saveTaskToJson();
        Destroy(task.gameObject);
    }

    void DeleteButtonPressed(NewTask task)
    {
        tasksList.Remove(task);

        deletedValue++;
        PlayerPrefs.SetInt("deletedValueAdd", deletedValue);

        saveTaskToJson();
        Destroy(task.gameObject);
    }

    public void DayButtonUp(Text dayText)
    {
        intDay++;
        dayText.text = intDay.ToString();
    }

    public void DayButtonDown(Text dayText)
    {
        intDay--;
        dayText.text = intDay.ToString();
    }

    public void MonthButtonUp(Text monthText)
    {
        intMonth++;
        monthText.text = intMonth.ToString();
    }

    public void MonthButtonDown(Text monthText)
    {
        intMonth--;
        monthText.text = intMonth.ToString();
    }

    public void YearButtonUp(Text yearText)
    {
        intYear++;
        yearText.text = intYear.ToString();
    }

    public void YearButtonDown(Text yearText)
    {
        intYear--;
        yearText.text = intYear.ToString();
    }

    public void HourButtonUp(Text hourText)
    {
        intHour++;
        hourText.text = intHour.ToString();
    }

    public void HourButtonDown(Text hourText)
    {
        intHour--;
        hourText.text = intHour.ToString();
    }

    public void MinuteButtonUp(Text minuteText)
    {
        intMinute++;
        minuteText.text = intMinute.ToString();
    }

    public void MinuteButtonDown(Text minuteText)
    {
        intMinute--;
        minuteText.text = intMinute.ToString();
    }
}
