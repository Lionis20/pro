using UnityEngine;

public class NextPlayer : MonoBehaviour
{
    public GameObject Jugador1;
    public GameObject Jugador2;
    public GameObject MenuEscjMano2;
    private bool menuEscjMano = false;

    public GameObject HandJ1;
    public GameObject HandJ2;
    public GameObject Deck;
    public GameObject Deck2;

    public GameObject TextJug1;
    public GameObject TextJug2;

    public void OnClick()
    {
        // Intercambiar posiciones y rotaciones de Jugador1 y Jugador2
        (Jugador1.transform.position, Jugador2.transform.position) = (Jugador2.transform.position, Jugador1.transform.position);
        (Jugador1.transform.rotation, Jugador2.transform.rotation) = (Jugador2.transform.rotation, Jugador1.transform.rotation);
        
        // Activar solo una vez
        if (!menuEscjMano)
        {
            MenuEscjMano2.SetActive(true);
            menuEscjMano = true;
        }

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
}
