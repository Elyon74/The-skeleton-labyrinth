using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGate2 : MonoBehaviour
{
    public Switch2 Switch2;

    void Start()
    {
        Switch2 = GameObject.Find("Switch2").GetComponent<Switch2>();
    }

    void Update()
    {
        if (Switch2.Switchh2 == true)
        {
            this.gameObject.transform.Rotate(new Vector3(0.0f, Time.deltaTime * 50f, 0.0f), Space.World);
        }
    }
}
