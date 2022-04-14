using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [Header("�̵� �ӵ�")]
    public float Speed;

    [Header("����")]
    public float Jump;
    public float Gravity = -9.81f;
    public float Y_velopcity;

    [Header("ü��")]
    public Slider HP_Slider;
    public Text HP_Text;
    public float Cur_HP;
    public float Max_HP;

    CharacterController CC;

    void Start()
    {
        Cur_HP = 100f;
        Max_HP = 100f;

        CC = GetComponent<CharacterController>();
        HP_Handle();
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

    public void HP_Handle()
    {
        HP_Slider.value = (float)Cur_HP / (float)Max_HP;
    }
}