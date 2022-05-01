using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : MonoBehaviour
{
    [SerializeField] private GameObject PlayerHoover;
    private bool playerDetect = false;
    public bool playerHoover = false;
    private int hoover = 0;

    private float hooverCnt;
    protected virtual void Start()
    {
        InvokeRepeating("MoveTurn", 0, 2);
        //GameManager.Instance.environmentalGaugeMax++;
    }

    protected virtual void Update()
    {
        if (playerDetect == false && playerHoover == false)
        {
            this.transform.position += transform.forward * Time.deltaTime * 3;
        }
        if (playerHoover)
        {
            switch (hoover)
            {
                case 4:

                    break;
                case 3:
                    break;
                case 2:
                    break;
                case 1:
                    break;
            }
            hooverCnt += Time.deltaTime;
            if (hooverCnt > 3)
            {
                hooverCnt = 0;
                GameManager.Instance.environmentalGaugeCur++;
                Destroy(gameObject);
            }
            PlHoover();
        }
        else
        {
            hooverCnt = 0;
            hoover = 0;
        }
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
            CancelInvoke("MoveTurn");
            gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
            this.transform.position = Vector3.MoveTowards(this.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 5 * Time.deltaTime);
        }
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            MoveTurn();
        }
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHoover4")&&Input.GetMouseButton(0))
        {
            playerHoover = true;
            hoover = 4;
        }
        if (other.CompareTag("PlayerHoover3") && Input.GetMouseButton(0))
        {
            playerHoover = true;
            hoover = 3;


        }
        if (other.CompareTag("PlayerHoover2") && Input.GetMouseButton(0))
        {
            playerHoover = true;
            hoover = 2;

        }
        if (other.CompareTag("PlayerHoover") && Input.GetMouseButton(0))
        {
            playerHoover = true;
            hoover = 1;

        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetect = false;
            InvokeRepeating("MoveTurn", 0, 2);
        }
    }
}