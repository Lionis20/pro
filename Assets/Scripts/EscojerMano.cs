using UnityEngine;

public class EscojerMano : MonoBehaviour
{
    public GameObject MenuEscjMano;
    public GameObject SlotDeck;
    public GameObject NoCardsS;
    public GameObject Hand;
    public GameObject LimitCartas;

    public GameObject[] PoolCuerpoSlots;
    public GameObject[] PoolDistanciaSlots;
    public GameObject[] PoolAsedioSlots;

    public GameObject SlotAuCuerpo;
    public GameObject SlotAuDistancia;
    public GameObject SlotAuAsedio;

    public GameObject SlotCliCuerpo;
    public GameObject SlotCliDistancia;
    public GameObject SlotCliAsedio;

    public GameObject SlotLider;

    private const int MAX_CARDS_IN_HAND = 10;
    private const int SLOTS_PER_POOL = 5;

    public Draw draw;

    public void OnClick()
    {
        if (Hand.transform.childCount == MAX_CARDS_IN_HAND)
        {
            MenuEscjMano.SetActive(false);
            SlotDeck.SetActive(false);
            LimitCartas.SetActive(false);

            ActivarPoolSlots(PoolCuerpoSlots);
            ActivarPoolSlots(PoolDistanciaSlots);
            ActivarPoolSlots(PoolAsedioSlots);

            SlotAuCuerpo.SetActive(true);
            SlotAuDistancia.SetActive(true);
            SlotAuAsedio.SetActive(true);

            SlotCliCuerpo.SetActive(true);
            SlotCliDistancia.SetActive(true);
            SlotCliAsedio.SetActive(true);

            SlotLider.SetActive(true);

            draw.IgualaCountDoce(); //Solucion error robo de 2 cartas por turno
        }
        else
        {
            NoCardsS.SetActive(true);
        }
    }

    private void ActivarPoolSlots(GameObject[] poolSlots)
    {
        for (int i = 0; i < poolSlots.Length; i += SLOTS_PER_POOL)
        {
            // Activar los 5 slots de cada pool
            for (int j = 0; j < SLOTS_PER_POOL; j++)
            {
                poolSlots[i + j].SetActive(true);
            }
        }
    }
}
