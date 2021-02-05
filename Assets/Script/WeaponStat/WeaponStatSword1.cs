using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatSword1 : MonoBehaviour
{
    public Player Player;   // On cree une variable public Player

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();    // On recupere les variables de stat de l' objet Player et de sont component Player
        StatBoost();
    }

    void Update()
    {
    }
    public void StatBoost()
    {
        Player.Atk += 4; // On ajoute les stats de l' arme aux stat du perso
        Player.AtkMag += 4;
    }
}
