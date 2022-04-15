using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour
{
    [SerializeField] int itemNum;
    private bool isCol;
    private void Update()
    {
        if (isCol&&Input.GetKey(KeyCode.F))
        {
            GameManager.Instance.ItemManager(itemNum);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isCol = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isCol = false;   
    }
}
