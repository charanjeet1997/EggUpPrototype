using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggManager : MonoBehaviour
{
    public GameObject eggPrefab;
    public GameObject eggStartPosition;
    public Material eggMaterial;
    public Color eggColor;
    public Color[] eggColors;
    public GameEvents gameEvents;
    public GameObject cylinder;
    public Camera mainCamera;

    private void OnEnable() {
        gameEvents.OnGameStart.AddListener(EggSetupOnLevelStart);
    }

    private void OnDisable() {
        gameEvents.OnGameStart.RemoveListener(EggSetupOnLevelStart);
    }
    public void EggSetupOnLevelStart()
    {
        eggColor = eggColors[Random.Range(0,eggColors.Length)];
        eggMaterial.color = eggColor;
        cylinder.transform.localEulerAngles = new Vector3(0,180,0);
        mainCamera.transform.position = new Vector3(0,1,mainCamera.transform.position.z);
        GameObject egg = Instantiate(eggPrefab,eggStartPosition.transform.position,Quaternion.identity);
    }
}
