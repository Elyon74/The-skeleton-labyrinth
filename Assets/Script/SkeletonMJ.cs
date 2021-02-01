using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonMJ : MonoBehaviour
{
    public int Level = 1;
    public string Ennemyname = "SkeletonMJ";
    public int HPMaxMJ = 10;
    public int CurrentHPMJ = 10;

    public bool DeadMJ = false;

    public int HPMax = 10;
    public int CurrentHP = 10;
    public int MPMax = 10;
    public int CurrentMP = 10;

    public int Atk = 1;
    public int AtkMag = 1;
    public int Def = 1;
    public int DefMag = 1;

    public int Vit = 1;
    public int Chc = 1;
    public int Crit = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if (CurrentHPMJ <= 0)
        {
            DeadMJ = true;
        }
        if (DeadMJ == true)
        {

        }
    }
    public void Damage(int DamageAmountMJ)
    {
        CurrentHPMJ -= DamageAmountMJ;
    }
}
