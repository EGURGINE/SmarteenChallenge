using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoover : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && Input.GetMouseButton(0))
        {
            other.GetComponent<Monster>().playerHoover = true;
            Debug.Log("½ÇÇà");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Monster>().playerHoover = false;
        }
    }
}
