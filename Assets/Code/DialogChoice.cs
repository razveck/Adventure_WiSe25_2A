using UnityEngine;

[System.Serializable] //sagt Unity, dass die Klasse serialisiert werden darf (im Inspector angezeigt werden darf)
public class DialogChoice //kein MonoBehaviour
{
    public string text;
    public DialogLine nextLine;
}
