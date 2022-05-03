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
            PlHoover();
        }
        else hoover = 0;
    }
    void PlHoover()
    {
        switch (hoover)
        {
            case 4:
                transform.position = Vector3.MoveTowards(transform.position, PlayerHoover.transform.position, 6.5f * Time.deltaTime);
                break;
            case 3:
                transform.position = Vector3.MoveTowards(transform.position, PlayerHoover.transform.position, 6f * Time.deltaTime);
                break;
            case 2:
                transform.position = Vector3.MoveTowards(transform.position, PlayerHoover.transform.position, 5.5f * Time.deltaTime);

                break;
            case 1:
                transform.position = Vector3.MoveTowards(transform.position, PlayerHoover.transform.position, 5f * Time.deltaTime);
                break;
        }
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
            hoover = 4;
            Debug.Log(hoover);
            playerHoover = true;
            transform.DOScale(0.01f, 0.5f).SetEase(Ease.OutBounce);

        }
        else if (other.CompareTag("PlayerHoover3") && Input.GetMouseButton(0))
        {
            hoover = 3;
            Debug.Log(hoover);
            playerHoover = true;
            transform.DOScale(0.5f, 2f).SetEase(Ease.OutBounce);

        }
        else if (other.CompareTag("PlayerHoover2") && Input.GetMouseButton(0))
        {
            hoover = 2;
            Debug.Log(hoover);
            playerHoover = true;
        }
        else if (other.CompareTag("PlayerHoover1") && Input.GetMouseButton(0))
        {
            hoover = 1;
            Debug.Log(hoover);
            playerHoover = true;
        }
        else if (other.CompareTag("PlayerHoover") && Input.GetMouseButton(0))
        {
            GameManager.Instance.environmentalGaugeCur++;
            Debug.Log("end");
            Destroy(gameObject);

        }
        else
        {

            playerHoover = false;
            hoover = 0;
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