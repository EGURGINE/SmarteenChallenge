using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRoots : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f);
    }
    void Update()
    {
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 35f;
    }
}
