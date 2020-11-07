using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	[SerializeField] KeyCode ReloadButton = KeyCode.R;
	private void Update () {
		if (Input.GetKeyDown (ReloadButton))
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}