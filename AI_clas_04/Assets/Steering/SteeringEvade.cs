using UnityEngine;
using System.Collections;


public class SteeringEvade : MonoBehaviour {
    public float max_prediction;

    Move move;
    SteeringArrive arrive;

    // Use this for initialization
    void Start () {

        move = GetComponent<Move>();
        arrive = GetComponent<SteeringArrive>();
    }
	
	// Update is called once per frame
	void Update () {

        Steer(move.target.transform.position, move.target.GetComponent<Move>().movement);

    }

    public void Steer(Vector3 target, Vector3 velocity)
    {
        
        Vector3 prediction = target + velocity * max_prediction;
        
        arrive.Steer(-prediction);
    }


}
