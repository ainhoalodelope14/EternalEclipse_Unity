using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Mejora
{
    public string nombre; // Nombre de la mejora
    public string descripcion; // Descripción de la mejora
    public System.Action aplicarMejora; // Método que aplica la mejora

    public Mejora(string nombre, string descripcion, System.Action aplicarMejora)
    {
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.aplicarMejora = aplicarMejora;
    }
}
