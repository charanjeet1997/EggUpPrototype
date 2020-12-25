using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public CanvasData initScreen;
    public List<CanvasData> screens;
    public static CanvasManager Instance;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        initScreen.screen.enabled = true;
    }

    public void ChangeScreen(CanvasEnum screenName)
    {
        for (int screenIndex = 0; screenIndex < screens.Count; screenIndex++)
        {
            if(screenName == screens[screenIndex].ScreenName)
            {
                screens[screenIndex].screen.enabled = true;
            }
            else
                screens[screenIndex].screen.enabled = false;
        }   
    }
}
