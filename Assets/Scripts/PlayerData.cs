using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    //achievements
    public float ProgressBar;
    public HashSet<AchievementType> achievements = new HashSet<AchievementType>();
    public int Revives;


    //Announcements
    public bool Ann2;
    public bool Ann3;
    public bool Ann4;
    public bool Ann5;
    public bool Ann7;
    public bool Ann13;

    //Levels
    public int levelWon;
    public int lvldifficultyCompleted1;
    public int lvldifficultyCompleted2;
    public int lvldifficultyCompleted3;
    public int lvldifficultyCompleted4;
    public int lvldifficultyCompleted5;
    public int lvldifficultyCompleted6;
    public int lvldifficultyCompleted7;
    public int lvldifficultyCompleted8;
    public int lvldifficultyCompleted9;
    public int lvldifficultyCompleted10;
    public int lvldifficultyCompleted11;
    public int lvldifficultyCompleted12;
    public int lvldifficultyCompleted13;
    public int lvldifficultyCompleted14;
    public int lvldifficultyCompleted15;
    public int lvldifficultyCompleted16;
    public int lvldifficultyCompleted17;
    public int lvldifficultyCompleted18;

    //Scores
    public int lvlMaxScore1;
    public int lvlMaxScore2;
    public int lvlMaxScore3;
    public int lvlMaxScore4;
    public int lvlMaxScore5;
    public int lvlMaxScore6;
    public int lvlMaxScore7;
    public int lvlMaxScore8;
    public int lvlMaxScore9;
    public int lvlMaxScore10;
    public int lvlMaxScore11;
    public int lvlMaxScore12;
    public int lvlMaxScore13;
    public int lvlMaxScore14;
    public int lvlMaxScore15;
    public int lvlMaxScore16;
    public int lvlMaxScore17;
    public int lvlMaxScore18;


    public int currentDifficulty;
    public bool ReadAnnouncement;
    public int Stars;
    public int UnlockedLStage;
    public bool MusicMuted;
    public bool SFXMuted;

    public PlayerData(PlayerStats player)
    {
        ProgressBar = PlayerStats.ProgressBar;
        Revives = PlayerStats.Revives;
        achievements = PlayerStats.achievements;

        //Announcements
        Ann2 = PlayerStats.Ann2;
        Ann3 = PlayerStats.Ann3;
        Ann4 = PlayerStats.Ann4;
        Ann5 = PlayerStats.Ann5;
        Ann7 = PlayerStats.Ann7;
        Ann13 = PlayerStats.Ann13;

        //levels
        levelWon = PlayerStats.levelWon;
        lvldifficultyCompleted1 = PlayerStats.lvldifficultyCompleted1;
        lvldifficultyCompleted2 = PlayerStats.lvldifficultyCompleted2;
        lvldifficultyCompleted3 = PlayerStats.lvldifficultyCompleted3;
        lvldifficultyCompleted4 = PlayerStats.lvldifficultyCompleted4;
        lvldifficultyCompleted5 = PlayerStats.lvldifficultyCompleted5;
        lvldifficultyCompleted6 = PlayerStats.lvldifficultyCompleted6;
        lvldifficultyCompleted7 = PlayerStats.lvldifficultyCompleted7;
        lvldifficultyCompleted8 = PlayerStats.lvldifficultyCompleted8;
        lvldifficultyCompleted9 = PlayerStats.lvldifficultyCompleted9;
        lvldifficultyCompleted10 = PlayerStats.lvldifficultyCompleted10;
        lvldifficultyCompleted11 = PlayerStats.lvldifficultyCompleted11;
        lvldifficultyCompleted12 = PlayerStats.lvldifficultyCompleted12;
        lvldifficultyCompleted13 = PlayerStats.lvldifficultyCompleted13;
        lvldifficultyCompleted14 = PlayerStats.lvldifficultyCompleted14;
        lvldifficultyCompleted15 = PlayerStats.lvldifficultyCompleted15;
        lvldifficultyCompleted16 = PlayerStats.lvldifficultyCompleted16;
        lvldifficultyCompleted17 = PlayerStats.lvldifficultyCompleted17;
        lvldifficultyCompleted18 = PlayerStats.lvldifficultyCompleted18;

        //scores
        lvlMaxScore1 = PlayerStats.lvlMaxScore1;
        lvlMaxScore2 = PlayerStats.lvlMaxScore2;
        lvlMaxScore3 = PlayerStats.lvlMaxScore3;
        lvlMaxScore4 = PlayerStats.lvlMaxScore4;
        lvlMaxScore5 = PlayerStats.lvlMaxScore5;
        lvlMaxScore6 = PlayerStats.lvlMaxScore6;
        lvlMaxScore7 = PlayerStats.lvlMaxScore7;
        lvlMaxScore8 = PlayerStats.lvlMaxScore8;
        lvlMaxScore9 = PlayerStats.lvlMaxScore9;
        lvlMaxScore10 = PlayerStats.lvlMaxScore10;
        lvlMaxScore11 = PlayerStats.lvlMaxScore11;
        lvlMaxScore12 = PlayerStats.lvlMaxScore12;
        lvlMaxScore13 = PlayerStats.lvlMaxScore13;
        lvlMaxScore14 = PlayerStats.lvlMaxScore14;
        lvlMaxScore15 = PlayerStats.lvlMaxScore15;
        lvlMaxScore16 = PlayerStats.lvlMaxScore16;
        lvlMaxScore17 = PlayerStats.lvlMaxScore17;
        lvlMaxScore18 = PlayerStats.lvlMaxScore18;

       
        currentDifficulty = PlayerStats.currentDifficulty;
        ReadAnnouncement = PlayerStats.ReadAnnouncement;
        Stars = PlayerStats.Stars;
        UnlockedLStage = PlayerStats.UnlockedLStage;
        MusicMuted = PlayerStats.MusicMuted;
        SFXMuted = PlayerStats.SFXMuted;

    }




}
