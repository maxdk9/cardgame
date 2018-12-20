using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardScript : MonoBehaviour ,IBeginDragHandler,IDragHandler,IEndDragHandler
{
	public  Camera MainCamera;

	private Vector3 offset;
	public Transform DefaultParent;

	public Transform DefaultTempCardParent;

	public GameObject TempCardGo;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		int siblingIndex = transform.GetSiblingIndex();
		offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
		DefaultParent =DefaultTempCardParent= transform.parent;
		

		
		Debug.Log("sibling index= "+siblingIndex);
		TempCardGo.transform.SetParent(DefaultParent);
		TempCardGo.transform.SetSiblingIndex(siblingIndex);
		
		
		
		GetComponent<CanvasGroup>().blocksRaycasts = false;
		transform.SetParent(DefaultParent.parent);
		
		
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 newpos = MainCamera.ScreenToWorldPoint(eventData.position);
		//newpos.z = 0;
		transform.position = newpos+offset;
		CheckPosition();
		if (TempCardGo.transform.parent != DefaultTempCardParent)
		{
			TempCardGo.transform.SetParent(DefaultTempCardParent);
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
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
