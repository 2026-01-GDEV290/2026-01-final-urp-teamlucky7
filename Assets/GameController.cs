using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private Text prizeText;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text scoreNumText;

    [SerializeField]
    private Row[] rows;

    [SerializeField]
    private Transform handle;

    private int prizeValue;
    private int currentScore;
    private int newScore;

    private bool resultsChecked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prizeText.enabled = false;
        scoreText.enabled = true;
        scoreNumText.enabled = true;
        currentScore = 0;
        newScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            currentScore = newScore;
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && !resultsChecked)
        {
            CheckResults();
            prizeText.enabled = true;
            prizeText.text = "Money Get! - " + prizeValue;
        }
    }

    private void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            StartCoroutine("PullHandle");
        }
    }

    private IEnumerator PullHandle()
    {
        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, i);
            yield return null;
        }

        HandlePulled();

        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, -i);
            yield return null;
        }
    }

    private void CheckResults()
    {
        if (rows[0].stoppedSlot == "Star" && rows[1].stoppedSlot == "Star" && rows[2].stoppedSlot == "Star")
        {
            prizeValue = 100;
        }

        else if (rows[0].stoppedSlot == "Moon" && rows[1].stoppedSlot == "Moon" && rows[2].stoppedSlot == "Moon")
        {
            prizeValue = 200;
        }

        else if (rows[0].stoppedSlot == "Alien" && rows[1].stoppedSlot == "Alien" && rows[2].stoppedSlot == "Alien")
        {
            prizeValue = 300;
        }

        else if (rows[0].stoppedSlot == "Seven" && rows[1].stoppedSlot == "Seven" && rows[2].stoppedSlot == "Seven")
        {
            prizeValue = 777;
        }

        else if (rows[0].stoppedSlot == "Bar" && rows[1].stoppedSlot == "Bar" && rows[2].stoppedSlot == "Bar")
        {
            prizeValue = 400;
        }

        else if (rows[0].stoppedSlot == "Xenomorph" && rows[1].stoppedSlot == "Xenomorph" && rows[2].stoppedSlot == "Xenomorph")
        {
            prizeValue = 600;
        }

        else if (rows[0].stoppedSlot == "Sun" && rows[1].stoppedSlot == "Sun" && rows[2].stoppedSlot == "Sun")
        {
            prizeValue = 800;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot && rows[1].stoppedSlot == "Star")
            || (rows[1].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Star")
            || (rows[0].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Star"))
        {
            prizeValue = 50;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot && rows[1].stoppedSlot == "Moon")
            || (rows[1].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Moon")
            || (rows[0].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Moon"))
        {
            prizeValue = 100;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot && rows[1].stoppedSlot == "Alien")
            || (rows[1].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Alien")
            || (rows[0].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Alien"))
        {
            prizeValue = 150;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot && rows[1].stoppedSlot == "Bar")
            || (rows[1].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Bar")
            || (rows[0].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Bar"))
        {
            prizeValue = 200;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot && rows[1].stoppedSlot == "Seven")
            || (rows[1].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Seven")
            || (rows[0].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Seven"))
        {
            prizeValue = 389;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot && rows[1].stoppedSlot == "Xenomorph")
            || (rows[1].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Xenomorph")
            || (rows[0].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Xenomorph"))
        {
            prizeValue = 300;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot && rows[1].stoppedSlot == "Sun")
            || (rows[1].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Sun")
            || (rows[0].stoppedSlot == rows[2].stoppedSlot && rows[2].stoppedSlot == "Sun"))
        {
            prizeValue = 800;
        }

        if (currentScore != prizeValue + currentScore)
        {
            newScore = prizeValue + currentScore;
        }

        scoreNumText.text = "" + newScore;
    }
}
