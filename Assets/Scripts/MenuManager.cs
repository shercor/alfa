using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene("Juego");
    }

    public void ButtonControls()
    {
        SceneManager.LoadScene("Controles");
    }

    public void ButtonQuit()
    {
        Debug.Log("Saliendo del Juego");
        Application.Quit();
    }
}
