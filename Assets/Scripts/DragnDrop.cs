using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DragnDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    public GameObject RangeUI;
    Image m_SpriteRenderer;
    

    public GameObject draggedT;

    public GameObject cancelButtonObj;
    public GameObject turret;
    Vector2 startPosition;
    private RectTransform rectTransform;

    bool AvailablePos = true;

    public TextMeshProUGUI textCountdown;
    bool timerIsRunning = false;
    public float timeRemaining = 4;

    GameObject menu;
    DragMenuAnimations menuAnimations;

    public GameObject Turret;
    Placement placement;
    public Currency currencyScript;
    public Shop shopScript;
    private void Awake()
    {
        menu = GameObject.Find("Panel (1)");
        //menuAnimations = menu.GetComponent<DragMenuAnimations>();
        m_SpriteRenderer = RangeUI.GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {
        placement = Turret.GetComponent<Placement>();
        textCountdown.enabled = false;
        startPosition = gameObject.transform.position;
        currencyScript = GameObject.Find("Currency").GetComponent<Currency>();
        shopScript = gameObject.GetComponent<Shop>();
    }
    private void Update()
    {

        if (timerIsRunning)
        {
            if (timeRemaining >= 1)
            {
                textCountdown.enabled = true;
                timeRemaining -= Time.deltaTime;
                textCountdown.text = timeRemaining.ToString("0");
            }
            else
            {
                transform.localPosition = new Vector3(0f, 0f, 0f);
                m_SpriteRenderer.enabled = false;
                //RangeUI.SetActive(false);
                //gameObject.transform.localScale /= 1.05f;
                cancelButtonObj.SetActive(false);
                timeRemaining = 0;
                timerIsRunning = false;
                textCountdown.enabled = false;
                //menuAnimations.OnEnableMenu();
            }
        }


        if (placement.collidingNumber > 0)
        {
            
            AvailablePos = false;
            if(m_SpriteRenderer != null)
                m_SpriteRenderer.color = new Color(255, 0, 0, 0.25f);
        }
        if(placement.collidingNumber == 0)
        {
            AvailablePos = true;
            if (m_SpriteRenderer != null)
                m_SpriteRenderer.color = new Color(0, 0, 0, 0.25f);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        m_SpriteRenderer.enabled = true;
        //RangeUI.SetActive(true);
        cancelButtonObj.SetActive(true);
        timerIsRunning = false;
        textCountdown.enabled = false;
        //menuAnimations.CloseMenu();
        //image.color = new Color(255, 255, 255, 1f);


        if (!AvailablePos)
        {
            //this.GetComponent<RectTransform>().localPosition = new Vector3 (0,100,0);
                //gameObject.transform.localScale *= 1.05f;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        //image.color = new Color(255, 255, 255, 1f);
        //cancelButtonObj.SetActive(true);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {


        if (AvailablePos)
        {
            Vector2 spawnPosition = Turret.transform.position;
            GameObject g = Instantiate(turret, spawnPosition, Quaternion.identity);
            //Turret currentTurret = g.GetComponent<Turret>();
            transform.localPosition = new Vector3(0f, 0f, 0f);
            m_SpriteRenderer.enabled = false;
            //RangeUI.SetActive(false);
            //gameObject.transform.localScale /= 1.05f;
            cancelButtonObj.SetActive(false);
            //menuAnimations.OnEnableMenu();
            currencyScript.money -= shopScript.price;

        }
        if(!AvailablePos)
        {
            timerIsRunning = true;
            //menuAnimations.OnEnableMenu();
            timeRemaining = 3;


        }
        if (placement.cancelButton)
        {
            
            timerIsRunning = false;
            transform.localPosition = new Vector3(0f, 0f, 0f);
            m_SpriteRenderer.enabled = false;
            //RangeUI.SetActive(false);
            //gameObject.transform.localScale /= 1.05f;
            cancelButtonObj.SetActive(false);
            //menuAnimations.OnEnableMenu();

        }
    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
    }
    public void BackToStart()
    {
        timerIsRunning = false;
        textCountdown.enabled = false;
        transform.localPosition = new Vector3(0f, 0f, 0f);
        m_SpriteRenderer.enabled = false;
        //cancelButtonObj.SetActive(false);
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("UnPlaceableSpace"))
        {
            collidingNumber = 1;
            Debug.Log(collidingNumber);
        }
    }*/
}