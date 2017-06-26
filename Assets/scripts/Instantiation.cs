using UnityEngine;

public class Instantiation : MonoBehaviour
{
	public GameObject clone = null;
	void Start ()
	{	
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.X)) {
			clone = Instantiate (Resources.Load ("prefabs/shootiguess"), transform.position+(transform.forward*0.5f), transform.rotation) as GameObject;
		}
	}
}
