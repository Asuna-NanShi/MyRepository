using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SliceTest : MonoBehaviour
{

    public int scoreValue = 10;
    public GameObject gameController;
    public Material material;

    private void Start()
    {

    }

    public void Slice(GameObject go)
    {
        SlicedHull finalHull = SliceObject(go, material);
        if(finalHull!=null)
        {
            GameObject lowerParent = finalHull.CreateLowerHull(go, material);
            GameObject upperParent = finalHull.CreateUpperHull(go, material);
            lowerParent.AddComponent<Rigidbody>().AddExplosionForce(500, transform.up, 3.0f);
            upperParent.AddComponent<Rigidbody>().AddExplosionForce(500, -transform.up, 3.0f);
            upperParent.AddComponent<MeshCollider>().convex = true;
            lowerParent.AddComponent<MeshCollider>().convex = true;
            go.SetActive(false);
            Destroy(upperParent, 1.0f);
            Destroy(lowerParent, 1.0f);
        }
    }

    public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }

    private void OnTriggerEnter(Collider other)
    {
        Slice(other.gameObject);
        if (other.gameObject.CompareTag("Arrow"))
        {
            gameController.GetComponent<GameController>().AddScore(scoreValue);
        }
    }
}