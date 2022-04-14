using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private GameObject PlayerObj;
    private Rigidbody rb;
    private bool playerDetect = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        InvokeRepeating("MoveTurn", 0, 2);
    }

    void Update()
    {

        if (playerDetect == false)
        {
            this.transform.position += transform.right * Time.deltaTime * 3;

        }
    }

    void MoveTurn()
    {
        this.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerDetect = true;
            gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
            this.transform.position = Vector3.MoveTowards(this.transform.position, PlayerObj.transform.position, 5 * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            MoveTurn();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerDetect = false;
        }
    }
}