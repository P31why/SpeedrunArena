using Assets.Scripts;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class Door : MonoBehaviour,IInteractableItem
{
    private bool _isOpen;
    [SerializeField]
    private Animator _animator;
    private void Awake()
    {
        _isOpen = false;
    }
    public void Interact()
    {
        _isOpen = true;
        if (_isOpen)
        {
            _animator.Play("Opening");
            StartCoroutine(doorClosing());
        }
    }
    IEnumerator doorClosing()
    {
        yield return new WaitForSeconds(4);
        _isOpen = false;
        _animator.Play("Closing");
    }
}
