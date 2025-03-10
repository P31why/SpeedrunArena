using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private int maxItems=3;
    [SerializeField]
    private int currentItem = 0;
    [SerializeField]
    private GameObject currentGameObject;
    private float _mouseScroll;
    void Update()
    {
        _mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        if (_mouseScroll > 0.1)
        {
            currentItem--;
            if (currentItem <= 0)
                currentItem = gameObject.transform.childCount-1;
            SetActiveItem();
        }
        else if (_mouseScroll < -0.1)
        {
            currentItem++;
            if (currentItem >= maxItems)
                currentItem = 0;
                SetActiveItem();
        }
        if (currentGameObject!=null && Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }
        else if (currentGameObject != null && Input.GetButton("Fire1"))
        {
            currentGameObject.GetComponent<IGun>().Shoot();
        }
    }
    public void AddItem(GameObject item)
    {
        if (gameObject.transform.childCount < maxItems)
        {
            item.GetComponent<IEquipbleItem>().Equip();
            SetActiveItem();
        }  
    }
    public void DropItem()
    {
        currentGameObject.GetComponent<IEquipbleItem>().Drop();
    }
    private void SetActiveItem()
    {
        for (int i=0; i<gameObject.transform.childCount;i++)
        {
            if (currentItem == i)
            {
                GameObject temp = gameObject.transform.GetChild(i).gameObject;
                temp.SetActive(true);
                currentGameObject =temp.gameObject;
            }
            else gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
