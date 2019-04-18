using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int score = 0;
    public int maxCombo = 0;
    public int combo = 0;

    public void addScore(int score)
    {
        this.score += score;
        this.combo++;

        if (this.combo > this.maxCombo)
            this.maxCombo = this.combo;
    }

    public void missAction()
    {
        this.combo = 0;
    }
}
