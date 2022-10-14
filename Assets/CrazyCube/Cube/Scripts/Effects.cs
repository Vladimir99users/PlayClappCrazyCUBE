using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Effects : MonoBehaviour
{
    [SerializeField]private GameObject _particalSystem;
 
    internal void DestroyAndPlayEffects(MeshRenderer mesh, Transform positionSpawn)
    {
        
        var particalSystem = Instantiate(_particalSystem,positionSpawn.position,_particalSystem.gameObject.transform.rotation) as GameObject;
        var particle = particalSystem.GetComponent<ParticleSystem>();
        var main = particle.main;
        main.startColor = mesh.material.color;
        particle.Play();

        Destroy(particalSystem,main.duration);
    }

}