using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncePhysics : MonoBehaviour
{
    public float bounciness;
    public string bounceColliderTag;
    public GameEvents gameEvents;
    public AudioSource ballBounceAudioSource;
    public Rigidbody rb_ball;
    GameObject racket;
    public float distance;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == bounceColliderTag)
        {
            if (transform.position.y > other.transform.position.y)
            {
                ballBounceAudioSource.Play();
                Debug.Log(other.transform.parent.parent.parent.name);
                rb_ball.velocity = (transform.up * bounciness * Time.deltaTime);
                racket = other.transform.parent.parent.parent.parent.parent.parent.gameObject;
                Vector3 racketPositon = RacketSetupOnCylinder.Instance.GetCurrentRacketPosition(other.transform.parent.parent.parent.parent.parent.parent.gameObject);
                gameEvents.RaiseRacketPositionEvent(racketPositon);
            }
        }
    }

    private void Update()
    {
        if (racket != null)
        {
            if (transform.position.y > racket.transform.position.y)
            {

            }
            else
            {
                distance = racket.transform.position.y - transform.position.y;
                if (distance > 4)
                {
                    gameEvents.RaiseOnGameOver();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
