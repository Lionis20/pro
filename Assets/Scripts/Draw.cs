using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draw : MonoBehaviour
{
    public GameObject Hand;
    private List<GameObject> CardsInHand { get; set; }
    public List<GameObject> CardsInDeck;

    private bool ClickPri = true;
    private bool hasHabLider = false;

    public GameObject SlotDeck;
    public GameObject LimitCartas;
    private float tiempoTranscurrido = 0f;

    private int cardCount = 0; // Contador de cartas instanciadas

    public string Player;
    private int playerLayer;



    // Start is called before the first frame update
    void Start()
    {
        CardsInHand = new();
        // Obtener el índice de la capa "Player"
        playerLayer = LayerMask.NameToLayer(Player);
    }

    public void OnClick()
    {
        tiempoTranscurrido = 0f; //Reiniciar tiempo del letrero

        int numCartasDisponibles = ClickPri ? 10 : 2; //Primer click se agragan 10 cartas, luego 2

        for (int i = 0; i < numCartasDisponibles; i++)
        {
            if (cardCount < 12 && CardsInDeck.Count > 0 && Hand.transform.childCount < 10)
            {
                int randomIndex = Random.Range(0, CardsInDeck.Count);
                GameObject drawCard = Instantiate(CardsInDeck[randomIndex], new Vector3(0, 0, 0), Quaternion.identity);
                drawCard.transform.SetParent(Hand.transform, false);
                CardsInHand.Add(drawCard);

                drawCard.layer = playerLayer; //Diferenciar cartas de uno y otro jugador

                //Eliminar las cartas de la lista de cartas no instanciadas
                CardsInDeck.RemoveAt(randomIndex);
                
                //Activar el Slot para devolver dos cartas al mazo
                if (ClickPri)
                {                drawCard.layer = LayerMask.NameToLayer(Player);

                    SlotDeck.SetActive(true);
                }
             cardCount++; //incrementar el contador de cartas instanciadas
            }
            else
            {
                LimitCartas.SetActive(true);
            }  
        }

        ClickPri = false;

    }
    public void Devolver(GameObject item)
    {
        CardsInDeck.Add(item);
    }

    private void Update() //Desactivar letrero pasados 5 segundos
    {
        if (LimitCartas.activeSelf)
        {
            tiempoTranscurrido += Time.deltaTime;
            if (tiempoTranscurrido >= 5f)
            {
                LimitCartas.SetActive(false);
                tiempoTranscurrido = 0f;
            }
        }
    }
    public void RestarCardCount()
    {
        cardCount -= 2; // Resta 2 al contador de cartas instanciadas
    }
    public void IgualaCountDoce()
    {
        cardCount = 12; 
    }

    public void HabLider()
    {
        if (!hasHabLider)
        {
            int randomIndex = Random.Range(0, CardsInDeck.Count);
            GameObject drawCard = Instantiate(CardsInDeck[randomIndex], new Vector3(0, 0, 0), Quaternion.identity);
            drawCard.transform.SetParent(Hand.transform, false);
            CardsInHand.Add(drawCard);
            
            // Marcar que el método
            hasHabLider = true;
        }
    }
 
}








