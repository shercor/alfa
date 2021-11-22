using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public void ButtonReturn()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ButtonExit()
    {
        Debug.Log("Saliendo del Juego");
        Application.Quit();
    }
}
