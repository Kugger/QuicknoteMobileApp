using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddTask : MonoBehaviour
{
    public Dropdown category, type, year, month, day, colour;

    public InputField descripiton;

    public Button createButton;

    // Update is called once per frame
    void Update()
    {
        if(createButton == true)
        {
            Debug.Log(category);
            Debug.Log(year);
            Debug.Log(descripiton);
        }
    }
}
