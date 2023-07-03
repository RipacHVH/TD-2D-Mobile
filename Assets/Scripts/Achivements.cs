using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum AchievementType
{
    None,
    ReviveYourself10,
    ReviveYourself20,
    ReviveYourself40,
    ReviveYourself50,
    Stars17,
    Stars34,
    GetAllStars,
    Levels6,
    Levels12,
    GetAllLevels,
    Scorelvl1,
    Scorelvl2,
    Scorelvl3,
    Scorelvl4,
    Scorelvl5,
    Scorelvl6,
    Scorelvl7,
    Scorelvl8,
    Scorelvl9,
    Scorelvl10,
    Scorelvl11,
    Scorelvl12,
    Scorelvl13,
    Scorelvl14,
    Scorelvl15,
    Scorelvl16,
    Scorelvl17,
    Scorelvl18,
    Scorelvl19,
    Scorelvl20,
    Scorelvl21,
    Scorelvl22,
    Scorelvl23,
    Scorelvl24,
    Scorelvl25,
    Scorelvl26,
    Scorelvl27,
    Scorelvl28,

    // Add more achievements here...
}

public class Achivements : MonoBehaviour
{
    public Button[] Claim;
    public Slider slider;
    public TextMeshProUGUI Percentage;

    private void Start()
    {
        FindObjectOfType<PlayerStats>().LoadPlayer();
        Percentage.text = PlayerStats.ProgressBar.ToString("N0") + "%";
        slider.value = PlayerStats.ProgressBar / 100;
        // Enable all buttons by default
        foreach (Button button in Claim)
        {
            if (button != null)
                button.interactable = false;
        }
    }

    void FixedUpdate()
    {
        Revives();
        Stars();
        Levels();
        Scores();

        // Check for other achievements and update the UI accordingly...
    }

    public void ClaimAchievement(int achievement)
    {
        AchievementType achievementType = (AchievementType)achievement;
        PlayerStats.ProgressBar += 3.57f;
        slider.value = PlayerStats.ProgressBar/100;
        Percentage.text = PlayerStats.ProgressBar.ToString("N0") + "%";
        PlayerStats.achievements.Add(achievementType);
        Claim[(int)achievementType].image.enabled = false;
        GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
    }

    private void Revives()
    {
        //REVIVES
        if (PlayerStats.Revives >= 10 && !PlayerStats.achievements.Contains(AchievementType.ReviveYourself10))
        {
            Claim[(int)AchievementType.ReviveYourself10].interactable = true;
        }
        if (PlayerStats.Revives >= 20 && !PlayerStats.achievements.Contains(AchievementType.ReviveYourself20))
        {
            Claim[(int)AchievementType.ReviveYourself20].interactable = true;
        }
        if (PlayerStats.Revives >= 40 && !PlayerStats.achievements.Contains(AchievementType.ReviveYourself40))
        {
            Claim[(int)AchievementType.ReviveYourself40].interactable = true;
        }
        if (PlayerStats.Revives >= 50 && !PlayerStats.achievements.Contains(AchievementType.ReviveYourself50))
        {
            Claim[(int)AchievementType.ReviveYourself50].interactable = true;
        }

        if (PlayerStats.achievements.Contains(AchievementType.ReviveYourself10))
        {
            Claim[(int)AchievementType.ReviveYourself10].image.enabled = false;
        }
        if (PlayerStats.achievements.Contains(AchievementType.ReviveYourself20))
        {
            Claim[(int)AchievementType.ReviveYourself20].image.enabled = false;
        }
        if (PlayerStats.achievements.Contains(AchievementType.ReviveYourself40))
        {
            Claim[(int)AchievementType.ReviveYourself40].image.enabled = false;
        }
        if (PlayerStats.achievements.Contains(AchievementType.ReviveYourself50))
        {
            Claim[(int)AchievementType.ReviveYourself50].image.enabled = false;
        }

    }
    private void Stars()
    {
        if (PlayerStats.Stars >= 54 && !PlayerStats.achievements.Contains(AchievementType.GetAllStars))
        {
            Claim[(int)AchievementType.GetAllStars].interactable = true;
        }
        if (PlayerStats.Stars >= 34 && !PlayerStats.achievements.Contains(AchievementType.Stars34))
        {
            Claim[(int)AchievementType.Stars34].interactable = true;
        }
        if (PlayerStats.Stars >= 17 && !PlayerStats.achievements.Contains(AchievementType.Stars17))
        {
            Claim[(int)AchievementType.Stars17].interactable = true;
        }

        if (PlayerStats.achievements.Contains(AchievementType.GetAllStars))
        {
            Claim[(int)AchievementType.GetAllStars].image.enabled = false;
        }
        if (PlayerStats.achievements.Contains(AchievementType.Stars34))
        {
            Claim[(int)AchievementType.Stars34].image.enabled = false;
        }
        if (PlayerStats.achievements.Contains(AchievementType.Stars17))
        {
            Claim[(int)AchievementType.Stars17].image.enabled = false;
        }

    }
    private void Levels()
    {
            if (PlayerStats.levelWon >= 6 && !PlayerStats.achievements.Contains(AchievementType.Levels6))
        {
            Claim[(int)AchievementType.Levels6].interactable = true;
        }
        if (PlayerStats.levelWon >= 12 && !PlayerStats.achievements.Contains(AchievementType.Levels12))
        {
            Claim[(int)AchievementType.Levels12].interactable = true;
        }
        if (PlayerStats.levelWon >= 18 && !PlayerStats.achievements.Contains(AchievementType.GetAllLevels))
        {
            Claim[(int)AchievementType.GetAllLevels].interactable = true;
        }

        if (PlayerStats.achievements.Contains(AchievementType.Levels6))
        {
            Claim[(int)AchievementType.Levels6].image.enabled = false;
        }
        if (PlayerStats.achievements.Contains(AchievementType.Levels12))
        {
            Claim[(int)AchievementType.Levels12].image.enabled = false;
        }
        if (PlayerStats.achievements.Contains(AchievementType.GetAllLevels))
        {
            Claim[(int)AchievementType.GetAllLevels].image.enabled = false;
        }
    }
    private void Scores()
    {
        if (PlayerStats.lvlMaxScore1 >= 400 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl1))
            Claim[(int)AchievementType.Scorelvl1].interactable = true;
        if (PlayerStats.lvlMaxScore2 >= 400 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl2))
            Claim[(int)AchievementType.Scorelvl2].interactable = true;
        if (PlayerStats.lvlMaxScore3 >= 800 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl3))
            Claim[(int)AchievementType.Scorelvl3].interactable = true;
        if (PlayerStats.lvlMaxScore4 >= 800 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl4))
            Claim[(int)AchievementType.Scorelvl4].interactable = true;
        if (PlayerStats.lvlMaxScore5 >= 1200 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl5))
            Claim[(int)AchievementType.Scorelvl5].interactable = true;
        if (PlayerStats.lvlMaxScore6 >= 1000 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl6))
            Claim[(int)AchievementType.Scorelvl6].interactable = true;
        if (PlayerStats.lvlMaxScore7 >= 1600 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl7))
            Claim[(int)AchievementType.Scorelvl7].interactable = true;
        if (PlayerStats.lvlMaxScore8 >= 1600 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl8))
            Claim[(int)AchievementType.Scorelvl8].interactable = true;
        if (PlayerStats.lvlMaxScore9 >= 1200 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl9))
            Claim[(int)AchievementType.Scorelvl9].interactable = true;
        if (PlayerStats.lvlMaxScore10 >= 1480 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl10))
            Claim[(int)AchievementType.Scorelvl10].interactable = true;
        if (PlayerStats.lvlMaxScore11 >= 1600 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl11))
            Claim[(int)AchievementType.Scorelvl11].interactable = true;
        if (PlayerStats.lvlMaxScore12 >= 1720 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl12))
            Claim[(int)AchievementType.Scorelvl12].interactable = true;
        if (PlayerStats.lvlMaxScore13 >= 2000 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl13))
            Claim[(int)AchievementType.Scorelvl13].interactable = true;
        if (PlayerStats.lvlMaxScore14 >= 2000 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl14))
            Claim[(int)AchievementType.Scorelvl14].interactable = true;
        if (PlayerStats.lvlMaxScore15 >= 2200 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl15))
            Claim[(int)AchievementType.Scorelvl15].interactable = true;
        if (PlayerStats.lvlMaxScore16 >= 2400 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl16))
            Claim[(int)AchievementType.Scorelvl16].interactable = true;
        if (PlayerStats.lvlMaxScore17 >= 1600 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl17))
            Claim[(int)AchievementType.Scorelvl17].interactable = true;
        if (PlayerStats.lvlMaxScore18 >= 4000 && !PlayerStats.achievements.Contains(AchievementType.Scorelvl18))
            Claim[(int)AchievementType.Scorelvl18].interactable = true;


        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl1))
            Claim[(int)AchievementType.Scorelvl1].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl2))
            Claim[(int)AchievementType.Scorelvl2].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl3))
            Claim[(int)AchievementType.Scorelvl3].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl4))
            Claim[(int)AchievementType.Scorelvl4].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl5))
            Claim[(int)AchievementType.Scorelvl5].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl6))
            Claim[(int)AchievementType.Scorelvl6].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl7))
            Claim[(int)AchievementType.Scorelvl7].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl8))
            Claim[(int)AchievementType.Scorelvl8].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl9))
            Claim[(int)AchievementType.Scorelvl9].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl10))
            Claim[(int)AchievementType.Scorelvl10].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl11))
            Claim[(int)AchievementType.Scorelvl11].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl12))
            Claim[(int)AchievementType.Scorelvl12].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl13))
            Claim[(int)AchievementType.Scorelvl13].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl14))
            Claim[(int)AchievementType.Scorelvl14].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl15))
            Claim[(int)AchievementType.Scorelvl15].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl16))
            Claim[(int)AchievementType.Scorelvl16].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl17))
            Claim[(int)AchievementType.Scorelvl17].image.enabled = false;
        if (PlayerStats.achievements.Contains(AchievementType.Scorelvl18))
            Claim[(int)AchievementType.Scorelvl18].image.enabled = false;

    }
}