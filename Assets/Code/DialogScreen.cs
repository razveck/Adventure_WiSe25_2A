using TMPro;
using UnityEngine;

public class DialogScreen : MonoBehaviour {

	private DialogLine currentLine;

	public GameObject panel;
	public TMP_Text nameTMP;
	public TMP_Text dialogTextTMP;
	public GameObject[] choiceButtons;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	public void ShowDialog(DialogLine dialog, string speakerName) {
		currentLine = dialog;

		nameTMP.text = speakerName;
		dialogTextTMP.text = dialog.text;

		panel.SetActive(true);
	}

	public void HideDialog(){
		panel.SetActive(false);
	}

	public void SelectChoice(int index){
		ShowDialog(currentLine.choices[index].nextLine, "");
	}

}
