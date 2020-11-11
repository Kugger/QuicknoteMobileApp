/**
  * \author: Kacper Gorgoń
  * \date: 2020.11.10
  * \brief: Add User button functionality in LoggingScene
  * v0.01
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class SignInButton : MonoBehaviour
{
    public void AddUser() 
    {
        SceneManager.LoadScene("SignUpScene");
    }
}
