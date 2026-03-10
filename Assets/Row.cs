using UnityEngine;
using System.Collections;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rowStopped = true;
        GameController.HandlePulled += StartRotating;
    }

    private void StartRotating()
    {
        stoppedSlot = "";
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.025f;

        for (int i = 0; i < 30; i++)
        {
            if(transform.position.y <= -18.612f)
            {
                transform.position = new Vector2(transform.position.x, -15.509F);
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            yield return new WaitForSeconds(timeInterval);
        }

        randomValue = Random.Range(60, 100);

        switch (randomValue % 3)
        {
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;
        }

        for (int i=0; i<randomValue; i++)
        {
            if(transform.position.y <= -18.612f)
            {
                transform.position = new Vector2(transform.position.x, -15.509F);
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            if(i > Mathf.RoundToInt(randomValue * 0.25f))
            {
                timeInterval = 0.05f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
            {
                timeInterval = 0.1f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
            {
                timeInterval = 0.15f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
            {
                timeInterval = 0.2f;
            }

            yield return new WaitForSeconds(timeInterval);
        }

        if(transform.position.y == -18.612f)
        {
            stoppedSlot = "Diamond";
        }
        else if (transform.position.y == -18.155f)
        {
            stoppedSlot = "Crown";
        }
        else if (transform.position.y == -17.719f)
        {
            stoppedSlot = "Melon";
        }
        else if (transform.position.y == -17.283f)
        {
            stoppedSlot = "Bar";
        }
        else if (transform.position.y == -16.838f)
        {
            stoppedSlot = "Seven";
        }
        else if (transform.position.y == -16.387f)
        {
            stoppedSlot = "Cherry";
        }
        else if (transform.position.y == -17.719f)
        {
            stoppedSlot = "Lemon";
        }
        else if (transform.position.y == -15.926f)
        {
            stoppedSlot = "Diamond";
        }

        rowStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        GameController.HandlePulled -= StartRotating;
    }
}
