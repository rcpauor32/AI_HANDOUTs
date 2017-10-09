using UnityEngine;
using System.Collections;

public class SteeringVelocityMatching : MonoBehaviour {

	public float time_to_target = 0.25f;

	Move move;
	Move target_move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		target_move = move.target.GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(target_move)
		{
            // TODO 5: First come up with your ideal velocity
            // then accelerate to it. 
            Vector3 dir = target_move.transform.position - this.transform.position;
            dir.Normalize();
            move.max_mov_velocity = target_move.max_mov_velocity;
            move.AccelerateMovement(dir * move.max_mov_velocity);

		}
	}
}
