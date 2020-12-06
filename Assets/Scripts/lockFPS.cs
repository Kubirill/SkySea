using UnityEngine;

public class lockFPS : MonoBehaviour {
    private void Awake () => Application.targetFrameRate = 60;
}