using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TapGo : MonoBehaviour
{
    [SerializeField] private Animator Go;
    [SerializeField] private Animator ChickenJump;
    [SerializeField] private Animator ChickenOnBike;
    [SerializeField] private Animator Barier;
    [SerializeField] private Animator MiniGameRoadAnimator;
    [SerializeField] private Animator FogAnimator;
    [SerializeField] private Animator CarTaxiBarier;

    public Animator ManholesAnimator;

    [SerializeField] private GameObject Fog;
    [SerializeField] private GameObject Bike;
    [SerializeField] private GameObject Cursor;
    [SerializeField] private GameObject CarTaxi;
    [SerializeField] private GameObject BarierObject;
    [SerializeField] private GameObject MiniGameRoad;
    public GameObject Manholes;
    private string animationTrigger = "ClickGo";

    public GameObject TapMiniGameScript;

    private void Start()
    {
        Go.Play("Idle");
        Bike.SetActive(true);
        Cursor.SetActive(true);
        BarierObject.SetActive(false);
        MiniGameRoad.SetActive(false);
        Fog.SetActive(false);
        CarTaxiBarier.enabled = false;
        Manholes.SetActive(false);
        ManholesAnimator.enabled = false;
    }

    public void OnClickGoButton()
    {
        Go.SetTrigger(animationTrigger);
        ChickenJump.SetTrigger(animationTrigger);
        Cursor.SetActive(false);
        StartCoroutine(WaitOnBike());
        ChickenOnBike.SetTrigger(animationTrigger);
        CarTaxi.SetActive(false);
        BarierObject.SetActive(true);
        Barier.SetTrigger(animationTrigger);
        StartCoroutine(WaitMiniGame());
        CarTaxiBarier.enabled = true;
        CarTaxiBarier.SetTrigger(animationTrigger);
    }

    private IEnumerator WaitOnBike()
    {
        yield return new WaitForSeconds(0.30f);
        Bike.SetActive(false);
    }

    private IEnumerator WaitMiniGame()
    {
        yield return new WaitForSeconds(1f);
        MiniGameRoad.SetActive(true);
        MiniGameRoadAnimator.SetTrigger(animationTrigger);
        Fog.SetActive(true);
        FogAnimator.SetTrigger(animationTrigger);
        TapMiniGameScript.GetComponent<TapMiniGame>().ButtomLine1.SetActive(true);
        TapMiniGameScript.GetComponent<TapMiniGame>().Cursor2.SetActive(true);
        ManholesAnimator.enabled = true;
        Manholes.SetActive(true);
        ManholesAnimator.SetTrigger(animationTrigger);
    }
}
