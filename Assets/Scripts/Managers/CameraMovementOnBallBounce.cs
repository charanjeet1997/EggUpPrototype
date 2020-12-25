using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementOnBallBounce : MonoBehaviour
{
    public Camera gameCamera;
    public GameEvents gameEvents;
    public float cameraMoveSpeed; 
    bool moveTowardsPosition;
    Vector3 currentRacketPosition,cameraposition;
    [SerializeField]private float distance;
    private void Start() {
        cameraposition = gameCamera.transform.position;
    }
    private void OnEnable() {
        gameEvents.OnRacketPositionGet.AddListener(GetCurrentRacketPosition);
    }

    private void OnDisable() {
        gameEvents.OnRacketPositionGet.RemoveListener(GetCurrentRacketPosition);
    }

    public void GetCurrentRacketPosition(Vector3 position)
    {
        currentRacketPosition = cameraposition + new Vector3(0,position.y+1,0);
        moveTowardsPosition = true;
    }

    private void Update() {
        if(moveTowardsPosition == true)
        {
            distance = Vector3.Distance(gameCamera.transform.position,currentRacketPosition);
            if(distance > 0.5)
            {
                gameCamera.transform.position = Vector3.MoveTowards(gameCamera.transform.position,currentRacketPosition,cameraMoveSpeed * Time.deltaTime);
            }
        }
    }
}
