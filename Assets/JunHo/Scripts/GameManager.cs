using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ItemManager(int num)
    {
        switch (num)
        {
            case 1:
                GameObject.Find("Player").GetComponent<Player>().Cur_HP += 10;
                break;
            case 2:
                GameObject.Find("Player").GetComponent<Player>().Speed += 5;
                break;
            case 3:
                //���� && ���� ����
                break;
            case 4:
                //���̴�
                break;
            case 5:
                //�ڷ���Ʈ
                break;
        }
    }
}