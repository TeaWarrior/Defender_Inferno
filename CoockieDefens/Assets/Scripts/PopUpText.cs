using TMPro;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    [SerializeField] TextMeshPro textMesh;
    [SerializeField] float flySpeed;
    // Start is called before the first frame update

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
    public void SetDamageText(int damage)
    {
        textMesh.text = damage.ToString();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + flySpeed * Time.deltaTime, transform.position.z);
    }
}
