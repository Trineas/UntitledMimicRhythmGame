using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject followObject;
    public Vector2 followOffset;
    private Vector2 treshold;
    public float speed = 3f;
    private Rigidbody rb;

    void Start()
    {
        treshold = calculateTreshold();
        rb = followObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 follow = followObject.transform.position;
        float xDifference = Vector3.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector3.Distance(Vector2.up * transform.position.x, Vector2.up * follow.y);

        Vector2 newPosition = transform.position;

        if (Mathf.Abs(xDifference) >= treshold.x)
        {
            newPosition.x = follow.x;
        }

        if (Mathf.Abs(yDifference) >= treshold.y)
        {
            newPosition.y = follow.y;
        }

        float moveSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }

    private Vector2 calculateTreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateTreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }

}
