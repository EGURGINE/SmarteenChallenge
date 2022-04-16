using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyFish : Monster
{
    [SerializeField] private GameObject Plastic;

    protected virtual void Start()
    {
        StartCoroutine(ShotPlastic());
    }

    IEnumerator ShotPlastic()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(Plastic, transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(Plastic, transform.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        Instantiate(Plastic, transform.position, transform.rotation);
        StartCoroutine(ShotPlastic());
    }
}
