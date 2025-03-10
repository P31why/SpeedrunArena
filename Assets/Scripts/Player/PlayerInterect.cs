using Assets.Scripts;
using UnityEngine;

public class PlayerInterect : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private float _distance;
    [SerializeField] private Camera _camera;
    public Transform crosshair;
    public LayerMask layerMask;
    private GameObject currentItem;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            RaycastObject(true);
        else RaycastObject(false);
    }
    public void RaycastObject(bool buttonPressed)
    {
        _ray = _camera.ScreenPointToRay(crosshair.position);
        if (Physics.Raycast(_ray,out _hit,_distance,layerMask))
        {
            if (_hit.collider != null)
            {
                GameObject obj = _hit.collider.gameObject;
                if (obj.TryGetComponent<IInteractableItem>(out IInteractableItem item))
                {
                    obj.GetComponent<Outline>().enabled = true;
                    currentItem = obj;
                    if (buttonPressed)
                        item.Interact();
                }
                else if (obj.CompareTag("Item"))
                {
                    obj.GetComponent<Outline>().enabled = true;
                    currentItem = obj;
                    if (buttonPressed)
                    {
                        gameObject.GetComponent<Hand>().AddItem(obj);
                        Debug.Log("+ item");
                    }
                }
            }
        }
        else
        {
            if (currentItem != null)
                currentItem.GetComponent<Outline>().enabled = false;
        }
    }
}
