using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plastic : MonoBehaviour
{
    private bool skillType = false;
    private void Update()
    {
        if(skillType == false)
            transform.position += transform.right * Time.deltaTime;
        else
        {
            gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position * 0.3f);
            transform.position += transform.right * Time.deltaTime;
        }
    }
}
