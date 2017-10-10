using UnityEngine;
using System.Collections;

public class SteeringSeparation : MonoBehaviour {

	public LayerMask mask;
	public float search_radius = 5.0f;
	public AnimationCurve falloff;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
        mask = 8;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 1: Agents much separate from each other:
        // 1- Find other agents in the vicinity (use a layer for all agents)
        // 2- For each of them calculate a escape vector using the AnimationCurve
        // 3- Sum up all vectors and trim down to maximum acceleration

        Vector3 escape_vector = this.transform.position;

        Collider[] inRange_colliders = Physics.OverlapSphere(this.transform.position, search_radius, mask.value);
        foreach(Collider col in inRange_colliders)
        {
            Vector3 repulsion_vector = this.transform.position - col.transform.position;
            escape_vector += repulsion_vector;
        }

        escape_vector = escape_vector.normalized * move.max_mov_acceleration * falloff.Evaluate(Time.time * 0.1f);

        move.AccelerateMovement(escape_vector);

	}

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, search_radius);
	}
}
