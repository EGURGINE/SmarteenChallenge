using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [Header("이동 속도")]
    public float Speed;

    [Header("점프")]
    public float Jump;
    public float Gravity = -9.81f;
    public float Y_velopcity;

    [Header("체력")]
    public Slider HP_Slider;
    public float Cur_HP;
    public float Max_HP;

    CharacterController CC;

    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Y_velopcity += Gravity * Time.deltaTime;
        if (CC.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Y_velopcity = Jump;
            }
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();
        dir.y = Y_velopcity;
        CC.Move(dir * Speed * Time.deltaTime);
    }
}
