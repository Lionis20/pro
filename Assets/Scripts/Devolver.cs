using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Devolver : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public GameObject SlotDeck;
    public Draw draw;
    public GameObject LimitCartas;

    private void Start()
    {
        draw = GameObject.FindObjectOfType<Draw>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (! item)
        { 
            item = DragHandler.itemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;

            // Verificar si hay dos cartas en el SlotDeck
            if (SlotDeck.transform.childCount == 2)
            {
                // Desactivar SlotDeck
                SlotDeck.gameObject.SetActive(false);
            }

            draw.Devolver(item); // Agregar el objeto a la lista
        }

        item = null; // Limpiar la variable item
    }

    public void OnClick() //Activar letrero sin devolver cartas
    {
        LimitCartas.SetActive(true);
    }
}
