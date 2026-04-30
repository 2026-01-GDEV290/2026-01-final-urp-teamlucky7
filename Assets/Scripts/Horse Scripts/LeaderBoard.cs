using UnityEngine;
using TMPro;
using System; // Make sure you have TextMeshPro installed

public class LeaderBoard : MonoBehaviour
{
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI horseNameText;

    public void UpdateEntry(int rank, string name)
    {
        rankText.text = rank.ToString();
        horseNameText.text = name;
    }

    internal void UpdateEntry(int v, object horseName)
    {
        throw new NotImplementedException();
    }
}
