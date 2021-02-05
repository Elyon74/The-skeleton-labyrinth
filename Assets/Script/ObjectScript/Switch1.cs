using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch1 : MonoBehaviour
{
    BoxCollider Switch1Collider;

    public bool Switchh1 = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Switchh1 = true;

        }
    }
}
