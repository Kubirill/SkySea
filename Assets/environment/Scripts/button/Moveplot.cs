using UnityEngine;

public class Moveplot : MonoBehaviour {
    [SerializeField] GameObject pet;
    [SerializeField] Transform LeftB;
    [SerializeField] Transform RightB;
    [SerializeField] Transform center;
    void Update () {
        if (Input.GetKeyDown (KeyCode.LeftArrow))
            leftButton ();
        if (Input.GetKeyDown (KeyCode.RightArrow))
            rightButton ();
        if (Input.GetKeyDown (KeyCode.UpArrow))
            centerButton ();
    }
    void leftButton () =>
        pet.transform.position = new Vector3 (LeftB.position.x, LeftB.position.y + 5, LeftB.position.z);

    void rightButton () =>
        pet.transform.position = new Vector3 (RightB.position.x, RightB.position.y + 5, RightB.position.z);

    void centerButton () =>
        pet.transform.position = new Vector3 (center.position.x, center.position.y + 5, center.position.z);

}