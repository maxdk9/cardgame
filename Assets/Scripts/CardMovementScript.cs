using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovementScript : MonoBehaviour ,IBeginDragHandler,IDragHandler,IEndDragHandler
{
	public  Camera MainCamera;

	public bool isDraggable;

	private Vector3 offset;
	public Transform DefaultParent;

	public Transform DefaultTempCardParent;

	public GameObject TempCardGo;
    public GameManager gameManager;
	
	// Use this for initialization
	void Start () {
        MainCamera = Camera.allCameras[0];
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		int siblingIndex = transform.GetSiblingIndex();
		offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
		DefaultParent =DefaultTempCardParent= transform.parent;
		
		isDraggable = (DefaultParent.GetComponent<DropPlayScript>().FieldType == FieldType.selfhand||
            DefaultParent.GetComponent<DropPlayScript>().FieldType==FieldType.selffield
            )&&gameManager.IsPlayerTurn;
		if (!isDraggable)
		{
			return;
		}

		
		Debug.Log("sibling index= "+siblingIndex);
		TempCardGo.transform.SetParent(DefaultParent);
		TempCardGo.transform.SetSiblingIndex(siblingIndex);
		
		
		
		
		
		GetComponent<CanvasGroup>().blocksRaycasts = false;
		transform.SetParent(DefaultParent.parent);
		
		
	}

	public void OnDrag(PointerEventData eventData)
	{

		if (!isDraggable)
		{
			return;
		}
		Vector3 newpos = MainCamera.ScreenToWorldPoint(eventData.position);
		//newpos.z = 0;
		transform.position = newpos+offset;
	
		if (TempCardGo.transform.parent != DefaultTempCardParent)
		{
			TempCardGo.transform.SetParent(DefaultTempCardParent);
		}


        if (DefaultParent.GetComponent<DropPlayScript>().FieldType != FieldType.selfhand)
        {
            CheckPosition();
        }
	}

	public void OnEndDrag(PointerEventData eventData)
	{

		if (!isDraggable)
		{
			return;
		}
		transform.SetParent(DefaultParent);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		TempCardGo.transform.SetParent(GameObject.Find("Canvas").transform);
		TempCardGo.transform.localPosition=new Vector2(1800,0);
		
		transform.SetSiblingIndex(TempCardGo.transform.GetSiblingIndex());
	}

	private void Awake()
	{
		TempCardGo=GameObject.Find("TempCardGO");
	}


	void CheckPosition()
	{
		int newIndex = DefaultTempCardParent.childCount;
		for (int i = 0; i < DefaultTempCardParent.childCount; i++)
		{

			if (transform.position.x < DefaultTempCardParent.GetChild(i).transform.position.x)
			{
				newIndex = i;
				if (TempCardGo.transform.GetSiblingIndex() < newIndex)
				{
					newIndex--;
				}
				break;
				

			}
		}
		TempCardGo.transform.SetSiblingIndex(newIndex);
	}
}
