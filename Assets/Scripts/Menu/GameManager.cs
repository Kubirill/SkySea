using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{

    [SerializeField] DragonMove DragonMove;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject playerCamera;
    string btnEvent;
    bool useEffects = false;
    // timers for press on long focus
    public void Focus(string buttonEvent)
    {
        // the button function is set by the name on the button itself
        btnEvent = buttonEvent;
        print("Focus Button: " + btnEvent);
        StartCoroutine(Press());
    }
    public void UnFocus()
    {
        print("Defocus Button");
        btnEvent = "Pass";
    }
    IEnumerator Press()
    {
        // if we look at button 2s, we press button
        yield return new WaitForSeconds(2f);
        Invoke(btnEvent, 0);
    }
    public void PressStart()
    {
        print("Start game 🏁");
        // we start game
        DragonMove.enabled = true;
        DragonMove.gameObject.GetComponent<Rigidbody>().useGravity = true;
        if (startButton == null)
            startButton = GameObject.Find("Menu/StartButton");
        // delete button
        startButton.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 1f);
        Destroy(startButton, 2f);
    }
    public void Restart()
    {
        print("Restart game! 🔁");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Pass()
    {
        print("Nothing to press..");
    }
    public void MakeEffects()
    {
        print($"57. GameManager -> useEffects : {useEffects}");
        playerCamera.GetComponent<PostProcessVolume>().enabled = useEffects;
        playerCamera.GetComponent<PostProcessLayer>().enabled = useEffects;
        useEffects = !useEffects;

    }
}
