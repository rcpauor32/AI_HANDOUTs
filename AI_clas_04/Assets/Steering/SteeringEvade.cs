using UnityEngine;
using System.Collections;


public class SteeringEvade : MonoBehaviour {
    public float max_prediction;

    public float distance = 40;

    Move move;
    SteeringSeek seek;
    SteeringArrive arrive;

    // Use this for initialization
    void Start () {

        move = GetComponent<Move>();
        arrive = GetComponent<SteeringArrive>();
        seek = GetComponent<SteeringSeek>();
    }
	
	// Update is called once per frame
	void Update () {

        Steer(move.target.transform.position, move.target.GetComponent<Move>().movement);

    }

    public void Steer(Vector3 target, Vector3 velocity)
    {

        if (Vector3.Distance(transform.position, target) < distance)
        {
            Vector3 prediction = target + velocity * max_prediction;
            Vector3 inverse_dir = transform.position - prediction;
            move.AccelerateMovement(inverse_dir.normalized * move.max_mov_acceleration);
        }
        

    }


}
