using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{
    BoxCollider Key1Collider;

    public bool Keyy1 = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
           Keyy1 = true;

        }
    }
}