using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulOfTheTree : Monster
{
    [SerializeField] private GameObject WarningSign;
    [SerializeField] private GameObject TreeRoots;
    private bool collisionCheck = true;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
    IEnumerator RootAttack()
    {
        Vector3 PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        GameObject a = Instantiate(WarningSign, PlayerPos - new Vector3(0, PlayerPos.y, 0), Quaternion.Euler(0,0,0));
        yield return new WaitForSeconds(2f);
        Destroy(a);
        Instantiate(TreeRoots, PlayerPos + new Vector3(0, -17.3f, 0), Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(5f);
        StartCoroutine(RootAttack());
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
    private void OnTriggerEnter(Collider other)
    {
        base.OnTriggerStay(other);
        if (other.CompareTag("Player") && playerHoover == false && collisionCheck == true)
        {
            StartCoroutine(RootAttack());
            collisionCheck = false;
        }
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
