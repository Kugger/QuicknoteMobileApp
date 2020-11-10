using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class SignInButton : MonoBehaviour
{
    public void AddUser() 
    {
        SceneManager.LoadScene(1);
    }
}
