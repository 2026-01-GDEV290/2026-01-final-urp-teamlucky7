using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Dictionary<string, float> npcPool = new Dictionary<string, float>();

    private string[] npcList = { "Strangula", "Bullseye", "Madam Fortune", "Jack-Of-All-Trades", "Business Man", "Detective", "Mafia Man" };

    [SerializeField]
    private string playerCharacter = "";
    
    private float playerMoneyValue = 0;

    [SerializeField]
    private Text npcText1;
    [SerializeField]
    private Text npcText2;
    [SerializeField]
    private Text npcText3;
    [SerializeField]
    private Text npcText4;
    [SerializeField]
    private Text npcText5;
    [SerializeField]
    private Text npcText6;
    [SerializeField]
    private Text npcText7;

    [SerializeField] 
    private Text npcValue1;
    [SerializeField]
    private Text npcValue2;
    [SerializeField]
    private Text npcValue3;
    [SerializeField]
    private Text npcValue4;
    [SerializeField]
    private Text npcValue5;
    [SerializeField]
    private Text npcValue6;
    [SerializeField]
    private Text npcValue7;


    [SerializeField]
    private int day = 1;

    public bool updateLeaderboard = false;

    private bool showingLeaderboard = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateLeaderboard = false;
        playerCharacter = "";
        InitializeLeaderboard();

        Debug.Log(npcPool.Count);
        day = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(showingLeaderboard == false && updateLeaderboard == true)
        {
            ShowLeaderboard();
        }
    }

    public void InitializeLeaderboard()
    {
        npcPool.Add("Strangula", 0);
        npcPool.Add("Bullseye", 0);
        npcPool.Add("Madam Fortune", 0);
        npcPool.Add("Jack-Of-All-Trades", 0);
        npcPool.Add("Business Man", 0);
        npcPool.Add("Detective", 0);
        npcPool.Add("Mafia Man", 0);

        if (day == 1)
        {
            Debug.Log("Day 1");
            for (int i = 0; i < npcList.Length; i++)
            {
                Debug.Log("initialized leaderboard for loop");
                if (npcPool.ContainsKey(nameof(playerCharacter)))
                {
                    Debug.Log("____________________________________________________________________________");
                    Debug.Log("Attempting to remove player...");
                    Debug.Log("____________________________________________________________________________");
                    npcPool.Remove(nameof(playerCharacter));
                    if (npcPool.ContainsKey(nameof(playerCharacter)))
                    {
                        Debug.Log("____________________________________________________________________________");
                        Debug.Log("Player Character not removed");
                        Debug.Log("____________________________________________________________________________");
                    } else
                    {
                        Debug.Log("____________________________________________________________________________");
                        Debug.Log("Player Character successfully removed");
                        Debug.Log("____________________________________________________________________________");
                    }
                }
                int npcMoneyValue = UnityEngine.Random.Range(50, 6000);
                npcPool[npcList[i]] = npcMoneyValue;
            }
        }
        else
        {
            for (int i = 0; i < npcPool.Count - 1; i++)
            {
                int npcMoneyValue = UnityEngine.Random.Range(150, 5000);
                npcPool[npcList[i]] += npcMoneyValue;
            }
        }
    }

    public void ShowLeaderboard()
    {
        showingLeaderboard = true;
        string[] npcOrderedList = {"", "", "", "", "", "", ""};
        float[] npcOrderedValue = { 0, 0, 0, 0, 0, 0, 0 };

        Debug.Log("NPC Ordered Value Length: " + npcOrderedValue.Length);
        Debug.Log("NPC Ordered List Length: " + npcOrderedList.Length);

        //for (int i = 0; i <= npcList.Length - 1; i++) //for loop that goes from the first element of the NPC List array to the last; used to search for the specific key in the NPC Pool hashmap, until it reaches the last name
        //{
        //    Debug.Log("First Loop");
        //    var j = npcOrderedValue.Length;

        //    //for(int j = npcOrderedValue.Length - 1; j >= 0; j--) //for loop that goes from the first element of the Ordered Value list to the last; used to check each value currently inside of the list 
        //    while (j-1 > 0) {
        //        j--;
        //        Debug.Log("Second Loop");
        //        Debug.Log("J = " + j);
        //        if(j == 6 && i  == 0)
        //        {
        //            npcOrderedValue[j] = npcPool[npcList[i]];
        //            npcOrderedList[i] = npcList[i];
        //        } else if (npcPool.ContainsKey(npcList[i]) && npcPool[npcList[i]] < npcOrderedValue[j]) //Checks if the name in slot I of the NPC list is inside of the hashmap "NPC Pool"
        //        {
        //            npcOrderedValue[j - 1] = npcOrderedValue[j];
        //            npcOrderedValue[j] = npcPool[npcList[i]];
        //            npcOrderedList[i - 1] = npcList[i];
        //            npcOrderedList[i] = npcList[i];
        //            Debug.Log("" + npcList[i] + ": " + npcOrderedValue[j] + "");
        //            Debug.Log("Real Value: " + npcList[i] + ": " + npcPool[npcList[i]] + "");
        //        }
        //        else if (j == 0 && npcPool[npcList[i]] > npcOrderedValue[j])
        //        {
        //            npcOrderedValue[j] = npcPool[npcList[i]];
        //            npcOrderedList[i] = npcList[i];
        //        }
        //        else if (npcPool.ContainsKey(playerCharacter) && playerMoneyValue < npcOrderedValue[j])
        //        {
        //            npcOrderedValue[j] = npcPool[npcList[i]];
        //            npcOrderedList[i] = playerCharacter;
        //            Debug.Log("" + npcOrderedList[j] + ": " + npcOrderedValue[j]);
        //        }
        //        else
        //        {
        //            Debug.Log("No conditions met");
        //        }
        //    }

        for(int i = 0;i < npcOrderedList.Length; i++)
        {
            npcOrderedList[i] = npcList[i];
        }

        for (int i = 0; i < npcOrderedValue.Length; i++)
        {
            if (npcPool.ContainsKey(npcList[i]))
            {
                npcOrderedValue[i] = npcPool[npcList[i]];
            }
            else if (playerCharacter.Equals(npcList[i], StringComparison.OrdinalIgnoreCase))
            {
                npcOrderedValue[i] = playerMoneyValue;
            }   
        }

        Array.Sort(npcOrderedValue);
        Array.Reverse(npcOrderedValue);

        for (int i = 0; i < npcList.Length; i++)
        {
            Debug.Log("I = " + i);
            Debug.Log("Real Value: " + npcList[i] + ": " + npcPool[npcList[i]] + "");
            for (int j = 0; j < npcOrderedValue.Length; j++)
            {
                Debug.Log("J = " + j);
                if (npcPool[npcList[i]] == npcOrderedValue[j])
                {
                    Debug.Log("" + npcList[i] + ": " + npcOrderedValue[j] + "");
                    npcOrderedList[j] = npcList[i];
                }
            }
        }

        //}
        //for (int i = 0; i < npcPool.Count - 1; i++)
        //{
        //    if(i == 0)
        //    {
        //        npcOrderedList[i] = npcList[i];
        //    } else
        //    if (!npcPool.ContainsKey(npcList[i]))
        //    {
        //        if (playerMoneyValue < npcPool[npcList[i - 1]])
        //        {
        //            npcOrderedList[i] = npcList[i - 1];
        //            npcOrderedValue[i - 1] = playerMoneyValue;
        //        }
        //        else
        //        {
        //            npcOrderedList[i] = npcList[i];
        //            npcOrderedValue[i] = playerMoneyValue;
        //        }
        //    }
        //    else if (npcPool.ContainsKey(npcList[i]) && npcPool[npcList[i]] < npcPool[npcList[i - 1]])
        //    {
        //        npcOrderedList[i - 1] = npcList[i];
        //        npcOrderedValue[i - 1] = npcPool[npcList[i]];
        //    }
        //    else
        //    {
        //        npcOrderedList[i] = npcList[i];
        //        npcOrderedValue[i] = npcPool[npcList[i]];
        //    }
        //}

        npcText1.text = npcOrderedList[0];
        npcText2.text = npcOrderedList[1];
        npcText3.text = npcOrderedList[2];
        npcText4.text = npcOrderedList[3];
        npcText5.text = npcOrderedList[4];
        npcText6.text = npcOrderedList[5];
        npcText7.text = npcOrderedList[6];

        npcValue1.text = "" + npcOrderedValue[0];
        npcValue2.text = "" + npcOrderedValue[1];
        npcValue3.text = "" + npcOrderedValue[2];
        npcValue4.text = "" + npcOrderedValue[3];
        npcValue5.text = "" + npcOrderedValue[4];
        npcValue6.text = "" + npcOrderedValue[5];
        npcValue7.text = "" + npcOrderedValue[6];

        npcText1.enabled = true;
        npcText2.enabled = true;
        npcText3.enabled = true;
        npcText4.enabled = true;
        npcText5.enabled = true;
        npcText6.enabled = true;
        npcText7.enabled = true;

        npcValue1.enabled = true;
        npcValue2.enabled = true;
        npcValue3.enabled = true;
        npcValue4.enabled = true;
        npcValue5.enabled = true;
        npcValue6.enabled = true;
        npcValue7.enabled = true;

        showingLeaderboard = false;
        updateLeaderboard = false;
    }
}

