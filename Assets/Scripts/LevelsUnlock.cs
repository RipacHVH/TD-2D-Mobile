using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelsUnlock : MonoBehaviour
{
    public Button[] levelButtons;
    public Image[] levelImages;
    public Image[] lockImages;
    public Image[] EasyStars;
    public Image[] MediumStars;
    public Image[] HardStars;
    public int levelAt = 1;

    public GameObject Announcement;
    // Update is called once per frame
    void Start()
    {
        //UnlockedLevels = PlayerStats.levelWon;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > PlayerStats.levelWon)
            {
                levelButtons[i].interactable = false;
                levelImages[i].color = new Color(150, 150, 150, 0.6f);
                lockImages[i].enabled = true;
            }
        }

    }
}
