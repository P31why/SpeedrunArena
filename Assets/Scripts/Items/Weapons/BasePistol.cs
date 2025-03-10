using UnityEngine;
using Assets.Scripts;
using System.Collections;

public class BasePistol : MonoBehaviour, IEquipbleItem,IGun
{
    [SerializeField]
    private GameObject _playerHand;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _shootpoint;
    [SerializeField]
    private float _shootForce;

    [SerializeField]
    private float _shootTime;
    public void Equip()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.parent = _playerHand.transform;
        gameObject.transform.position = _playerHand.transform.position;
        gameObject.transform.rotation = _playerHand.transform.rotation;
       // gameObject.transform.localRotation =  Quaternion.Euler(Vector3.forward.normalized);
    }
    public void Drop()
    {
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100);
    }
    public void Shoot()
    {
        if (_shootTime <= 0)
        {
            GameObject obj = Instantiate(_bullet, _shootpoint.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().AddForce(Vector3.forward * _shootForce,ForceMode.Force);
            _shootTime = 3;
            StartCoroutine(CheckTime());
        }
    }
    IEnumerator CheckTime()
    {
        while (_shootTime > 0)
        {
            yield return new WaitForSeconds(0.1f);
            _shootTime -= 1;
        }
    }
}
