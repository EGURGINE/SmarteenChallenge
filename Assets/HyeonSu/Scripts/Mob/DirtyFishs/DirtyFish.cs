using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyFish : Monster
{
    [SerializeField] private GameObject Plastic;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(ShotPlastic());
    }
    protected override void Update()
    {
        base.Update();
    }
    IEnumerator ShotPlastic()
    {
        yield return new WaitForSeconds(2.5f);
        Instantiate(Plastic, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.6f);
        Instantiate(Plastic, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.6f);
        Instantiate(Plastic, transform.position, transform.rotation);
        StartCoroutine(ShotPlastic());
    }
    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
