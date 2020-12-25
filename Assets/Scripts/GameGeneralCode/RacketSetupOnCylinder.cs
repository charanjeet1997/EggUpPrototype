using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketSetupOnCylinder : MonoBehaviour
{
    public RacketManager racketRingPrefab;
    public GameObject RacketHolderCylinder;
    public GameObject RacketRingParent;
    public GameEvents gameEvents;
    public float numberOfRackets = 0;
    public static RacketSetupOnCylinder Instance;
    public float maxIterations, minIterations;
    [SerializeField] List<GameObject> rackets = new List<GameObject>();
    GameObject racket;
    public int rotationIterations = 4;
    public int currentRotationIteration;
    public int racketYRotation;
    int index = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        racketYRotation = 360 / rotationIterations;
        currentRotationIteration = rotationIterations;
        GetScaleHeightOfRacket();
    }
    public void GetScaleHeightOfRacket()
    {
        if (RacketHolderCylinder != null)
        {
            numberOfRackets = (RacketHolderCylinder.transform.localScale.y - 1) * 2;
            Debug.Log(RacketHolderCylinder.transform.localScale.y);
            racketRingPrefab.index = 0;
            racket = Instantiate(racketRingPrefab.gameObject, RacketRingParent.transform);
            racket.transform.position = new Vector3(0, 0, 0);
            racket.GetComponent<RacketManager>().boxCollider.isTrigger = false;
            float pointRandomIndex = Random.Range(3, 5);
            rackets.Add(racket);
            for (float racketIndex = 1; racketIndex < numberOfRackets; racketIndex += Random.Range(minIterations, maxIterations))
            {
                index++;
                if (racketIndex >= pointRandomIndex)
                {
                    racketRingPrefab.canTreeShow = true;
                    pointRandomIndex = Random.Range(racketIndex + 3, racketIndex + 5);
                }
                else
                    racketRingPrefab.canTreeShow = false;
                racketRingPrefab.index = index;
                racket = Instantiate(racketRingPrefab.gameObject, RacketRingParent.transform);
                racket.transform.position = new Vector3(0, racketIndex, 0);
                rackets.Add(racket);
            }
            SetRacketRotation();
        }
    }

    public void SetRacketRotation()
    {
        for (int racketIndex = 1; racketIndex < rackets.Count; racketIndex++)
        {
            if (racketIndex >= currentRotationIteration)
            {
                racketYRotation += (360 / currentRotationIteration);
                currentRotationIteration = rotationIterations + index;
            }
            rackets[racketIndex].transform.localEulerAngles = new Vector3(0, GetRandomRotation(), 0);
        }
    }

    public Vector3 GetCurrentRacketPosition(GameObject racketObject)
    {
        Debug.Log(rackets[0].transform.GetChild(0).name);
        Vector3 racketPosition = rackets.Find(rkt => rkt == racketObject).transform.position;
        return racketPosition;
    }

    private void OnGameOver()
    {
        for (int racketIndex = 0; racketIndex < rackets.Count; racketIndex++)
        {
            Destroy(rackets[racketIndex]);
        }
        rackets.Clear();
        currentRotationIteration = rotationIterations;
        GetScaleHeightOfRacket();
    }
    private void OnEnable()
    {
        gameEvents.OnGameOver.AddListener(OnGameOver);
    }

    private void OnDisable()
    {
        gameEvents.OnGameOver.RemoveListener(OnGameOver);
    }

    public int GetRandomRotation()
    {
        return Random.Range(0, racketYRotation);
    }
}
