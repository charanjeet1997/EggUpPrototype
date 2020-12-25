using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EggPointManager : MonoBehaviour
{
    public EggpointContainer eggpointContainer;
    public GameEvents gameEvents;
    public Text currentPoints,currentPointsRestart;
    public Text HighScore;
    public Canvas GameUi,MainUI;
    private void Start() {
        currentPointsRestart.text = eggpointContainer.GetAllPoints().ToString();
        HighScore.text = eggpointContainer.GetHighScore().ToString();
        GameUi.enabled = false;
        MainUI.enabled = true;
    }
    private void OnEnable() {
        gameEvents.OnCurrentPointsSetup.AddListener(GetCurrentPoints);
        gameEvents.OnGameOver.AddListener(OnGameOver);
    }

    private void OnDisable() {
        gameEvents.OnCurrentPointsSetup.RemoveListener(GetCurrentPoints);
        gameEvents.OnGameOver.RemoveListener(OnGameOver);
    }
    public void GetCurrentPoints(int point)
    {
        eggpointContainer.AddPoints(point);
        eggpointContainer.collectedPoints+= point;
        currentPoints.text = eggpointContainer.GetCurrentPoints().ToString();
    }

    public void OnGameOver()
    {
        currentPointsRestart.text = eggpointContainer.GetAllPoints().ToString();
        HighScore.text = eggpointContainer.GetHighScore().ToString();
        CanvasManager.Instance.ChangeScreen(CanvasEnum.mainScreen);
    }
    
    public void OnSTartGame()
    {
        CanvasManager.Instance.ChangeScreen(CanvasEnum.gameUI);
        currentPoints.text = "0";
        eggpointContainer.SetCurrentCollctedPointsToZero();
        gameEvents.RaiseOnGameStart();
    }

    

}
