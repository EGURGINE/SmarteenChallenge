using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashVeneer : MonoBehaviour
{
    [SerializeField] private GameObject Dregs;
    private void Start()
    {
        Vector3 abc = transform.position;
        abc.y = 1;
        StartCoroutine(DregsRecell());
    }
    
    IEnumerator DregsRecell()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i <= 4; i++)
        {
            Instantiate(Dregs, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.7f);
        }
        Destroy(gameObject);
    }
}
