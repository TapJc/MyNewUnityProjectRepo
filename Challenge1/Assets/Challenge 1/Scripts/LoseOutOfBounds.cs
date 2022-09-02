﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOutOfBounds : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -51 || transform.position.y > 80)
        {
            ScoreManager.gameOver = true;
        }
    }
}
