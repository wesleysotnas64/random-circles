using UnityEngine;

public class SceneController : MonoBehaviour
{

    public GameObject circleObject;
    public Vector3 mousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetMousePosition();
            if (Vector3.Distance(mousePosition, Vector3.zero) <= 8)
            {
                InstantiateCircle();
            }
        }
    }

    public void InstantiateCircle()
    {
        GameObject c = Instantiate(circleObject);
        c.gameObject.name = "Clone";
        c.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }

    public void GetMousePosition()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;
    }
}
