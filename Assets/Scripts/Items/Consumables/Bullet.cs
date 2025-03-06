using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DeleteBullet());
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "Player":
                {
                    Debug.Log("hit");
                    break;
                }
            default:
                Debug.Log("Hit obj"+collision.gameObject.name);
                Destroy(gameObject);
                break;
        }
    }
    IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
