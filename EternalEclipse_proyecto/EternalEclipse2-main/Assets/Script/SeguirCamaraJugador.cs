using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamaraJugador : MonoBehaviour
{
    public Transform objetivo; // Referencia al transform del personaje que seguirá la cámara
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset para ajustar la posición de la cámara con respecto al personaje

    // Update is called once per frame
    void LateUpdate()
    {
        if (objetivo != null)
        {
            // Obtener la posición actual del personaje y agregar el offset
            Vector3 nuevaPosicion = objetivo.position + offset;

            // Asignar la nueva posición a la cámara manteniendo el mismo valor en z
            transform.position = new Vector3(nuevaPosicion.x, nuevaPosicion.y, transform.position.z);
        }
    }
}
