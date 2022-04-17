using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrash : Monster
{
    Renderer FoodTrashMTR;
    [SerializeField] private GameObject Veneer;
    protected override void Start()
    {
        base.Start();
        FoodTrashMTR = GetComponent<Renderer>();
    }
    protected override void Update()
    {
        base.Update();
    }

    IEnumerator SelfExplosion()
    {
        for (int i = 0; i <= 5; i++)
        {
        FoodTrashMTR.material.color = new Color(1, 1, 0, 150 / 255f);
        yield return new WaitForSeconds(0.5f);
        FoodTrashMTR.material.color = new Color(1, 1, 0 , 1);
        yield return new WaitForSeconds(0.5f);
        }
        Instantiate(Veneer,transform.position, transform.rotation);
        Destroy(gameObject);
    }

    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
    }
    private void OnTriggerEnter(Collider other)
    {
        base.OnTriggerStay(other);
        if (other.CompareTag("Player") && playerHoover == false)
            StartCoroutine(SelfExplosion());
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
