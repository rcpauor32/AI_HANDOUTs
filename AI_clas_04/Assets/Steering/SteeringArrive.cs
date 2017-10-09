using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float slow_distance = 5.0f;
	public float time_to_target = 0.1f;

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
        if (!move)
            move = GetComponent<Move>();

        // TODO 3: Create a vector to calculate our ideal velocity
        // then calculate the acceleration needed to match that velocity
        // before sending it to move.AccelerateMovement() clamp it to 
        // move.max_mov_acceleration
        if (Vector3.Distance(this.transform.position, target) < slow_distance)
        {
            float dist = Vector3.Distance(this.transform.position, target);
            float slow_v = dist / slow_distance;
            Vector3 A = this.transform.position;
            Vector3 B = target;

            Vector3 dir_v = B - A;
            dir_v.Normalize();
            move.AccelerateMovement(dir_v * move.max_mov_velocity);
            move.movement *= slow_v;
        }
        if (Vector3.Distance(this.transform.position, target) < min_distance)
        {
            move.movement = Vector3.zero;
        }
	}

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}
