using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]
sealed class Skin : MonoBehaviour
{
    [SerializeField] private Material[] _material;
    internal void NewRandomSkin()
    {
       gameObject.GetComponent<MeshRenderer>().material = _material[Random.Range(0,_material.Length)];
    }

}
