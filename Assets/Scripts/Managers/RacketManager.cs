using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketManager : MonoBehaviour
{
    public int index;
    public BoxCollider boxCollider;
    public BoxCollider racketHolderCollider;
    public GameObject christMasTree;
    public bool canTreeShow;
    public GameEvents gameEvents;
    public GameObject ball;

    private void OnEnable()
    {
        gameEvents.OnGameStart.AddListener(OnStartGame);
    }
    private void OnDisable()
    {
        gameEvents.OnGameStart.RemoveListener(OnStartGame);
    }
    private void Start()
    {
        christMasTree.SetActive(canTreeShow);
    }
    public void OnStartGame()
    {
        if (index == 0)
        {
            boxCollider.isTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            ball = other.gameObject;
            if (ball.transform.position.y > transform.position.y)
                boxCollider.isTrigger = false;
            else
            {
                boxCollider.isTrigger = true;
            }
        }
        //        Debug.Log(other.name);
    }
    private void OnTriggerStay(Collider other) {
        if (other.tag == "Ball")
        {
            boxCollider.isTrigger = true;
        }
    }
}
