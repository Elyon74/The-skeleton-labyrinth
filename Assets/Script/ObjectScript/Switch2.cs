using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    BoxCollider Switch2Collider;

    public bool Switchh2 = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Switchh2 = true;

        }
    }
}
