using UnityEngine;
using System.Collections;

public class SteeringSeek : MonoBehaviour {

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
        // TODO 1: accelerate towards our target at max_acceleration
        // use move.AccelerateMovement()
        Vector3 A = this.transform.position;
        Vector3 B = target;

        Vector3 dir_v = B - A;
        dir_v.Normalize();

        move.AccelerateMovement(dir_v * move.max_mov_acceleration);

	}
}
