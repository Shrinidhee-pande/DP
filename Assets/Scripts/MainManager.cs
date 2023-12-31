using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public GameObject GameOverObject;

    private bool m_Started = false;
    public int m_Points { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        BestScoreText.text = "Best Score: Name: " + ScoreManager.Instance.playerName + " : " + ScoreManager.Instance.score;
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        if (m_Points > ScoreManager.Instance.score)
        {
            ScoreManager.Instance.playerName = ScoreManager.Instance.thisPlayer;
            ScoreManager.Instance.score = m_Points;
            BestScoreText.text = "Best Score: Name: " + ScoreManager.Instance.playerName + " : " + ScoreManager.Instance.score;
        }
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        GameOverObject.SetActive(true);
    }
}
