using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ball")
        {
            CanvasManager.Instance.ChangeScreen(CanvasEnum.WinScreen);
            Destroy(other.gameObject);
        }
    }
}
