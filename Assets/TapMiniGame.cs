using System.Collections;
using UnityEngine;

public class TapMiniGame : MonoBehaviour
{
    [SerializeField] private Animator Line1;
    [SerializeField] private Animator ChickAnimator;
    [SerializeField] private Animator Cars;
    [SerializeField] private Animator Win;

    public GameObject Line1Object;
    public GameObject ButtomLine1;
    public GameObject Cursor2;

    [SerializeField] private GameObject WinObject;

    [SerializeField] private GameObject CarsObject;
    [SerializeField] private GameObject Chick;

    [SerializeField] private GameObject CanvasObject;

    private string animationTrigger = "ClickLine";

    private void Start()
    {
        Line1Object.SetActive(false);
        ButtomLine1.SetActive(false);
        Cursor2.SetActive(false);
        Chick.SetActive(false);
        CarsObject.SetActive(false);
        WinObject.SetActive(false);
    }

    public void OnClickLine1()
    {
        Line1.SetTrigger(animationTrigger);
        Line1Object.SetActive(true);
        ButtomLine1.SetActive(false);
        StartCoroutine(WaitLine1());
        Cursor2.SetActive(false);
    }

    private IEnumerator WaitLine1()
    {
        yield return new WaitForSeconds(1f);
        Line1Object.SetActive(false);
        Chick.SetActive(true);
        ChickAnimator.SetTrigger(animationTrigger);
        StartCoroutine(WaitChicken());
        CarsObject.SetActive(true);
        Cars.SetTrigger(animationTrigger);
        StartCoroutine(WaitCars());
    }

    private IEnumerator WaitChicken()
    {
        yield return new WaitForSeconds(3.1f);
        Chick.SetActive(false);
        WinObject.SetActive(true);
        Win.SetTrigger(animationTrigger);
        StartCoroutine(WaitHideWin());
    }

    private IEnumerator WaitCars()
    {
        yield return new WaitForSeconds(1.05f);
        CarsObject.SetActive(false);
    }

    private IEnumerator WaitHideWin()
    {
        yield return new WaitForSeconds(1f);
        WinObject.SetActive(false);
        CanvasObject.GetComponent<TapMiniGameLine2>().Cursor3.SetActive(true);
        CanvasObject.GetComponent<TapMiniGameLine2>().ButtomLine2.SetActive(true);
    }
}
