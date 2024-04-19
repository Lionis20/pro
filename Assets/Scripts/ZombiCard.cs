using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiCard : MonoBehaviour
{
    public int Ataque;
    public int Defensa;
    public GameObject card;

    public void UseCard()
    {
        // Comprobar el valor de la variable damage en CombatManager
        if (CombatManager.Instance.damage == 0)
        {
            // Si damage = 0, cargar el valor de ataque en damage y la carta
            CombatManager.Instance.CalculateDamage(Ataque, card);

            CombatManager.Instance.DisPlayerControl();
        }
        else 
        {
            if(card != CombatManager.Instance.AttackCard)
            {
                // Si damage > 0, restar damage a defensa
                Defensa -= CombatManager.Instance.damage;
            
                if (Defensa < 1)
                {
                    Destroy(card);

                    if (gameObject.layer == LayerMask.NameToLayer("Player"))
                    {
                        CombatManager.Instance.PuntosPlayer += Defensa;
                    }
                    else if (gameObject.layer == LayerMask.NameToLayer("Player2"))
                    {
                        CombatManager.Instance.PuntosPlayer2 += Defensa;
                    }  

                    CombatManager.Instance.ActPuntos();

                    CombatManager.Instance.ActPlayerControl();

                    CombatManager.Instance.Ganar();
                }

                //Limpiar damage
                CombatManager.Instance.damage = 0;
            }
            else
            {
                //Limpiar damage
                CombatManager.Instance.damage = 0;
            }
        }
    }

    public void LluviaAcida()
    {
        Ataque -= 1;
        Defensa -= 1;
    }

    public void BarreraPlayer()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Ataque += 2;
            Defensa += 2;
        }
    }

    public void BarreraPlayer2()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player2"))
        {
            Ataque += 2;
            Defensa += 2;
        }
    }
}