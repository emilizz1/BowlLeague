using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private List<int> rolls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;
    
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}

    public void Bowl (int pinFall)
    {
        ball.Reset();
        try {
            rolls.Add(pinFall);
            
            ActionMaster.Action nextAction = ActionMaster.NextAction(rolls);
            pinSetter.PerformAction(nextAction);
        }
        catch
        {
            Debug.LogWarning("Smth went wrong with Bowl");
        }
        try {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        } catch {
            Debug.LogWarning("FillRollCard failed");
        }
            
    }
}
