using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActive : MonoBehaviour {

	public PassiveMechanics mechanics;

	public void StartActiveScript()
	{
		mechanics.enabled = true;
	}
}
