using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    [Header("환경게이지")]
    [SerializeField] private Slider environmentalGauge;
    public float environmentalGaugeMax;
    public float environmentalGaugeCur;

    [Header("플레이어 속성")]
    private int hooverUp;
    [SerializeField] private BoxCollider playerHoover;
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
        if (Input.GetKey(KeyCode.F))
        {
            ItemManager(3);
        }
        SliderManager();
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
                if (hooverUp >= 5) return;

                playerHoover.size =new Vector3(playerHoover.size.x, playerHoover.size.y, playerHoover.size.z+1);
                playerHoover.center = new Vector3(playerHoover.center.x, playerHoover.center.y, playerHoover.center.z + 0.5f);
                hooverUp++;
                //공속 && 범위 증가
                break;
            case 4:
                //레이더
                break;
            case 5:
                //텔레포트
                break;
        }
    }
    private void SliderManager()
    {
        environmentalGauge.value = environmentalGaugeCur/environmentalGaugeMax;
    }
}
