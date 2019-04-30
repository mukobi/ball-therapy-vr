using UnityEngine;

public class PathScript : MonoBehaviour
{
    private float timeLastBall = 0.0f;
    public Material matOn;
    public Material matOff;
    public bool isLeft = false;
    public GameObject explosionPrefab;
    public bool FirstBallHit { get; set; } = false;

    private readonly float hapticMaxAmp = 1;
    private readonly int numVisibleOrbs = 5;
    private Haptics haptics;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTransf = transform.GetChild(i);
            childTransf.gameObject.SetActive(false);
            childTransf.gameObject.GetComponent<Renderer>().material = matOff;
            childTransf.gameObject.GetComponent<BallScript>().explosionPrefab = explosionPrefab;
            childTransf.position = new Vector3(GameState.armSpan * childTransf.position.x, GameState.armSpan * childTransf.position.y, childTransf.position.z);
        }
        ColorOrbs(0, numVisibleOrbs);
        haptics = FindObjectOfType<Haptics>();
    }

    // triggered by parent PathManager when both paths have been hit
    public void AdvancePath()
    {
        transform.GetChild(0).GetComponent<BallScript>().Explode();
        float diffBallTime = Time.time - timeLastBall;
        timeLastBall = Time.time;
        if(diffBallTime < 1.8f)
        {
            if (isLeft)
                haptics.VibrateLeft(2f, 160, hapticMaxAmp / diffBallTime);
            else
                haptics.VibrateRight(2f, 160, hapticMaxAmp / diffBallTime);
        }
        if (transform.childCount == 1)
        {
            FindObjectOfType<GameManager>().GoToNextLevel();
            return;
        }
        ColorOrbs(1, 1 + numVisibleOrbs);
        FirstBallHit = false;
    }

    private void ColorOrbs(int startIndex, int endIndex)
    {
        transform.GetChild(startIndex).gameObject.GetComponent<Renderer>().material = matOn;
        transform.GetChild(startIndex).gameObject.SetActive(false);
        transform.GetChild(startIndex).gameObject.SetActive(true);
        for (int i = startIndex + 1; i < endIndex; i++)
        {
            if (transform.childCount >= i + 1)
                transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
