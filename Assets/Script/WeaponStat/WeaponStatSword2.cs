using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatSword2 : MonoBehaviour
{
    public SkeletonMJ SkeletonMJ;

    void Start()
    {
        SkeletonMJ = GameObject.Find("SkeletonMJ").GetComponent<SkeletonMJ>();
        StatBoost();
    }

    void Update()
    {
    }
    public void StatBoost()
    {
        SkeletonMJ.Atk += 4; // On ajoute les stats de l' arme aux stat du perso
        SkeletonMJ.AtkMag += 4;
    }
}
