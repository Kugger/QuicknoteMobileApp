using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddTask : MonoBehaviour
{
    public Dropdown category, type, year, month, day, colour;

    public InputField descripiton;

    string m_Message;

    public void createButtonPressed() 
    {
        m_Message = category.options[category.value].text;

        Debug.Log(m_Message);
        Debug.Log(year.value);
        Debug.Log(descripiton);
    }
}
