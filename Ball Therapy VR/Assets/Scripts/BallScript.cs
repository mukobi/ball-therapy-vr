using UnityEngine;

public class BallScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject explosionPrefab;

    private PathScript pathScript;
    private PathManager pathManager;

    private void Start()
    {
        pathScript = gameObject.GetComponentInParent<PathScript>();
        pathManager = gameObject.GetComponentInParent<PathManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        string triggerTag = gameObject.GetComponentInParent<PathScript>().isLeft ? "Left Controller" : "Right Controller";
        // Debug.Log("Look for " + triggerTag + ", found " + other.tag);
        if (other.tag == triggerTag && transform.GetSiblingIndex() == 0) 
        {
            pathScript.FirstBallHit = true;
            pathManager.CheckSyncedPathTrigger();
        }
    }

    public void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
