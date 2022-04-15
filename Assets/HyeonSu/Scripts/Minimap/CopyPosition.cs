using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    [SerializeField] private bool x, y, z;
    [SerializeField] private Transform target;
    void Update()
    {
        if (!target) return;
        transform.position = new Vector3((x ? target.transform.position.x : transform.position.x), (y ? target.transform.position.y : transform.position.y), (z ? target.transform.position.z : transform.position.z));

    }
}
