using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
	void FixedUpdate()
	{
		var h_val = Input.GetAxis("Horizontal");
		var v_val = Input.GetAxis("Vertical");
		var rigidbody = GetComponent<Rigidbody>();
		rigidbody.AddTorque(transform.TransformVector(new Vector3(0f, h_val, 0f)*2f));
		rigidbody.AddTorque(transform.TransformVector(new Vector3(v_val, 0f, 0f)*2f));
		rigidbody.AddTorque(transform.TransformVector(new Vector3(0f, 0f, -h_val)*1f));
		var forward = transform.TransformVector(Vector3.forward);
		var left = transform.TransformVector(Vector3.left);
		var horizontal_forward = new Vector3(forward.x, 0f, forward.z).normalized;
		var horizontal_left = Vector3.Cross(Vector3.up, horizontal_forward);
		rigidbody.AddTorque(Vector3.Cross(forward, horizontal_forward)*2f);
		rigidbody.AddTorque(Vector3.Cross(horizontal_left, left)*2f);

		rigidbody.AddForce(transform.TransformVector(new Vector3(0f, 0f, 200f)));	
	}
}
