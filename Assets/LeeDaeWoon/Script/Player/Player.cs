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
    public Text HP_Text;
    public float Cur_HP;
    public float Max_HP;

    [Header("카메라")]
    public float Rotation_Speed;
    private float Rx;
    private float Ry;

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
        Camera_Rotation();
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
        dir = Camera.main.transform.TransformDirection(dir);
        dir.Normalize();
        dir.y = Y_velopcity;
        CC.Move(dir * Speed * Time.deltaTime);
    }

    public void Camera_Rotation()
    {
        float Mx = Input.GetAxis("Mouse X");
        float My = Input.GetAxis("Mouse Y");

        Rx += Rotation_Speed * My * Time.deltaTime;
        Ry += Rotation_Speed * Mx * Time.deltaTime;

        Rx = Mathf.Clamp(Rx, -80f, 80f);

        transform.eulerAngles = new Vector3(-Rx, Ry, 0f);
    }

    public void HP_Handle()
    {
        HP_Slider.value = (float)Cur_HP / (float)Max_HP;
    }
}
