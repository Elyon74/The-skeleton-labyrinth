using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatSword1 : MonoBehaviour
{
    public int Atq = 5;
    public int MAtq = 5;

    void Start()
    {
        GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        
    }
    public void StatBoost()
    {
        // Atk += 5; On applique les stats de l' arme aux stat du perso
        // AtkMag += 5;
    }
}
