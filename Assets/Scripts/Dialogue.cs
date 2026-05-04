using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string[] nameExtra;

    [TextArea(3, 10)] //sets min and max lines the text area will use
    public string[] sentences;
}
