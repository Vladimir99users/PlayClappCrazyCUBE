using UnityEngine;

sealed class Cube : MonoBehaviour
{
    
    private float _speed;
    private Vector3 _endDot;
    private Skin _RandomSkin => GetComponent<Skin>();

    [SerializeField]private Effects _effects;
    
    [SerializeField] private AudioClip _deathCubeSound;
    [SerializeField] private AudioClip _createCubeSound;

    public void Initialize(float speed,Vector3 endDot)
    {
        _speed = speed;
        _endDot = endDot;
        SoundController.OnEnableSoundEffect?.Invoke(_createCubeSound);
        if(_RandomSkin != null)
        {
            _RandomSkin.NewRandomSkin();
        }
    }
    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position,_endDot) > 0.1f)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position,_endDot,_speed * Time.fixedDeltaTime);
            transform.position = newPosition;
        } else if(Vector3.Distance(transform.position,_endDot) <= 0.1f)
        {
            if(_effects != null)
            {
                AmountCube.OnAmountCube?.Invoke();
                SoundController.OnEnableSoundEffect?.Invoke(_deathCubeSound);
                _effects.DestroyAndPlayEffects(gameObject.GetComponent<MeshRenderer>(),gameObject.transform);
            }

            Destroy(gameObject);
        }
        
    }
}
