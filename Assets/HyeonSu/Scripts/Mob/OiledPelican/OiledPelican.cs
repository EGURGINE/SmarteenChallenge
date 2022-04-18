using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OiledPelican : Monster
{
    [SerializeField] private GameObject OilLaserObj;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(OilLaser());
    }
    protected override void Update()
    {
        base.Update();
    }
    IEnumerator OilLaser()
    {
        OilLaserObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        OilLaserObj.SetActive(false);
        yield return new WaitForSeconds(3f);
        StartCoroutine(OilLaser());
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }
    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
    }
}
