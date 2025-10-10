using UnityEngine;

public class NPC : Interactable {

	public string name;
	public DialogLine dialog;
	public Sprite portrait;
	public DialogScreen dialogScreen;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	public override void Interact() {
		dialogScreen.ShowDialog(dialog, name);
	}
}
