using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private static CombatManager instance;
        public GameObject AttackCard;

        public int PuntosPlayer;
        public int PuntosPlayer2;

        public TextMeshProUGUI PuntosPlayerT;
        public TextMeshProUGUI PuntosPlayer2T;

        Card card;

        public GameObject Jugador1;
        public GameObject Jugador2;

        public GameObject HandJ1;
        public GameObject HandJ2;
        
        public GameObject Deck;
        public GameObject Deck2;

        public GameObject PlayerImage;

        public TextMeshProUGUI Gana;
        public GameObject Ganador;

        public int PuntosRonda = 0;
        public int PuntosRonda2 =0;

        public TextMeshProUGUI PuntosRondaT;
        public TextMeshProUGUI PuntosRonda2T;



    public static CombatManager Instance
    {
        get
        {
            // Si no hay una instancia de CombatManager, se crea una nueva
            if (instance == null)
            {
                instance = FindObjectOfType<CombatManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("CombatManager");
                    instance = obj.AddComponent<CombatManager>();
                }
            }
            return instance;
        }
    }

    public int damage;

    public void CalculateDamage(int attack, GameObject card)
    {
        // Asignar el valor de ataque damage
        damage = attack;

        // Guardar una referencia al objeto de la carta atacante
        AttackCard = card;

        // Imprimir el valor de ataque en la consola para verificar que se está pasando
        Debug.Log("Valor de ataque: " + damage);
    }

    public void ActPuntos()
    {
        //Actualizar el texto de los puntos de los jugadores
        PuntosPlayerT.text = "" + PuntosPlayer;
        PuntosPlayer2T.text = "" + PuntosPlayer2;
    }

    public void CambioTurno()
    {
        // Intercambiar posiciones y rotaciones de Jugador1 y Jugador2
        (Jugador1.transform.position, Jugador2.transform.position) = (Jugador2.transform.position, Jugador1.transform.position);
        (Jugador1.transform.rotation, Jugador2.transform.rotation) = (Jugador2.transform.rotation, Jugador1.transform.rotation);

        if(HandJ1.activeInHierarchy) //Evitar q intercambio de cartas entre manos
        {
            HandJ2.SetActive(true);
            HandJ1.SetActive(false);
        }
        else
        {
            HandJ2.SetActive(false);
            HandJ1.SetActive(true);
        }

        if(Deck.activeInHierarchy) //Evitar q las cartas se devuelvan al Deck contrario
        {
            Deck2.SetActive(true);
            Deck.SetActive(false);

        }
        else
        {
            Deck2.SetActive(false);
            Deck.SetActive(true);
        }

    }

    public void DestroyObjectsWithTag(string tag) //Despeje
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }

    }

    public void DisPlayerControl()
    {
        PlayerImage.SetActive(false);
    }

    public void ActPlayerControl()
    {
        PlayerImage.SetActive(true);
    }

    public void Ganar()
    {
        if(PuntosPlayer <=0)
        {
            Gana.text = "Jugador 2 gana la ronda";
            Ganador.SetActive(true);
        }

        if(PuntosPlayer2 <=0) 
        {
            Gana.text = "Jugador 1 gana la ronda";
            Ganador.SetActive(true);

        }
    }

    public void GanarPasar()
    {
        Ganador.SetActive(true);
         
          if(PuntosPlayer == PuntosPlayer2)
        {
            Gana.text = "Empate";
            PuntosRonda += 1;
            PuntosRonda2 += 1;
        }    
       else if(PuntosPlayer < PuntosPlayer2)
        {
            Gana.text = "Jugador 2 gana la ronda";

            Jugador2.transform.position = new Vector2(-1.378723f, -51.42999f);
            Jugador1.transform.rotation = Quaternion.Euler(180f, 0f, 0f);

            Jugador1.transform.position = new Vector2(-1.378723f, 156.5f);
            Jugador2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            HandJ2.SetActive(true);
            Deck2.SetActive(true);

            HandJ1.SetActive(false);
            Deck.SetActive(false);

            PuntosRonda2 += 1;
        }
        else        
        {
            Gana.text = "Jugador 1 gana la ronda";
            Jugador1.transform.position = new Vector2(-1.378723f, -51.42999f);
            Jugador2.transform.rotation = Quaternion.Euler(180f, 0f, 0f);

            Jugador2.transform.position = new Vector2(-1.378723f, 156.5f);
            Jugador1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            HandJ2.SetActive(false);
            Deck2.SetActive(false);

            HandJ1.SetActive(true);
            Deck.SetActive(true);

            PuntosRonda += 1;
        }
    }

    public void Update()
    {
        PuntosRondaT.text = "" + PuntosRonda;
        PuntosRonda2T.text = "" + PuntosRonda2;
    }
}
