using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject cube;
    float[] z_rotate = { 90.0f, -90.0f, 0.0f, 180.0f };
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameObject go = Instantiate(cube);
        go.transform.position = transform.position;
        go.transform.rotation = Quaternion.Euler(0.0f, 180.0f, z_rotate[Random.Range(0, z_rotate.Length)]);
        go.SetActive(true);
    }
}
