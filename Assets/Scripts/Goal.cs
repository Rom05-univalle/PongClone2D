using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool leftGoal = true; // si true, suma punto al jugador derecho
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if (leftGoal) gameManager.ScoreRight();
            else gameManager.ScoreLeft();
        }
    }
}

