using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public enum buttonName
    {
        Level_Exit,
        Play,
        Reward_Exit,
        Reward_Enter,
    }
    [SerializeField] private UI _UI;
    [SerializeField] private buttonName _enum;
    [SerializeField] private level _level;
    [SerializeField] private timeReward _timeReward;
        public void buttonActivate(int enumIndex)
    {
        switch(enumIndex)
        {
            case 0:
            _UI.panels[0].SetActive(true);
            _enum = buttonName.Play;
            break;
            case 1:
            _UI.panels[0].SetActive(false);
            _enum = buttonName.Level_Exit;
            break;
            case 2:
            _UI.panels[1].SetActive(true);
            _enum = buttonName.Reward_Enter;
            break;
            case 3:
            _UI.panels[1].SetActive(false);
            _enum = buttonName.Reward_Exit;
            break;
            case 4:
            _timeReward.TimeRewardMethod();
            break;
        }
    }
        public void levelActivated(int levelIndex)
    {
            if (_level.levelIndex + 1 >= levelIndex)
            {
                SceneManager.LoadSceneAsync(levelIndex);
                Debug.Log("Level activate");
                PlayerPrefs.SetInt("levelIndex", levelIndex);
            }
            else
            {
                Debug.Log("Failed to load level index " + levelIndex);
            }
    }
}
