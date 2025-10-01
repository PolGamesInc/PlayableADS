using System.Collections;
using UnityEngine;

public class TapMiniGameLine3 : MonoBehaviour
{
    [SerializeField] private Animator Line3;
    [SerializeField] private Animator ChickAnimator;
    [SerializeField] private Animator Cars;
    [SerializeField] private Animator Win;
    [SerializeField] private Animator RoadMiniGame;
    [SerializeField] private Animator Fog;
    [SerializeField] private Animator BackGround;

    [SerializeField] private GameObject CarTaxiBarier;

    public GameObject Line3Object;
    public GameObject ButtomLine3;
    public GameObject Cursor4;

    [SerializeField] private GameObject WinObject;
    [SerializeField] private GameObject RoadMiniGameObject;

    [SerializeField] private GameObject CarsObject;
    [SerializeField] private GameObject Chick;
    [SerializeField] private GameObject Barier;

    private string animationTrigger = "ClickLine3";
    private string TrigerOut = "Out";

    private void Start()
    {
        Line3Object.SetActive(false);
        ButtomLine3.SetActive(false);
        Cursor4.SetActive(false);
        Chick.SetActive(false);
        CarsObject.SetActive(false);
        WinObject.SetActive(false);
        BackGround.enabled = false;
    }

    public void OnClickLine3()
    {
        Line3.SetTrigger(animationTrigger);
        Line3Object.SetActive(true);
        ButtomLine3.SetActive(false);
        StartCoroutine(WaitLine3());
        Cursor4.SetActive(false);
    }

    private IEnumerator WaitLine3()
    {
        yield return new WaitForSeconds(1f);
        Line3Object.SetActive(false);
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
        RoadMiniGame.SetTrigger(TrigerOut);
        Fog.SetTrigger(TrigerOut);
        StartCoroutine(WaitFogAndRoad());
    }

    private IEnumerator WaitFogAndRoad()
    {
        yield return new WaitForSeconds(0.2f);
        BackGround.enabled = true;
        BackGround.SetTrigger(TrigerOut);
        Barier.SetActive(false);
        CarTaxiBarier.SetActive(false);
    }
}
