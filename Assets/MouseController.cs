using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	public int mX,mY;

	private int rotationOffSet = -90;
	private float x,y,rotZ;

	public 
	
	// Update is called once per frame
	void FixedUpdate () {
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;

		Vector3 difference = GetComponent<Camera>().ScreenToWorldPoint (new Vector3(x,y,Mathf.Abs(transform.position.z))) - transform.position;

		mX = (int)difference.x;
		mY = (int)difference.y;

		//difference.Normalize (); // x+y+z=1

		//rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg; // angle °
		//transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffSet);
	}
}
