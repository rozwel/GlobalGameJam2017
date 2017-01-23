using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThruster : MonoBehaviour
{

    public float ThrustPower = 1;
    public float MaxSpeed = 10;
    public float TurnRate = 10;
    public GameObject camera;
    //public Vector3 newDirection;
    private Rigidbody _rigidBody;
    private bool surfing;
    private Vector3 surfVelocity;
    private Quaternion surfRotation;
    private Quaternion initialRotation;
    private float surfDuration;


    // Use this for initialization
    void Start()
    {
        surfing = false;
        //initialRotation = transform.localRotation;
        _rigidBody = GetComponent<Rigidbody>();
        lastPlayed = Time.time + 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (surfing)
        {
            float deltaTime = Mathf.Min(surfDuration, Time.deltaTime);
            _rigidBody.velocity = Vector3.Slerp(
                _rigidBody.velocity, surfVelocity, deltaTime / surfDuration
            );
            transform.localRotation = Quaternion.Slerp(
                transform.localRotation, surfRotation, deltaTime / surfDuration
            );
            surfDuration -= deltaTime;
            if (surfDuration <= 0.0f) { surfing = false; }

            //float thetaTarget = Vector3.Angle(_rigidBody.velocity, surfDirection.Value);
            //float thetaFrame = TurnRate * Time.deltaTime;
            //if (thetaFrame >= thetaTarget)
            //{
            //    surfDirection = null;
            //    thetaFrame = thetaTarget;
            //}
            //transform.Rotate(Vector3.up, thetaFrame);
        }
        else
        {
            _rigidBody.AddRelativeForce(-ThrustPower * Input.GetAxis("Vertical") * Time.deltaTime, 0, 0, ForceMode.Acceleration);
            //transform.Rotate(0, TurnRate * Input.GetAxis("Horizontal") * Time.deltaTime, 0, Space.Self);
            transform.Rotate(Vector3.up, TurnRate * Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        camera.transform.position = transform.position + new Vector3(0, 45, 0);
        if(Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            if(lastPlayed <= Time.time)
            {
                NotMoving();
            }
        }else
        {
            lastPlayed = Time.time+10;
        }
    }
    float lastPlayed;
    
    public void NotMoving()
    {
        float duration = CaptainSoundManager.instance.PlayRandomSound(CaptainSoundManager.instance.stayingStillToLong);
        lastPlayed = Time.time + 10 + duration;
    }

    public void StartSurf(Vector3 velocity)
    {
        surfing = true;
        surfVelocity = velocity;
        surfRotation = Quaternion.AngleAxis(-90, Vector3.right) * Quaternion.FromToRotation(-Vector3.right, velocity);
        surfDuration = 1.0f;
    }
}
