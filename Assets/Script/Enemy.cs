using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObjectPool
{
    [SerializeField] float _speed = 10;
    SpriteRenderer _image;
    Collider2D collider;
    void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (!IsActive) return;

        Vector3 sub = GameManager.Player.transform.position - transform.position;
        sub.Normalize();

        transform.position += sub * _speed * Time.deltaTime;
    }

    public void Damage()
    {
        Destroy();

        //TODO
        GameManager.Instance.GetExperience(1);
    }

    //ObjectPool
    bool _isActrive = false;
    public bool IsActive => _isActrive;
    public void DisactiveForInstantiate()
    {
        _image.enabled = false;
        collider.enabled = false;
        _isActrive = false;
    }
    public void Create()
    {
        _image.enabled = true;
        collider.enabled = true;
        _isActrive = true;
    }
    public void Destroy()
    {
        _image.enabled = false;
        collider.enabled = false;
        _isActrive = false;
    }
}