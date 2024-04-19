using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Pasar : MonoBehaviour
{
    public GameObject[] Slots;

    public GameObject CambioTurno;
    private int ClickCount = 0;

    public void OnClick()
    {
        if(ClickCount == 0)
        {
            CombatManager.Instance.CambioTurno();
            CambioTurno.SetActive(false);
            ClickCount ++;

        }
        else
        {
            foreach (GameObject go in Slots) //Enviar todas las cartas del campo al cementerio
            {
                if (go.transform.childCount > 0)
                {
                    for (int i = go.transform.childCount - 1; i >= 0; i--)
                    {
                        Destroy(go.transform.GetChild(i).gameObject);
                    }
                }
            }
            CombatManager.Instance.GanarPasar();
            ClickCount = 0;
        }
    }
}

    

