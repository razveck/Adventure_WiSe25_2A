using System.Collections;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public DialogScreen dialogScreen;
	public Transform questScreen;
	public GameObject questDisplayPrefab;

	[Header("Quest 1")] //Header attribute
	public NPC npc1;
	public Item bottle;
	public DialogLine dialog2;

	[Header("Quest 2")]
	public NPC npc2;
	public Item pill;
	public DialogLine npc2_dialog2;

	// Use this for initialization
	void Start() {
		//beide quests werden "gleichzeitig" gestartet
		StartCoroutine(Quest1());
		StartCoroutine(Quest2());
		//StopAllCoroutines();
	}

	IEnumerator Quest1() {
		yield return WaitForChoice("quest1accepted");

		GameObject questDisplay = Instantiate(questDisplayPrefab, questScreen);
		var questTMP = questDisplay.GetComponentInChildren<TMP_Text>();

		questTMP.text = "Finde eine Flasche";

		bottle.gameObject.SetActive(true);

		yield return WaitForItem(bottle);

		Destroy(bottle.gameObject);
		npc1.dialog = dialog2;

		questTMP.text = "Bringe die Flasche zurück";

		yield return WaitForNPC(npc1);
		Destroy(questDisplay);
	}

	IEnumerator Quest2() {
		yield return WaitForNPC(npc2);
		yield return new WaitUntil(() => dialogScreen.panel.activeSelf == false);

		GameObject questDisplay = Instantiate(questDisplayPrefab, questScreen);
		var questTMP = questDisplay.GetComponentInChildren<TMP_Text>();

		questTMP.text = "Luigi braucht Medizin";


		pill.gameObject.SetActive(true);

		yield return WaitForItem(pill);

		Destroy(pill.gameObject);
		npc2.dialog = npc2_dialog2;

		questTMP.text = "Bringe die Pille zurück";

		yield return WaitForNPC(npc2);
		Destroy(questDisplay);
	}

	IEnumerator WaitForNPC(NPC npc) {
		bool talkedToNPC = false;

		//variabel, die eine Funktion speichert
		System.Action action = () => {
			talkedToNPC = true;
		};

		npc.onInteracted += action;
		//die coroutine wartet
		yield return new WaitUntil(() => talkedToNPC);

		npc.onInteracted -= action;
	}

	IEnumerator WaitForChoice(string id) {
		bool choiceSelected = false;

		//variabel, die eine Funktion speichert
		System.Action<string> action = (inputId) => {
			if(inputId == id)
				choiceSelected = true;
		};

		dialogScreen.onChoiceSelected += action;
		//die coroutine wartet
		yield return new WaitUntil(() => choiceSelected);

		dialogScreen.onChoiceSelected -= action;
	}

	IEnumerator WaitForItem(Item item) {
		bool gotItem = false;

		//variabel, die eine Funktion speichert
		System.Action action = () => {
			gotItem = true;
		};

		item.onInteracted += action;
		//die coroutine wartet
		yield return new WaitUntil(() => gotItem);

		item.onInteracted -= action;
	}

}
