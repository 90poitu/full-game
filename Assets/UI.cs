using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    [SerializeField] private level _level;
    public GameObject[] panels;
    [SerializeField] private TMP_Text _levelIndexText;
    [SerializeField] private TMP_Text _TimeText;
    [SerializeField] private TMP_Text _DateTimeText;
    [SerializeField] private float _Time;
    [SerializeField] private string _date;
    void Awake()
    {
        _Time = PlayerPrefs.GetFloat("_Time");
        _date = System.DateTime.Today.Date.ToString("M/d/yyyy");
        if (_DateTimeText)
        {
            _DateTimeText.text = _date;
            
        }
    }
    void Update()
    {
        PlayerPrefs.SetFloat("_Time", _Time += Time.deltaTime);
        
        if (_levelIndexText)
        {
        _levelIndexText.text = "0" + _level.levelIndex.ToString("f0");
        }
        if (_TimeText)
        {
          _TimeText.text = PlayerPrefs.GetFloat("_Time").ToString("f1");
        }
    }
}
