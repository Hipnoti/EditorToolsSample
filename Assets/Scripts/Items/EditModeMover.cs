using UnityEngine;

[ExecuteAlways]
public class EditModeMover : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
