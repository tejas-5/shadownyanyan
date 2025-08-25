using UnityEngine;
[System.Serializable]
public class DialogueLine
{
    public enum Speaker { Player, Shadow }

    public Speaker speaker;

    [TextArea]  // ให้พิมพ์หลายบรรทัดใน Inspector
    public string text;
}