using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton_GameOver : MonoBehaviour
{
    public void Reiniciar()
    {
        //Reiniciar el juego, vuelve el tiempo a reiniciarse y carga la pantalla del juego
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombre); //Carga la escena
    }

    public void Salir()
    {
        //Cerrar juego
        Application.Quit();
    }

    public void Continuar()
    {
        //Reiniciar el juego, vuelve el tiempo a reiniciarse y carga la pantalla del juego
        Time.timeScale = 1f;
    }
}
