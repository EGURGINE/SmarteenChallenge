using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoover : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("ª°æ∆µÈ¿Ã±‚");

            if (Input.GetMouseButton(0))
            {
                Debug.Log("ª°æ∆µÈ¿Ã±‚");
            }
        }
    }
}
