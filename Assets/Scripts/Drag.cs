using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
	public GameObject holder;
	public GameObject cube;
    public GameObject electromagnet;

	float speed = 15;
	float maxSpeed = 20;

    public void OnEndDrag(PointerEventData eventData)
    {
        cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!eventData.IsPointerMoving())
            return;

        //Debug.Log(eventData.pointerCurrentRaycast.worldPosition);
        float xSpeed = Input.GetAxis("Mouse X") * speed;
        float ySpeed = Input.GetAxis("Mouse Y") * speed;

        xSpeed = xSpeed > maxSpeed ? maxSpeed : xSpeed;
        ySpeed = ySpeed > maxSpeed ? maxSpeed : ySpeed;

        xSpeed = xSpeed < -maxSpeed ? -maxSpeed : xSpeed;
        ySpeed = ySpeed < -maxSpeed ? -maxSpeed : ySpeed;
        //Debug.Log("x: " + xSpeed + ", y: " + ySpeed);

        //Vector3 direction = Vector3.Normalize(new Vector3(xSpeed, 0, ySpeed));

        //float tempXSpeed = xSpeed < 0 ? -xSpeed : xSpeed;
        //float tempYSpeed = ySpeed < 0 ? -ySpeed : ySpeed;

        //if (tempXSpeed > tempYSpeed)
        //{
        //    // Left or Right.
        //    if (xSpeed < 0)
        //    {
        //        Left();
        //    }
        //    else
        //    {
        //        Right();
        //    }
        //}
        //else
        //{
        //    // Forward or Backward.

        //    if (ySpeed < 0)
        //    {
        //        Backward();
        //    }
        //    else
        //    {
        //        Forward();
        //    }
        //}

        //Vector3 a = new Vector3(eventData.pointerCurrentRaycast.worldPosition.x, transform.position.y, transform.position.z);
        //Vector3 aDirection = a - transform.position;
        //aDirection.y = ySpeed;
        //Debug.Log(aDirection);
        //if(eventData.pointerCurrentRaycast.distance)

        cube.GetComponent<Rigidbody>().AddForce(new Vector3(xSpeed, 0, ySpeed), ForceMode.Force);
        //cube.GetComponent<Rigidbody>().AddForce(aDirection, ForceMode.Force);
    }

    void Left()
    {
        cube.transform.Translate(Vector3.left * Time.fixedDeltaTime);
        //cube.GetComponent<Rigidbody>().AddForce(Vector3.left * speed, ForceMode.Force);
    }
    void Right()
    {
        cube.transform.Translate(Vector3.right * Time.fixedDeltaTime);
        //cube.GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.Force);
    }
    void Forward()
    {
        cube.transform.Translate(Vector3.forward * Time.fixedDeltaTime);
        //cube.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Force);
    }
    void Backward()
    {
        cube.transform.Translate(Vector3.back * Time.fixedDeltaTime);
        //cube.GetComponent<Rigidbody>().AddForce(Vector3.back * speed, ForceMode.Force);
    }

    void FixedUpdate()
    {
        Vector3 newHolderPos = cube.transform.localPosition;
        newHolderPos.x = -newHolderPos.x;
        holder.transform.localPosition = newHolderPos;

       //if()
    }

    //void Update()
    //   {
    //	foreach (Touch touch in Input.touches)
    //	{
    //		if (touch.phase == TouchPhase.Began)
    //		{
    //			Ray ray = Camera.main.ScreenPointToRay(touch.position);
    //			RaycastHit hit;
    //			if (Physics.Raycast(ray, out hit))
    //			{
    //				Debug.Log(hit.collider.gameObject.name);
    //			}
    //		}
    //       }
    //   }
}