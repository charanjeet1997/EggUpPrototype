using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameEvent" , menuName = "EggUpEvents/GameEvent")]
public class GameEvents : ScriptableObject
{
    public UnityEvent<Vector3> OnRacketPositionGet;

    public void RaiseRacketPositionEvent(Vector3 position)
    {
        if(OnRacketPositionGet != null)
            OnRacketPositionGet.Invoke(position);
    }

    public UnityEvent<int> OnCurrentPointsSetup;

    public void RaiseOnCurrentPointSetup(int currentPoint)
    {
        if(OnCurrentPointsSetup != null)
        {
            OnCurrentPointsSetup.Invoke(currentPoint);
        }
    }

    public UnityEvent OnGameOver;

    public void RaiseOnGameOver()
    {
        if(OnGameOver != null)
        {
            OnGameOver.Invoke();
        }
    }

    public UnityEvent OnGameStart;

    public void RaiseOnGameStart()
    {
        if(OnGameStart != null)
        {
            OnGameStart.Invoke();
        }
    }
}
