using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonMJ : MonoBehaviour
{
    Animator animations2;
    CapsuleCollider SkeletonMJCollider;

    public Text hpText;
    public Text mpText;
    public Text atkText;
    public Text atkmagText;
    public Text defText;
    public Text defmagText;

    public float attackcooldown;
    public bool isAttacking;
    public float currentcooldown;
    public float attackrange;

    public int Level;
    public string Ennemyname = "SkeletonMJ";

    public bool DeadMJ = false;

    public int HPMax;
    public int CurrentHP;
    public int MPMax;
    public int CurrentMP;

    public int Atk;
    public int AtkMag;
    public int Def;
    public int DefMag;

    public int Vit;
    public int Chc;
    public int Crit;

    public int DamageAmountMJ;

    void Start()
    {
        hpText = GameObject.Find("HP2").GetComponent<Text>();
        mpText = GameObject.Find("MP2").GetComponent<Text>();
        atkText = GameObject.Find("Atk2").GetComponent<Text>();
        atkmagText = GameObject.Find("Atkmag2").GetComponent<Text>();
        defText = GameObject.Find("Def2").GetComponent<Text>();
        defmagText = GameObject.Find("Defmag2").GetComponent<Text>();
        animations2 = GameObject.Find("SkeletonMJ").GetComponent<Animator>();
    }

    void Update()
    {
        hpText.text = CurrentHP.ToString();
        mpText.text = CurrentMP.ToString();
        atkText.text = Atk.ToString();
        atkmagText.text = AtkMag.ToString();
        defText.text = Def.ToString();
        defmagText.text = DefMag.ToString();

        if (CurrentHP <= 0)
        {
            DeadMJ = true;
        }
        if (DeadMJ == true)
        {

        }
        if (isAttacking == true)
        {
            currentcooldown -= Time.deltaTime;
        }
        if (currentcooldown <= 0)
        {
            currentcooldown = attackcooldown;
            isAttacking = false;
        }
    }
    public void Damage(int DamageAmountMJ)
    {
        CurrentHP -= DamageAmountMJ;
    }
    public void Attack()
    {
        if (!isAttacking)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, attackrange))
            {
                ;
            }
        }
        isAttacking = true;
    }
}
