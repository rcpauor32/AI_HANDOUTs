using UnityEngine;
using System.Collections;

public class SteeringAlign : MonoBehaviour {

	public float min_angle = 0.01f;
	public float slow_angle = 0.1f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 4: As with arrive, we first construct our ideal rotation
        // then accelerate to it. Use Mathf.DeltaAngle() to wrap around PI
        // Is the same as arrive but with angular velocities
        Vector3 target_dir = move.target.transform.position - this.transform.position;
        Vector3 object_dir = this.transform.forward;

        float angle_a = Mathf.Rad2Deg * Mathf.Atan2(target_dir.z, target_dir.x);
        float angle_b = Mathf.Rad2Deg * Mathf.Atan2(object_dir.z, object_dir.x);

        float dangle = Mathf.DeltaAngle(angle_a, angle_b);

        if(Mathf.Abs(dangle) > min_angle)
        {
            float percentatge = 1;

            if(Mathf.Abs(dangle) < slow_angle)
            {
                percentatge = dangle / slow_angle;
            }

            move.AccelerateRotation(percentatge * (move.max_mov_acceleration / Time.deltaTime));
        }

    }
}
