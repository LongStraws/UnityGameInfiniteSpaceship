using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ShadowEffect : MonoBehaviour
{

    public Vector3 offset = new Vector3(-.1f, -.1f);
    Vector3 scaleChange = new Vector3(1f, 1f, 0);
    public Material materialShadow;

    GameObject _Shadow;

    // Start is called before the first frame update
    void Start()
    {
        _Shadow = new GameObject("Shadow");
        _Shadow.transform.parent = transform;

        _Shadow.transform.localPosition = offset;
        _Shadow.transform.localRotation = Quaternion.identity;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer sr = _Shadow.AddComponent<SpriteRenderer>();
        sr.sprite = renderer.sprite;
        sr.material = materialShadow;

        if (renderer.sprite.name == "Coin Art for Game Piskel")
        {
            _Shadow.transform.localScale = scaleChange;
        }

        //Making sure the sortinglayername is the same and that it is rendered behind
        sr.sortingLayerName = renderer.sortingLayerName;
        sr.sortingOrder = renderer.sortingOrder - 1;

    }

    private void Update() {
        if(GetComponentInParent<SpriteRenderer>().enabled == false){
            Destroy(_Shadow);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(_Shadow == null){
            return;
        }
        _Shadow.transform.localPosition = offset;
        _Shadow.transform.eulerAngles = transform.eulerAngles;
    }
}
