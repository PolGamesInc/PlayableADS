using System.Collections;
using UnityEngine;

public class TapMiniGameLine2 : MonoBehaviour
{
    [SerializeField] private Animator Line2;
    [SerializeField] private Animator ChickAnimator;
    [SerializeField] private Animator Cars;
    [SerializeField] private Animator Win;
    [SerializeField] private Animator manholesTwo;

    public GameObject Line2Object;
    public GameObject ButtomLine2;
    public GameObject Cursor3;

    [SerializeField] private GameObject WinObject;

    [SerializeField] private GameObject CarsObject;
    [SerializeField] private GameObject Chick;
    public GameObject ManholesTwoObject;

    [SerializeField] private GameObject CanvasObject;

    private string animationTrigger = "ClickLine2";

    private void Start()
    {
        Line2Object.SetActive(false);
        ButtomLine2.SetActive(false);
        Cursor3.SetActive(false);
        Chick.SetActive(false);
        CarsObject.SetActive(false);
        WinObject.SetActive(false);
        ManholesTwoObject.SetActive(false);
    }

    public void OnClickLine2()
    {
        Line2.SetTrigger(animationTrigger);
        Line2Object.SetActive(true);
        ButtomLine2.SetActive(false);
        StartCoroutine(WaitLine2());
        Cursor3.SetActive(false);
    }

    private IEnumerator WaitLine2()
    {
        yield return new WaitForSeconds(1f);
        Line2Object.SetActive(false);
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
        CanvasObject.GetComponent<TapMiniGameLine3>().Cursor4.SetActive(true);
        CanvasObject.GetComponent<TapMiniGameLine3>().ButtomLine3.SetActive(true);
        StartCoroutine(WaitManholeOne());
    }

    private IEnumerator WaitManholeOne()
    {
        yield return new WaitForSeconds(0.4f);
        manholesTwo.SetTrigger(animationTrigger);
    }
}
