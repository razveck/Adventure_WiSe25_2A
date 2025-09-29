using UnityEngine;

public class Beispiel : MonoBehaviour {

	//public variables können im Inspector zugewiesen werden
	public GameObject objectToDestroy;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		Debug.Log("Start");
	}

	// Update is called once per frame
	void Update() {
		Debug.Log("Update");
	}

	private void OnCollisionEnter(Collision collision) {
		//Destroy(gameObject); //"this" game object

		//Destroy(collision.gameObject); //das andere objekt

		Destroy(objectToDestroy);
	}


}
