using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        string triggerTag = gameObject.GetComponentInParent<PathScript>().isLeft ? "Left Controller" : "Right Controller";
        // Debug.Log("Look for " + triggerTag + ", found " + other.tag);
        if (other.tag == triggerTag && transform.GetSiblingIndex() == 0) 
        {
            gameObject.GetComponentInParent<PathScript>().AdvancePath();
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
