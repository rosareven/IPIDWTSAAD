using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private float _totalDaysSpent;
    public Slider daysToSpend;
    public Text metalCount;
    public Text naturalCount;
    public Slider projectTimeSpend;
    public Slider prosperity;
    public Slider resourceGathering;
    public Slider trust;
    public Village village;
    public Slider villageSocialTime;
    public Text weekDisplay;
    public Text woodCount;
    public Text daysSpentWarning;

    private void Start()
    {
        if (village.week == 1)
        {
            // start the first week dialogue
        }
    }

    private void OnGUI()
    {
        trust.value = village.trust;
        prosperity.value = village.prosperity;
        weekDisplay.text = "Week " + village.week;
        _totalDaysSpent = resourceGathering.value + villageSocialTime.value + projectTimeSpend.value;
        daysToSpend.value = 7f - _totalDaysSpent;
        woodCount.text = "Wood: " + village.wood;
        metalCount.text = "Metal: " + village.metal;
        naturalCount.text = "Natural Products: " + village.naturalProducts;
    }

    public void SpendDays(Slider taskBar)
    {
        if (_totalDaysSpent > 7)
            taskBar.value -= 1f;
        Debug.Log(_totalDaysSpent);
    }

    public void NextWeek()
    {
        if (_totalDaysSpent <= daysToSpend.maxValue)
        {
            village.week++;
            GainResource();
            GainVillageTrust();
            GainVillageProsperity();
            daysSpentWarning.GetComponent<Text>().enabled = false;
        }
        else
        {
            daysSpentWarning.GetComponent<Text>().enabled = true;
        }
    }

    public void GainResource()
    {
        for (int i = 0; i < resourceGathering.value; i++)
        {
            village.wood += Random.Range(0, 3);
            village.metal += Random.Range(0, 2);
            village.naturalProducts += Random.Range(0, 4);
        }
    }

    public void GainVillageTrust()
    {
        for (int i = 0; i < villageSocialTime.value; i++)
        {
            village.trust += Random.Range(0,2);
            Debug.Log(village.trust);
        }

        village.trust += Random.Range(-3,0);
        
        if (village.trust > 100) village.trust = 100;
    }
    
    public void GainVillageProsperity()
    {
        village.prosperity += Random.Range(-2, 2);

        if (village.prosperity > 100) village.prosperity = 100;
    }
}