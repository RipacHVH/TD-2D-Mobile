using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{


    public static float ProgressBar;
    public static HashSet<AchievementType> achievements = new HashSet<AchievementType>();
    public static int Revives;

    //Announcements
    public static bool Ann2;
    public static bool Ann3;
    public static bool Ann4;
    public static bool Ann5;
    public static bool Ann7;
    public static bool Ann13;


    
    //Levels
    public static int levelWon = 0;
    public static int lvldifficultyCompleted1 = 0;
    public static int lvldifficultyCompleted2 = 0;
    public static int lvldifficultyCompleted3 = 0;
    public static int lvldifficultyCompleted4 = 0;
    public static int lvldifficultyCompleted5 = 0;
    public static int lvldifficultyCompleted6 = 0;
    public static int lvldifficultyCompleted7 = 0;
    public static int lvldifficultyCompleted8 = 0;
    public static int lvldifficultyCompleted9 = 0;
    public static int lvldifficultyCompleted10 = 0;
    public static int lvldifficultyCompleted11 = 0;
    public static int lvldifficultyCompleted12 = 0;
    public static int lvldifficultyCompleted13 = 0;
    public static int lvldifficultyCompleted14 = 0;
    public static int lvldifficultyCompleted15 = 0;
    public static int lvldifficultyCompleted16 = 0;
    public static int lvldifficultyCompleted17 = 0;
    public static int lvldifficultyCompleted18 = 0;

    //scores
    public static int lvlMaxScore1 = 0;
    public static int lvlMaxScore2 = 0;
    public static int lvlMaxScore3 = 0;
    public static int lvlMaxScore4 = 0;
    public static int lvlMaxScore5 = 0;
    public static int lvlMaxScore6 = 0;
    public static int lvlMaxScore7 = 0;
    public static int lvlMaxScore8 = 0;
    public static int lvlMaxScore9 = 0;
    public static int lvlMaxScore10 = 0;
    public static int lvlMaxScore11 = 0;
    public static int lvlMaxScore12 = 0;
    public static int lvlMaxScore13 = 0;
    public static int lvlMaxScore14 = 0;
    public static int lvlMaxScore15 = 0;
    public static int lvlMaxScore16 = 0;
    public static int lvlMaxScore17 = 0;
    public static int lvlMaxScore18 = 0;

    public static int currentDifficulty = 1;
    public static bool ReadAnnouncement = false;
    public static int Stars = 0;
    public static int UnlockedLStage = 0;
    public static bool MusicMuted = false;
    public static bool SFXMuted = false;

    private void Start()
    {
        LoadPlayer();
        Stars = lvldifficultyCompleted1 + lvldifficultyCompleted2 + lvldifficultyCompleted3 + lvldifficultyCompleted4 + lvldifficultyCompleted5 + lvldifficultyCompleted6 +
            lvldifficultyCompleted7 + lvldifficultyCompleted8 + lvldifficultyCompleted9 + lvldifficultyCompleted10 + lvldifficultyCompleted11 + lvldifficultyCompleted12 +
            lvldifficultyCompleted13 + lvldifficultyCompleted14 + lvldifficultyCompleted15 + lvldifficultyCompleted16 + lvldifficultyCompleted17 + lvldifficultyCompleted18;
        SavePlayer();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        ProgressBar = data.ProgressBar;
        Revives = data.Revives;
        achievements = data.achievements;

        //Announcements
        Ann2 = data.Ann2;
        Ann3 = data.Ann3;
        Ann4 = data.Ann4;
        Ann5 = data.Ann5;
        Ann7 = data.Ann7;
        Ann13 = data.Ann13;

        //Levels
        levelWon = data.levelWon;
        lvldifficultyCompleted1 = data.lvldifficultyCompleted1;
        lvldifficultyCompleted2 = data.lvldifficultyCompleted2;
        lvldifficultyCompleted3 = data.lvldifficultyCompleted3;
        lvldifficultyCompleted4 = data.lvldifficultyCompleted4;
        lvldifficultyCompleted5 = data.lvldifficultyCompleted5;
        lvldifficultyCompleted6 = data.lvldifficultyCompleted6;
        lvldifficultyCompleted7 = data.lvldifficultyCompleted7;
        lvldifficultyCompleted8 = data.lvldifficultyCompleted8;
        lvldifficultyCompleted9 = data.lvldifficultyCompleted9;
        lvldifficultyCompleted10 = data.lvldifficultyCompleted10;
        lvldifficultyCompleted11 = data.lvldifficultyCompleted11;
        lvldifficultyCompleted12 = data.lvldifficultyCompleted12;
        lvldifficultyCompleted13 = data.lvldifficultyCompleted13;
        lvldifficultyCompleted14 = data.lvldifficultyCompleted14;
        lvldifficultyCompleted15 = data.lvldifficultyCompleted15;
        lvldifficultyCompleted16 = data.lvldifficultyCompleted16;
        lvldifficultyCompleted17 = data.lvldifficultyCompleted17;
        lvldifficultyCompleted18 = data.lvldifficultyCompleted18;

        //scores
        lvlMaxScore1 = data.lvlMaxScore1;
        lvlMaxScore2 = data.lvlMaxScore2;
        lvlMaxScore3 = data.lvlMaxScore3;
        lvlMaxScore4 = data.lvlMaxScore4;
        lvlMaxScore5 = data.lvlMaxScore5;
        lvlMaxScore6 = data.lvlMaxScore6;
        lvlMaxScore7 = data.lvlMaxScore7;
        lvlMaxScore8 = data.lvlMaxScore8;
        lvlMaxScore9 = data.lvlMaxScore9;
        lvlMaxScore10 = data.lvlMaxScore10;
        lvlMaxScore11 = data.lvlMaxScore11;
        lvlMaxScore12 = data.lvlMaxScore12;
        lvlMaxScore13 = data.lvlMaxScore13;
        lvlMaxScore14 = data.lvlMaxScore14;
        lvlMaxScore15 = data.lvlMaxScore15;
        lvlMaxScore16 = data.lvlMaxScore16;
        lvlMaxScore17 = data.lvlMaxScore17;
        lvlMaxScore18 = data.lvlMaxScore18;


        currentDifficulty = data.currentDifficulty;
        ReadAnnouncement = data.ReadAnnouncement;
        Stars = data.Stars;
        UnlockedLStage = data.UnlockedLStage;
        MusicMuted = data.MusicMuted;
        SFXMuted = data.SFXMuted;
    }

    public void ResetSave()
    {
        SaveSystem.ResetSave();
        Application.Quit();
    }
    public void addLevel()
    {
        levelWon++;

        SavePlayer();
    }
}
