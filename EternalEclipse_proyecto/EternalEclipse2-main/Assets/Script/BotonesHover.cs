using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotonesHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipPanel; // El panel que actúa como el tooltip
    public Text tooltipText; // El texto dentro del panel que muestra la descripción de la mejora
    public string upgradeDescription = ""; // La descripción de la mejora

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tooltipPanel != null && tooltipText != null) // Si da error en caso de quitar el cursor para no de error de null
        {
            tooltipPanel.SetActive(true); // Se activa el hover
            tooltipText.text = upgradeDescription; // Se coloca la descripcion correspondiente
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPanel.SetActive(false); // Se desactiva si sale
    }
}
