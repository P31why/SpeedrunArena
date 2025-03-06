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
            //Debug.Log(_hit.collider.gameObject.name);
            if (_hit.collider != null)
            {
                GameObject obj = _hit.collider.gameObject;
                if (obj.GetComponent<IInteractableItem>() != null)
                {
                    obj.GetComponent<Outline>().enabled = true;
                    currentItem = obj;
                    if (buttonPressed)
                        obj.GetComponent<IInteractableItem>().Interact();

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
