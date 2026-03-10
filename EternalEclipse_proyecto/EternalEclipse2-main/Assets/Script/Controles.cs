using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{

    public GameObject pantallaMenuControles; // Pantalla de menu con los controles


    // Start is called before the first frame update
    void Start()
    {
        int numOleada = PlayerPrefsSettings.instance.getNumOleada(); // Saber que numero de oleada es
        if (numOleada == 1)
        {
            Time.timeScale = 0f;
            pantallaMenuControles.SetActive(true); // Se activa si el número es 1
        }
        else
        {
            // Si no estás en la oleada 1, continúa directamente sin mostrar los controles
            Continuar();
        }

    }

    public void Continuar()
    {
        //Reiniciar el juego, vuelve el tiempo a reiniciarse y carga la pantalla del juego
        Time.timeScale = 1f;
        pantallaMenuControles.SetActive(false);
    }
}
