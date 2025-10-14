using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DialogScreen : MonoBehaviour {

	private DialogLine currentLine;
	private string currentSpeaker;

	//string ist die ID von der Choice
	public event System.Action<string> onChoiceSelected;

	public GameObject panel;
	public TMP_Text nameTMP;
	public TMP_Text dialogTextTMP;
	public GameObject[] choiceButtons;
	public GameObject continueButton;

	public PlayerInput input;
	public CinemachineInputAxisController cinemachineController;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		
	}

	public void ShowDialog(DialogLine dialog, string speakerName) {
		currentLine = dialog;
		currentSpeaker = speakerName;

		nameTMP.text = speakerName;
		dialogTextTMP.text = dialog.text;

		//for loop
		for(int i = 0; i < choiceButtons.Length; i++) {
			if(i < dialog.choices.Length) {
				choiceButtons[i].SetActive(true);
				choiceButtons[i].GetComponentInChildren<TMP_Text>().text = dialog.choices[i].text;
			} else {
				choiceButtons[i].SetActive(false);
			}
		}

		if(dialog.choices.Length == 0) {
			continueButton.SetActive(true);
			EventSystem.current.SetSelectedGameObject(continueButton);
		} else {
			continueButton.SetActive(false);
			EventSystem.current.SetSelectedGameObject(choiceButtons[0]);
		}

		input.SwitchCurrentActionMap("UI");
		cinemachineController.enabled = false;
		panel.SetActive(true);
	}

	public void HideDialog() {
		input.SwitchCurrentActionMap("Player");
		cinemachineController.enabled = true;
		panel.SetActive(false);
	}

	public void SelectChoice(int index) {
		onChoiceSelected?.Invoke(currentLine.choices[index].id);
		ShowDialog(currentLine.choices[index].nextLine, currentSpeaker);

		//optional
		//if(currentLine.choices[index].nextLine != null)
		//	ShowDialog(currentLine.choices[index].nextLine, currentSpeaker);
		//else
		//	HideDialog();
	}

	public void Continue() {
		if(currentLine.nextLine != null)
			ShowDialog(currentLine.nextLine, currentSpeaker);
		else
			HideDialog();
	}

}
