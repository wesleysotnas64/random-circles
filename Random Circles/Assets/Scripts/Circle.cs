using UnityEngine;

public class Circle : MonoBehaviour
{
    public Vector2 direction;
    public float velocity;
    public Color color;
    public float bounceDistance;
    public bool ableBounce;
    public float bounceTime;
    public float currentTime;

    public AudioSource audioSource;
    
    private void Start()
    {
        currentTime = 0;
        direction = GenerateDirection();
        color = GenerateColor();
        ableBounce = true;
        GetComponent<SpriteRenderer>().color = color;

        audioSource = GameObject.Find("SceneController").GetComponent<AudioSource>();
        audioSource.Play();
    }

    private void Update()
    {
        transform.Translate(direction * velocity * Time.deltaTime);

        if (IsFarToBounce())
        {
            Bounce();
        }
    }

    public void AbleToBounce()
    {
        if(ableBounce == false)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= bounceTime)
            {
                currentTime = 0;
                ableBounce = true;
            }
        }
    }

    public bool IsFarToBounce()
    {

        if (Vector3.Distance(Vector3.zero, transform.position) >= bounceDistance)
        {
            return true;
        }

        return false;
    }

    public void Bounce()
    {
        Vector3 normal = (Vector3.zero -  transform.position).normalized;
        Vector3 newDirection = CalcReflectVector(normal, direction);
        direction = newDirection;
        ableBounce = false;
        velocity *= 1.05f;
        audioSource.Play();
    }

    Vector3 CalcReflectVector(Vector3 vetorA, Vector3 vetorB)
    {
        vetorA = vetorA.normalized;
        vetorB = vetorB.normalized;

        Vector3 vetorReflexo = vetorB - 2 * Vector3.Dot(vetorB, vetorA) * vetorA;

        return vetorReflexo;
    }

    public Vector2 GenerateDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        float angleInRadians = Mathf.Deg2Rad * randomAngle;
        Vector2 randomVector = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

        return randomVector.normalized;
    }

    public Color GenerateColor()
    {
        float randomRed = Random.value;
        float randomGreen = Random.value;
        float randomBlue = Random.value;

        Color randomColor = new Color(randomRed, randomGreen, randomBlue, 1f);

        return randomColor;
    }
}
