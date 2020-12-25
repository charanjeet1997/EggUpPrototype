using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Container/EggPointContainer",fileName = "EggPointContainer")]
public class EggpointContainer : ScriptableObject
{
    public int collectedPoints;
    [SerializeField]private int currentCollectedPoints;
    [SerializeField]private int HighScore;

    public void AddPoints(int collectedPoints)
    {
        currentCollectedPoints += collectedPoints;
        CheckHighScore(currentCollectedPoints); 
    }

    public void CheckHighScore(int points)
    {
        if(points > HighScore)
        {
            HighScore = points;
        }
    }

    public int GetHighScore()
    {
        return HighScore;
    }

    public int GetCurrentPoints()
    {
        return currentCollectedPoints;
    }

    public int GetAllPoints()
    {
        return collectedPoints;
    }

    public void SetCurrentCollctedPointsToZero()
    {
        currentCollectedPoints = 0;
    }
}
