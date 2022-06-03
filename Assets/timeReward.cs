using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timeReward : MonoBehaviour
{
    [SerializeField] private GameObject[] _timeReward;
    [SerializeField] private float[] _timeToHit;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
         _timeToHit[i] = PlayerPrefs.GetFloat("Time " + i);
        }
    }
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
    void Update() => Invoke("TimeDecrease", Time.deltaTime);
    public void TimelyButton(int time)
    {
       if (PlayerPrefs.GetInt("_Time") >= _timeToHit[time])
        {
            //give reward
        }
        else
        {
            Debug.Log((PlayerPrefs.GetInt("_Time") - _timeToHit[time]));
        }
    }

    void TimeDecrease()
    {
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.GetFloat("Time " + i) >= 0)
            {
             PlayerPrefs.SetFloat("Time " + i, _timeToHit[i] -= Time.deltaTime);
            }
        }
    }
}
