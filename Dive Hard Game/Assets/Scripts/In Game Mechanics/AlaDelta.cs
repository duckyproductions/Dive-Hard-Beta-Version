using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlaDelta : PassiveMechanics
{
	DistanceJoint2D joint;
	Rigidbody2D rb;
    protected override void Execution()//start
    {
		GameObject go = new GameObject();
		rb = GetComponent<Rigidbody2D>();
		GameObject clon = Instantiate(go,transform);
		clon.transform.parent = null;
		Rigidbody2D rbClon = clon.AddComponent<Rigidbody2D>();
		rbClon.constraints = RigidbodyConstraints2D.FreezeAll;
		clon.transform.position += new Vector3(Mathf.Abs(rb.velocity.y), 0, 0);
		joint = transform.gameObject.AddComponent<DistanceJoint2D>();
		joint.connectedBody = rbClon;
		StartCoroutine(Break(joint));
	}
	
	IEnumerator Break(DistanceJoint2D joint)
	{
		yield return new WaitForSeconds(2.5f);
		Destroy(joint);
	}
}
