/**
  * \author: Kacper Gorgoń
  * \date: 2020.11.11
  * \brief: LoggingScene all actions in one script
  * v0.01
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class LoggingSceneScript : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;

    public Text login;

    
    public void LoginInput ()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void PasswordInput() 
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true);
    }

    public void AddUser()
    {
        SceneManager.LoadScene("SignUpScene");
    }
}
