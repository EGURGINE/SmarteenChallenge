using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private GameObject PlayerObj;
    [SerializeField] private GameObject PlayerHoover;
    private bool playerDetect = false;
    public bool playerHoover = false;
    private float hooverCnt;
    void Start()
    {
        InvokeRepeating("MoveTurn", 0, 2);
    }

    void Update()
    {
        if (playerDetect == false && playerHoover == false)
        {
            this.transform.position += transform.right * Time.deltaTime * 3;
        }
        if (playerHoover)
        {
            hooverCnt += Time.deltaTime;
            if (hooverCnt>3)
            {
                hooverCnt = 0;
                Destroy(gameObject);
            }
            PlHoover();
        }
        else hooverCnt = 0;
    }
    void PlHoover()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerHoover.transform.position, 0.5f*Time.deltaTime);
    }
    void MoveTurn()
    {
        if (playerHoover==false)
        {
            this.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
    }
    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerHoover ==false)
        {
            playerDetect = true;
            gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
            this.transform.position = Vector3.MoveTowards(this.transform.position, PlayerObj.transform.position, 5 * Time.deltaTime);
        }
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            MoveTurn();
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetect = false;
        }
    }
}