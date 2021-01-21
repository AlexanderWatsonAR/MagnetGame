using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
	public GameObject cube;
	Vector3 offsetToMouse;
	float zDistanceToCamera;

	float speed = 10;

	Vector3[] points = { new Vector3(-5,-0.02923155f, 1.731407f), new Vector3(-10.34f,-0.02923155f, 1.731407f), new Vector3(5,-0.02923155f, 1.731407f), new Vector3(10.34f,-0.02923155f, 1.731407f),
	new Vector3(-5,-0.02923155f, -11.68f), new Vector3(-10.34f,-0.02923155f, -11.68f), new Vector3(5,-0.02923155f, -11.68f), new Vector3(10.34f,-0.02923155f, -11.68f),
	new Vector3(-5,-0.02923155f, 11.68f), new Vector3(-10.34f,-0.02923155f, 11.68f), new Vector3(5,-0.02923155f, 11.68f), new Vector3(10.34f,-0.02923155f, 11.68f),
	new Vector3(10.34f,-0.02923155f, 15.68f)};

    void Start()
    {
		//yPosition = cube.transform.position.y;
    }

	void OnMouseDown()
    {
		zDistanceToCamera = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

		offsetToMouse = gameObject.transform.position - GetMouseWorldPosition();

		Debug.Log("Drag");
    }

	void OnMouseDrag()
    {
		float xSpeed = Input.GetAxis("Mouse X") * speed;
		float ySpeed = Input.GetAxis("Mouse Y") * speed;

		xSpeed = xSpeed > 25 ? 25 : xSpeed;
		ySpeed = ySpeed > 25 ? 25 : ySpeed;

		Vector3 newVec = GetMouseWorldPosition() + offsetToMouse;
        cube.GetComponent<Rigidbody>().AddForce(new Vector3(xSpeed, 0, newVec.z* -ySpeed), ForceMode.Force);

		Debug.Log(ySpeed);

        //Vector3 newVec = GetMouseWorldPosition() + offsetToMouse;
        //newVec.y = yPosition;


        //cube.transform.position = newVec;
    }

	Vector3 GetMouseWorldPosition()
    {
		Vector3 mousePoint = Input.mousePosition;

		//mousePoint.y = yPosition;
		mousePoint.z = zDistanceToCamera;

		return Camera.main.ScreenToWorldPoint(mousePoint);
    }		
}