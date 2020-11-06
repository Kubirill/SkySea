using DG.Tweening;
using UnityEngine;
public class Rotate : MonoBehaviour {

	[SerializeField] Transform plot;
	[SerializeField] bool left;
	[SerializeField] float smooth = 0.3f;
	[SerializeField] float angle = 15;
	float rotAngle = 0;

	private void OnTriggerEnter () {
		// string msg = "Turn on " + (left ? "left" : "right") + $" with {angle}";
		// print (msg);
		rotAngle = left ? -15 : 15;
		print ($"15. Rotate -> rotAngle : {rotAngle}");
		plot.DORotate (new Vector3 (0, rotAngle, 0), smooth);
	}
}