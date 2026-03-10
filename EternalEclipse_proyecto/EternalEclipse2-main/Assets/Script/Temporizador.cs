using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    public float tiempoInicial = 60f; // Tiempo inicial en segundos
    private float tiempoRestante; // Tiempo restante actual
    public bool tiempoAcabado = false; // Bandera para indicar si el tiempo ha terminado
    public Text textoTiempo; // Referencia al texto donde se mostrará el tiempo
    public GameObject canvasTiempoAcabado; // Referencia al Canvas que se activará cuando el tiempo acabe
    public GameObject gameData;
    public Boss boss; // Referencia al script del jefe

    void Start()
    {
        tiempoRestante = tiempoInicial; // Inicializar el tiempo restante al tiempo inicial
        ActualizarTextoTiempo(); // Actualizar el texto de tiempo inicial
    }

    void Update()
    {
        // Si el tiempo no ha terminado, actualizar el tiempo restante y el texto del tiempo
        if (!tiempoAcabado)
        {
            tiempoRestante -= Time.deltaTime; // Restar tiempo
            ActualizarTextoTiempo(); // Actualizar el texto del tiempo
            // Si el tiempo ha llegado a cero, activar el Canvas y marcar el tiempo como terminado
            if (tiempoRestante <= 1)
            {
                tiempoAcabado = true;
                 if (PlayerPrefsSettings.instance.getNumOleada() == 5)
                {
                    // Aparecer el jefe y desactivar el temporizador
                    boss.gameObject.SetActive(true); // Activar el jefe
                    boss.vidaBoss.gameObject.SetActive(true); // Mostrar la barra de vida del jefe
                    this.enabled = false; // Desactivar este script
                }
                else
                {
                    canvasTiempoAcabado.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
        }
    }

    void ActualizarTextoTiempo()
    {
        // Convertir el tiempo restante a formato de minutos y segundos
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        // Actualizar el texto de tiempo con el tiempo restante formateado
        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
