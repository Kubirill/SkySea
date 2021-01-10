using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameManager : MonoBehaviour
{

    [SerializeField] DragonMove DragonMove;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject dragonButton;
    public void PressStart()
    {
        DragonMove.enabled = true;
        // disable kinematic
        // DragonMove.gameObject.GetComponent<Rigidbody>().useGravity = true;
        if (startButton == null)
        {
            startButton = GameObject.Find("Menu/StartButton");
        }
        startButton.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 1f);
        dragonButton.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 1f);
    }
    IEnumerator DeleteStartButton()
    {
        yield return new WaitForSeconds(20f);
        // destroy our objects
        Destroy(startButton);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
