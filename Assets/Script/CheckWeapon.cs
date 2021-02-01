using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWeapon : MonoBehaviour
{
    // On cree une variable priver integer nombre sans virgule de l' ID de l' arme
    // float a contrario est un nombre a virgule
    private int WeaponID;
    // On cree une liste des armes
    [SerializeField]
    public List<GameObject> weaponlist = new List<GameObject>();

    void Update()
    {
        if (transform.childCount > 0)   // On dit que le script attacher au slot cherche a savoir si il a au moins un enfant si oui on creer un id
        // A faire pour chaque nouvelle arme i = x correspond a l' id de l' arme dans l' index
        {
            WeaponID = gameObject.GetComponentInChildren<ItemOnObject>().item.itemID;   // On recupere dans notre liste d' arme lobjet attacher a l' enfant et sont id
        }
        if (WeaponID == 1 && transform.childCount > 0)  // Ici on change le numero d' id pour chaque arme
        {
            for (int i = 0; i < weaponlist.Count; i++)  //i = 0 represente le slot de larme
            {
                if (i !=0)
                {
                    weaponlist[i].SetActive(false); // Si l' id n' est pas egal a celui de l'arme larme est desactiver
                }
                else
                {
                    weaponlist[i].SetActive(true);  // Si l' id est egal a celui de l'arme larme est activer
                }
            }
        }
    }
}
