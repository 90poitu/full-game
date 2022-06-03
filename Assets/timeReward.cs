using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timeReward : MonoBehaviour
{
    [SerializeField] private GameObject[] _timeReward;
    [SerializeField] private float[] _timeToHit;
    void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("Time " + i))
            {
                _timeToHit[0] = 100;
                _timeToHit[1] = 99;
                _timeToHit[2] = 66;
                _timeToHit[3] = 99;
                _timeToHit[4] = 33;
            }
        }
    }
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("Time " + i))
            {
                _timeToHit[i] = PlayerPrefs.GetFloat("Time " + i);
            }
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
                timerSlider.maxValue = 200;
                timerSlider.value = _timeToHit[i];

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
