using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class level : MonoBehaviour
{
    public int levelIndex = 0;
    [SerializeField] private GameObject[] _levels;
    [SerializeField] private Color _color;
    void Awake()
    {
        levelIndex = PlayerPrefs.GetInt("levelIndex");
    }
    void Start()
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            RawImage currentRawImage = _levels[levelIndex].GetComponent<RawImage>(); // current RawImage
            Button currentButton = _levels[levelIndex].GetComponent<Button>(); // Current Button
            RawImage youAreAt = _levels[levelIndex].transform.Find("RawImage").GetComponent<RawImage>(); // Current You are image
            
            if (currentButton)
            {
                if (currentRawImage)
                {
                   currentRawImage.color = _color;

                    if (levelIndex <= i)
                    {
                       currentButton.interactable = true;
                       youAreAt.gameObject.SetActive(true);
                    }
                    else
                    {
                        _levels[i].GetComponent<Button>().interactable = false; // All buttons
                        _levels[i].transform.Find("RawImage").gameObject.SetActive(false); // All You are image
                    }
                }
            }
        }
    }
}
