using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Coroutine moveCoroutine = null;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
            Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            //Debug.Log(pos);
            mousePosFar = Camera.main.ScreenToWorldPoint(mousePosFar);
            mousePosNear = Camera.main.ScreenToWorldPoint(mousePosNear);
            Debug.DrawRay(mousePosNear, mousePosFar - mousePosNear, Color.green);

            RaycastHit hit;
            Physics.Raycast(mousePosNear, mousePosFar - mousePosNear, out hit, 10f, LayerMask.GetMask("Walkable"));

            if(hit.collider)
            {
                if (moveCoroutine != null)
                    StopCoroutine(moveCoroutine);

                moveCoroutine = StartCoroutine(MoveTowards(hit.transform.position));
            }
        }
    }

    private IEnumerator MoveTowards(Vector3 hitPosition)
    {
        Vector3 moveTo = new Vector3(transform.position.x + (hitPosition.x - transform.position.x), transform.position.y, transform.position.z);
        while (transform.position != moveTo)
        {
            yield return null;
            Debug.Log("coroutine");
            transform.position = Vector3.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Spikes"))
        {
            Destroy(gameObject);
        }
    }
}
