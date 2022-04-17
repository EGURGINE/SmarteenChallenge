using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [SerializeField] private Slider environmentalGauge;
    public float environmentalGaugeMax;
    public float environmentalGaugeCur;

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
