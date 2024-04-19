using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public string[] requiredTags;
    public GameObject Hand; 

    private ZombiCard[] zombiCards;
    private PlantaCard[] plantaCards;

    public GameObject HabLider;
    public GameObject HabLider2;
    
    public void OnDrop(PointerEventData eventData)
    {
        plantaCards = FindObjectsOfType<PlantaCard>();
        zombiCards = FindObjectsOfType<ZombiCard>();


        if (! item)
        { 
            item = DragHandler.itemDragging;
            
            // Verificar tags requeridos
            bool hasRequiredTag = false;
            foreach (string tag in requiredTags)
            {
                if (item.CompareTag(tag))
                {
                    hasRequiredTag = true;
                    break;
                }
            }
            
            if (hasRequiredTag)
            {
                //Si hay un hijo en el DropSlot
                if (transform.childCount > 0)
                {
                    GameObject child = transform.GetChild(0).gameObject;
                    
                    // Si item tiene Señuelo, reemplaza al hijo
                    if (item.CompareTag("Señuelo"))
                    {
                        child.transform.SetParent(Hand.transform);
                        child.GetComponent<DragHandler>().enabled = true;
                        child.GetComponent<Button>().enabled = false;
                        
                        item.transform.SetParent(transform);
                        item.transform.position = transform.position;
                        item.GetComponent<DragHandler>().enabled = false;
                        item.GetComponent<Button>().enabled = true;
                    }
                    // Si item no tiene Señuelo, devolver el item a la mano
                    else
                    {
                        item.transform.SetParent(Hand.transform);
                        item = null;
                    }
                }
                // Si no hay hijos, agregar el item
                else
                {
                    item.transform.SetParent(transform);
                    item.transform.position = transform.position;
                    item.GetComponent<DragHandler>().enabled = false;
                    item.GetComponent<Button>().enabled = true;

                    //Carta Despeje
                    if (item.CompareTag("Despeje"))
                    {
                        CombatManager.Instance.DestroyObjectsWithTag("Clima");
                        CombatManager.Instance.DestroyObjectsWithTag("Despeje");
                    }
                    
                    // Llamar al método de todos los objetos ZombiCard
                    foreach (var zombiCard in zombiCards)
                    {
                        if(item.CompareTag("LluviaAcida"))
                        {
                            zombiCard.LluviaAcida();
                        }
                    }
                    
                    // Llamar al método de todos los objetos PlantaCard
                    foreach (var plantaCard in plantaCards)
                    {
                        if (item.CompareTag("Soleado"))
                        {
                            plantaCard.Soleado();
                        }
                    }

                    foreach (var zombiCard in zombiCards)
                    {
                        if(item.CompareTag("Barrera") && item.layer == LayerMask.NameToLayer("Player"))
                        {
                            zombiCard.BarreraPlayer();
                        }
                    }

                    foreach (var zombiCard in zombiCards)
                    {
                        if(item.CompareTag("Barrera") && item.layer == LayerMask.NameToLayer("Player2"))
                        {
                            zombiCard.BarreraPlayer2();
                        }
                    }

                    foreach (var plantaCard in plantaCards)
                    {
                        if (item.CompareTag("Revitalizar") && item.layer == LayerMask.NameToLayer("Player"))
                        {
                            plantaCard.RevitalizarPlayer();
                        }
                    }

                    foreach (var plantaCard in plantaCards)
                    {
                        if (item.CompareTag("Revitalizar") && item.layer == LayerMask.NameToLayer("Player2"))
                        {
                            plantaCard.RevitalizarPlayer2();
                        }
                    }

                    if (item.CompareTag("Líder") && item.layer == LayerMask.NameToLayer("Player"))
                    {
                        HabLider.SetActive(true);
                    }

                    if (item.CompareTag("Líder") && item.layer == LayerMask.NameToLayer("Player2"))
                    {
                        HabLider2.SetActive(true);
                    }
                }
            }
            else
            {
                item.transform.SetParent(Hand.transform);
                item = null;
            }
        }

        //Si hay más de un hijo
        if (transform.childCount > 1)
        {
            for (int i = 1; i < transform.childCount; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                bool hasRequiredTag = false;
                foreach (string tag in requiredTags)
                {
                    if (child.CompareTag(tag))
                    {
                        hasRequiredTag = true;
                        break;
                    }
                }
                // Si el hijo no tiene los tags, devolver a la mano, habilitar DragHandler y deshabilitar Button
                if (!hasRequiredTag)
                {
                    child.transform.SetParent(Hand.transform);
                    child.GetComponent<DragHandler>().enabled = true;
                    child.GetComponent<Button>().enabled = false;
                }
            }
        }
        item = null;
    }
}
