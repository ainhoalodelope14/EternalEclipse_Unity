using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    // Método para iniciar el juego
    public void Jugar(string nombre)
    {
        // Cargar la escena del juego
        SceneManager.LoadScene(nombre);
         // Initialize PlayerPrefsSettings.instance if it's null
        if(PlayerPrefsSettings.instance != null)
        {
            PlayerPrefsSettings.instance.Clear();
        }
        
        
    }

    // Método para salir del juego
    public void Salir()
    {
        // Salir de la aplicación (solo funciona en build, no en el editor)
        Application.Quit();
    }
}
