using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
   public GameObject pantallaGameOver; // Pantalla de Game Over
    public Slider barraDeVida; // Barra de vida del jugador

    void Start()
    {
        
    }

    void Update()
    {
        // Ver si la barra de vida del jugador ha llegado a cero
        if (barraDeVida.value <= 0)
        {
            // Mostrar la pantalla de Game Over si la barra de vida está vacía
            Invoke("MostrarGameOver", 1f);
        }
    }

    void MostrarGameOver()
    {
        // Activar la pantalla de Game Over
        pantallaGameOver.SetActive(true);

        //Pausar el juego
        Time.timeScale = 0f;

        PlayerPrefsSettings.instance.setNumOleada(1); // Poner de nuevo la oleada a 1
    }
}
