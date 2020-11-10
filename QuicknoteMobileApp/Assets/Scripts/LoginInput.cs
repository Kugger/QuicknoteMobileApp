/**
  * \author: Kacper Gorgoń
  * \date: 2020.11.10
  * \brief: Login Input field functionality in LoggingScene
  * v0.01
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class LoginInput : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;

    public Text login;
    // string loginText = "";

    public void OpenKeyboard () 
    {
        keyboard = TouchScreenKeyboard.Open("Hello", TouchScreenKeyboardType.Default);
    }

    /*
    void Update()
    {
        if(TouchScreenKeyboard.visible == false && keyboard != null)
        {
            if(keyboard.done)
            {
                loginText = login.text;
                keyboard = null;
            }
        }
    }
    */
}
