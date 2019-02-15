using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PinSetter : MonoBehaviour
{
    public GameObject pinSet;
    [SerializeField] GameObject levelFinished;

    private PinCounter pinCounter;
    private Animator animator;
    private DragLounch dragLounch;

    void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        dragLounch = FindObjectOfType<DragLounch>();
    }

    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin != null)
            {
                pin.RaisePins();
            }
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin != null)
            {
                pin.LowerPins();
            }
        }
        LetItLounch();
    }

    public void RenewPins()
    {
        Instantiate(pinSet, new Vector3(0, 0, 1829), Quaternion.identity);
        LetItLounch();
    }

    void OnTriggerExit(Collider collider)
    {
        GameObject thingLeft = collider.gameObject;
        if (thingLeft.GetComponent<Pin>())
        {
            Destroy(thingLeft);
        }
    }

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            dragLounch.CanItLounch = false;
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.Reset)
        {
            dragLounch.CanItLounch = false;
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            levelFinished.SetActive(true);
            Invoke("LoadMainMenu()", 3f);
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            dragLounch.CanItLounch = false;
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LetItLounch()
    {
        dragLounch.CanItLounch = true;
    }
}
