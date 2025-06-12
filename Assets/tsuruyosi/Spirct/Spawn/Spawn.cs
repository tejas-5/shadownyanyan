using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Vector3 strat;

    void Start()
    {
        strat = GameObject.FindWithTag("start").transform.position;
        GameObject.FindWithTag("Player").transform.position = new Vector3(strat.x, strat.y, strat.z);
    }

    void Update()
    {
        
    }
}
