using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timeReward : MonoBehaviour
{
    [SerializeField] private GameObject[] _timeReward;
    [SerializeField] private float[] _timeToHit;
    public void TimeRewardMethod()
    {
        for (int i = 0; i < _timeReward.Length; i++)
        {
            Slider timerSlider = _timeReward[i].transform.Find("Slider").GetComponent<Slider>();
            TMP_Text timeToHitText = _timeReward[i].transform.Find("timer to hit").GetComponent<TMP_Text>();

            if (timerSlider && timeToHitText)
            {
                timerSlider.maxValue = _timeToHit[i];
                timerSlider.value = timerSlider.maxValue;

                timeToHitText.text = timerSlider.value.ToString("f1") + " S";
            }
        }
    }
    void Update()
    {
         for (int i = 0; i < _timeToHit.Length; i++)
        {
            if (_timeToHit[i] > 0)
            {
              _timeToHit[i] -= Time.deltaTime;
            }
        }
    }
}
