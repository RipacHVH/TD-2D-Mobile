using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stars : MonoBehaviour
{
    public int level = 1;
    public Image[] StarsGameObj;
    private void Start()
    {
            if (level == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted1 >= i+1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 2)
            {
            for (int i = 0; i < 3; i++)
            {
                if (PlayerStats.lvldifficultyCompleted2 >= i + 1)
                {
                    StarsGameObj[i].enabled = true;
                }
            }
            }
            if (level == 3)
            {
            for (int i = 0; i < 3; i++)
            {
                if (PlayerStats.lvldifficultyCompleted3 >= i + 1)
                {
                    StarsGameObj[i].enabled = true;
                }
            }
            }
            if (level == 4)
            {
            for (int i = 0; i < 3; i++)
            {
                if (PlayerStats.lvldifficultyCompleted4 >= i + 1)
                {
                    StarsGameObj[i].enabled = true;
                }
            }
            }
            if (level == 5)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted5 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 6)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted6 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 7)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted7 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 8)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted8 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 9)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted9 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 10)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted10 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 11)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted11 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 12)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted12 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 13)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted13 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 14)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted14 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 15)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted15 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 16)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted16 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 17)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted17 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }
            if (level == 18)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (PlayerStats.lvldifficultyCompleted18 >= i + 1)
                    {
                        StarsGameObj[i].enabled = true;
                    }
                }
            }

        }
    }