using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckArmor : MonoBehaviour
{
    // On cree une variable priver integer nombre sans virgule de l' ID de l' armure
    // float a contrario est un nombre a virgule
    private int ArmorID;
    // On cree une liste d' armures
    [SerializeField]
    public List<GameObject> armorlist = new List<GameObject>();

    void Update()
    {
        if (transform.childCount > 0)   // On dit que le script attacher au slot cherche a savoir si il a au moins un enfant si oui on creer un id
            // A faire pour chaque nouvelle arme i = x correspond a l' id de l' arme dans l' index
        {
            ArmorID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;   // On recupere dans notre liste d' arme lobjet attacher a l' enfant et sont id
        }
        if (ArmorID == 1 && transform.childCount > 0)  // Ici on change le numero d' id pour chaque arme
        {
            for (int i = 0; i < armorlist.Count; i++)   // i = 0 represente le slot de larmure
            {
                if (i != 0)
                {
                    armorlist[i].SetActive(false); // Si l' id n' est pas egal a celui de l'arme larme est desactiver
                }
                else
                {
                    armorlist[i].SetActive(true);  // Si l' id est egal a celui de l'arme larme est activer
                }
            }
        }
    }
}