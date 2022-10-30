using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PastSpawner : MonoBehaviour
{
    [SerializeField] Transform _player;

    [SerializeField] GameObject[] _pastPrefs;
    [SerializeField] GameObject[] _backBGPrefs;

    [SerializeField] Past _firstPast;
    [SerializeField] Past _firstBackBG;

    private List<Past> _pasts = new();
    private List<Past> _backBG = new();
    
    [SerializeField] float _indentXToNewPast;
    [SerializeField] int _maxSumPlatforms;
     
    private void Start()
    {
        _pasts.Add(_firstPast);
        _backBG.Add(_firstBackBG);
    }

    private void Update()
    {
        if (_player.position.x + _indentXToNewPast > _pasts[_pasts.Count - 1].GetEndPoint().position.x)
            AddPast(_pasts, _pastPrefs);
        if (_player.position.x + _indentXToNewPast > _backBG[_backBG.Count - 1].GetEndPoint().position.x)
            AddPast(_backBG, _backBGPrefs);
    }

    private void AddPast(List<Past> pastList, GameObject[] pastPrefs)
    {
        GameObject newPast = Instantiate(RandomObj(pastPrefs));

        Past pastComponent = newPast.GetComponent<Past>();

        Past lastPast = pastList[^1];

        float distanceX1 = lastPast.GetEndPoint().position.x - lastPast.transform.position.x;
        float distanceX2 = newPast.transform.position.x - pastComponent.GetBeginPoint().position.x;

        newPast.transform.position = lastPast.transform.position + new Vector3(distanceX1 + distanceX2, 0); 
        /*
        newPast.transform.position = pastList[^1].GetEndPoint().position 
            - new Vector3(pastComponent.GetBeginPoint().position.x - newPast.transform.position.x, newPast.transform.position.y);
        */
        pastList.Add(pastComponent);

        
        if (pastList.Count > _maxSumPlatforms)
        {
            Destroy(pastList[0].gameObject);
            pastList.RemoveAt(0);
        }

    }

    private GameObject RandomObj(GameObject[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
