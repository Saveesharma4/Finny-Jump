using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2.8f;

    [Header("Destroy Settings")]
    [SerializeField] private float destroyPositionX = -35f;

    private void Update()
    {
        MovePipe();
        DestroyPipe();
    }

    private void MovePipe()
    {
        transform.position +=
            Vector3.left * moveSpeed * Time.deltaTime;
    }

    private void DestroyPipe()
    {
        if (transform.position.x < destroyPositionX)
        {
            Destroy(gameObject);
        }
    }
}