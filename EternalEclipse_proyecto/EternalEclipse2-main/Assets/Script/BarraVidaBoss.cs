using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaBoss : MonoBehaviour
{
     public Slider slider; // Barra vida Boss

    void Start()
    {
        slider = GetComponent<Slider>(); // Instancia el slider
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue=vidaMaxima; // Se coloca la maxima vida
    }
    public void QuitarVida(float cantidad)
    {
        //Se quita vida según la cantidad
        slider.value=cantidad; 
    }
    public void Inicio(float cantidad){
        slider.maxValue=cantidad; 
        slider.value=cantidad;
    }
}
