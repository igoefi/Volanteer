using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PastSpawner : MonoBehaviour
{
    [SerializeField] Transform _player;

    [SerializeField] Past[] _pastPrefs;

    [SerializeField] Past _firstPast;
    private List<Past> _pasts = new();
    
    [SerializeField] float _indentXToNewPast;
    [SerializeField] int _maxSumPlatforms;

    private void Start()
    {
        _pasts.Add(_firstPast);
    }

    private void Update()
    {
        if (_player.position.x + _indentXToNewPast > _pasts[_pasts.Count - 1].GetEndPoint().position.x)
            AddPast();

    }

    private void AddPast()
    {
        GameObject newPast = Instantiate(_pastPrefs[Random.Range(0, _pastPrefs.Length)].gameObject);

        Past pastComponent = newPast.GetComponent<Past>();
        newPast.transform.position = _pasts[^1].GetEndPoint().position 
            - new Vector3(pastComponent.GetBeginPoint().position.x - newPast.transform.position.x, 0);
        _pasts.Add(pastComponent);
        if(_pasts.Count > _maxSumPlatforms)
        {
            Destroy(_pasts[0].gameObject);
            _pasts.RemoveAt(0);
        }
    }

}
