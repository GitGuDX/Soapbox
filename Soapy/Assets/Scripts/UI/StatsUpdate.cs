using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUpdate : MonoBehaviour
{
    public Main main;
    public Image moneyStat;
    public Image popularityStat;
    public Image qualityStat;
    public Image governmentStat;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMoneyBar();
    }

    void UpdateMoneyBar() {
      moneyStat.fillAmount =  main.money / 200;

      popularityStat.fillAmount = main.popularity /200;
      qualityStat.fillAmount = main.quality /200;
      governmentStat.fillAmount = main.quality /200;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoneyBar();
    }
}
