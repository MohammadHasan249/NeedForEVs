using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackChargingStation : MonoBehaviour
{

    private Rigidbody rb;
    private LineRenderer line;
    private List<Vector3> point;

    public Camera cam;
    private NavMeshAgent agent;
    private Transform agentTransform;
    public GameObject[] chargingStations;
    private float shortestDistance = 999999f;
    private GameObject closestStation;
    public float lineWidth = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agentTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();
        line.SetColors(Color.white, Color.white);
        line.SetWidth(lineWidth, lineWidth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                if(hit.collider.gameObject.tag == "Obstacle"){
                    // Do nothing
                } else {
                    shortestDistance = 999999f;
                    agentTransform.position = hit.point;
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    // show the path finding to the nearest charging station
                    int checker = 0;
                    int cc = 0;
                    foreach(GameObject station in chargingStations){
                        float temp = Vector3.Distance(agentTransform.position, station.transform.position);
                        if(shortestDistance > temp){
                            shortestDistance = temp;
                            closestStation = station;
                            cc = checker;
                        }
                        checker += 1;
                    }
                    agent.SetDestination(closestStation.transform.position);
                    // at this point in time, closestStation has the target location
                    // at this point in time, agentTransform has the agent position.
                    //agent.SetDestination(closestStation.position);
                }
            }
        }
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // Pathfinding done: disable mesh for now
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
        DisplayLineDestination();
    }

    private void DisplayLineDestination(){
        if(agent.path.corners.Length < 2) return;

        int i = 1;
        while(i < agent.path.corners.Length){
            line.positionCount = agent.path.corners.Length;
            // point = agent.path.corners.ToList();
            point = new List<Vector3>(agent.path.corners);
            for(int j = 0; j < point.Count; j++){
                line.SetPosition(j, point[j]);
            }
            i++;
        }
    }
}
