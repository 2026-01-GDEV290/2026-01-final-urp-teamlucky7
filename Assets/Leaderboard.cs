using System.Collections.Generic;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
            if (npcPool.ContainsKey(playerCharacter))
            {
                npcPool.Remove(playerCharacter);
            }

            for (int i = 0; i <= npcPool.Count; i++)
            {
                int npcMoneyValue = Random.Range(50, 6000);
                npcPool[npcList[i]] = npcMoneyValue;
            }
        } else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showLeaderboard()
    {
        string[] npcOrderedList = {"", "", "", "", "", "", ""};
        float[] npcOrderedValue = { 0, 0, 0, 0, 0, 0, 0 };

        for (int i = 0; i < npcPool.Count; i++)
        {
            if (npcPool[npcList[i]] < npcPool[npcList[i - 1]])
            {
                npcOrderedList[i - 1] = npcList[i];
                npcOrderedValue[i -1] = npcPool[npcList[i]];
            } else
            {
                npcOrderedList[i] = npcList[i];
                npcOrderedValue[i] = npcPool[npcList[i]];
            }
        }

        npcText1.text = npcOrderedList[0];
        npcText2.text = npcOrderedList[1];
        npcText3.text = npcOrderedList[2];
        npcText4.text = npcOrderedList[3];
        npcText5.text = npcOrderedList[4];
        npcText6.text = npcOrderedList[5];
        npcText7.text = npcOrderedList[6];

        npcValue1.text = npcOrderedValue[0];
    }
}
