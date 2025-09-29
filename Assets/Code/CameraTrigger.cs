using UnityEngine;

public class CameraTrigger : MonoBehaviour
{

	public GameObject cinemachineCamera;

	private void OnTriggerEnter(Collider other) {
		cinemachineCamera.SetActive(true);
	}

	private void OnTriggerExit(Collider other) {
		cinemachineCamera.SetActive(false);
	}

}
