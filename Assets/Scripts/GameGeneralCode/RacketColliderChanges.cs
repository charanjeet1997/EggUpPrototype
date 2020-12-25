using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RacketColliderChanges : MonoBehaviour
{
    public BoxCollider racketCollider;
    public Animator racketAnimator;
    public RacketManager racketManager;
    public GameEvents gameEvents;
    public string eggTag;
    public int currentPoints;
    public GameObject PointObject;
    public ParticleSystem pointGetParticle;
    bool givePoint;

    private void OnCollisionEnter(Collision other)  {
        if(other.collider.tag == eggTag)
        {
            if(racketManager.canTreeShow)
            {
                if(other.collider.transform.position.y > transform.position.y)
                {
                    if(givePoint == false)
                    {
                        gameEvents.RaiseOnCurrentPointSetup(currentPoints);
                        givePoint = true;
                    }
                    PointObject.transform.gameObject.SetActive(false);
                }
            }
            racketAnimator.SetBool("CanFlex",true);
            StartCoroutine(StopRacketFlex());
        }
    }

    IEnumerator StopRacketFlex()
    {
        yield return new WaitForSeconds(0.0001f);
        racketAnimator.SetBool("CanFlex",false);
    }
}
