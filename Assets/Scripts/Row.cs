using UnityEngine;
using System.Collections;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;

    public float[] rowLocations = { -18.640f, -17.991f, -17.314f, -16.686f, -16.002f, -15.364f }; //array of slot locations, starting from the top and going to the buttom
    //In order: Star [0], Moon [1], Alien [2], Seven [3], Xenomorph [4], Sun [5]

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

        rowStopped = true;
        
        if (rowStopped == true)
        {
            double[] rowStoppedArray = {0,0,0,0,0};
            bool foundEquals = false;

            for(int i = 0; transform.position.y == rowLocations[i] && i < rowLocations.Length; i++)
            {
                foundEquals = true;
            }
            for (int i = 0; foundEquals == false && (transform.position.y > rowLocations[i] || transform.position.y < rowLocations[i]) && i < rowLocations.Length - 1; i++)
            {
                if(transform.position.y > rowLocations[i])
                {
                    rowStoppedArray[i] = transform.position.y - rowLocations[i];
                } else if(transform.position.y < rowLocations[i])
                {
                    rowStoppedArray[i] = rowLocations[i] - transform.position.y;
                }
            }
            for(int i = 0; foundEquals == false && rowStoppedArray.Length > 0 && i < rowStoppedArray.Length; i++)
            {
                int k = 0;
                for(int j = 1; j < rowStoppedArray.Length - 1; j++)
                {
                    if (rowStoppedArray[j] < rowStoppedArray[j - 1])
                    {
                        k = j;
                    }
                }
                transform.position = new Vector2(transform.position.x, rowLocations[k]);
            }

        }

        if (transform.position.y == rowLocations[0])
        {
            stoppedSlot = "Star";
        }
        else if (transform.position.y == rowLocations[1])
        {
            stoppedSlot = "Moon";
        }
        else if (transform.position.y == rowLocations[2])
        {
            stoppedSlot = "Alien";
        }
        else if (transform.position.y == rowLocations[3])
        {
            stoppedSlot = "Bar";
        }
        else if (transform.position.y == rowLocations[4])
        {
            stoppedSlot = "Seven";
        }
        else if (transform.position.y == rowLocations[5])
        {
            stoppedSlot = "Cherry";
        }        
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
