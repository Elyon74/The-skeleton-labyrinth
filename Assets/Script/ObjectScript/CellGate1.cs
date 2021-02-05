using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGate1 : MonoBehaviour
{
    BoxCollider CellGate1Collider;

    public Switch1 Switch1;
    void Start()
    {
        Switch1 = GameObject.Find("Switch1").GetComponent<Switch1>();
    }

    void Update()
    {
        // if (Switchh1 == true)
        {
            ;
        }
    }
}
