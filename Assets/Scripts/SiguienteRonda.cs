using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguienteRonda : MonoBehaviour
{
    public Draw draw;
    public Draw draw2;

    public GameObject Ganador;
    public GameObject CambioTurno;

    public void OnClick()
    {
        Ganador.SetActive(false);

        draw.RestarCardCount();
        draw2.RestarCardCount();

        CambioTurno.SetActive(true);

    }
}
