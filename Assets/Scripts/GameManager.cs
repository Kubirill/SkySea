using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameManager : MonoBehaviour
{

    [SerializeField] DragonMove DragonMove;
    [SerializeField] GameObject startButton;
    public void PressStart()
    {
        DragonMove.enabled = true;
        if (startButton == null)
            startButton = GameObject.Find("Menu/StartButton");
        startButton.transform.DOScale(new Vector3(0.001f, 0.001f, 0.001f), 1f);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
