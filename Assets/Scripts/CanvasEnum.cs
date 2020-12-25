using UnityEngine;
public enum CanvasEnum
{
    mainScreen,
    gameUI,
    WinScreen
}

[System.Serializable]
public class CanvasData{
    public Canvas screen;
    public CanvasEnum ScreenName;
}
