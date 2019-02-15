using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 5f;
    public float distanceToRaise = 40f;

    private Rigidbody rigidBody;
    private float startingYPos;

    void Start()
    {
        startingYPos = transform.position.y;
        rigidBody = GetComponent<Rigidbody>();
    }

    public bool IsStanding()
    {
        if (transform.position.y - standingThreshold < startingYPos + distanceToRaise &&
           transform.position.y + standingThreshold > startingYPos + distanceToRaise)
        {
            return true;
        }
        else if ((transform.position.y - standingThreshold) > startingYPos)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void RaisePins()
    {
        if (IsStanding())
        {
            rigidBody.useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0, 0);
        }
    }

    public void LowerPins()
    {
        if (IsStanding())
        {
            transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
            rigidBody.useGravity = true;
        }
    }
}
