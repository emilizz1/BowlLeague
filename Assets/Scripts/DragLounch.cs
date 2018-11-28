﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLounch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

	void Start () {
        ball = GetComponent<Ball>();
	}

    public void MoveStart(float amount)
    {
        if (!ball.inPlay)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x, -50, 50);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    public void DragStart()
    {
        if (!ball.inPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd()
    {
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;

            float lounchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float lounchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            Vector3 lounchVelocity = new Vector3(lounchSpeedX, 0, lounchSpeedZ);
            ball.Lounch(lounchVelocity);
        }
    }
}