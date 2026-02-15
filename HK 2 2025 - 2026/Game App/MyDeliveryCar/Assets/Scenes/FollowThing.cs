using UnityEngine;

public class FollowThing : MonoBehaviour
{
    [SerializeField] GameObject followThing;
    // Update is called once per frame
    void Update()
    {
        transform.position = followThing.transform.position + new Vector3(0, 0, -10);
    }
}
