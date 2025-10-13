using System.Collections;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public NPC npc1;
	public Item bottle;
	public DialogLine dialog2;

	// Use this for initialization
	IEnumerator Start() {
		bool talkedToNPC1 = false;
		npc1.onInteracted += () => {
			talkedToNPC1 = true;
		};
		//die coroutine wartet
		yield return new WaitUntil(() => talkedToNPC1);

		bottle.gameObject.SetActive(true);

		bool gotBottle = false;
		bottle.onInteracted += () => {
			gotBottle = true;
		};
		//die coroutine wartet
		yield return new WaitUntil(() => gotBottle);

		Destroy(bottle.gameObject);
		npc1.dialog = dialog2;
	}

	// Update is called once per frame
	void Update() {

	}
}
