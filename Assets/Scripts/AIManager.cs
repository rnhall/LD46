using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{

    public MeshAgent[] agents;
    public GameObject player;

    private int visionCone = 180;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (MeshAgent agent in agents)
        {
            List<GameObject> agentsInFOV = CheckFieldOfVision(agent);
            if (agent.tag == "Police" && agentsInFOV.Contains(player))
            {
            }

        }
    }

    public List<GameObject> CheckFieldOfVision(MeshAgent agent)
    {
        List<GameObject> hits = new List<GameObject>();

        foreach (MeshAgent agentTwo in agents)
        {
            RaycastHit hit;
            if (Physics.Linecast(agent.transform.position, agentTwo.transform.position, out hit))
            {
                float angle = Vector3.Dot(agent.transform.forward, agent.transform.position - agentTwo.transform.position);
                if (hit.collider.gameObject.layer != 9 && angle < 0)
                {
                    hits.Add(hit.collider.gameObject);
                    Debug.DrawLine(agent.transform.position, agentTwo.transform.position, Color.black);
                }
            }
        }
        return hits;
    }
}
