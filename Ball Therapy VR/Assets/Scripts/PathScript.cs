using UnityEngine;

public class PathScript : MonoBehaviour
{
    private float timeLastBall = 0.0f;
    public Material matOn;
    public Material matOff;
    public bool isLeft = false;
    public bool FirstBallHit { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gameObject.name);
        //Debug.Log(transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTransf = transform.GetChild(i);
            childTransf.gameObject.SetActive(false);
            childTransf.gameObject.GetComponent<Renderer>().material = matOff;
            Vector3 scaled = new Vector3(GameState.armSpan * childTransf.position.x, 2 * GameState.armSpan * childTransf.position.y, GameState.armSpan * childTransf.position.z);
            childTransf.position = scaled;
            childTransf.position.Set(scaled.x, scaled.y, scaled.z);
            //Debug.Log(childTransf.position);
        }
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.GetComponent<Renderer>().material = matOn;
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
    }

    // triggered when the next ball in the path to be hit is hit
    public void AdvancePath()
    {
        float diffBallTime = Time.time - timeLastBall;
        timeLastBall = Time.time;
        //Debug.Log("BT: " + diffBallTime);
        if(diffBallTime < 1f)  // too fast
        {
            Haptics haptics = FindObjectOfType<Haptics>();
            if (haptics != null)
            {
                if (isLeft)
                    haptics.VibrateLeft(2f, 160, 1 - diffBallTime);
                else
                    haptics.VibrateRight(2f, 160, 1 - diffBallTime);
            }
        }
        if (transform.childCount == 1)
        {
            FindObjectOfType<GameManager>().GoToNextLevel();
            return;
        }
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        //Debug.Log(transform.childCount);
        if (transform.childCount >= 3)
            transform.GetChild(2).gameObject.SetActive(true);
        if (transform.childCount >= 4)
            transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.GetComponent<Renderer>().material = matOn;

        transform.GetChild(0).GetComponent<BallScript>().Explode();
        FirstBallHit = false;
    }
}
