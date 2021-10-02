using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageController : MonoBehaviour
{
    private const int MinRage = 25;
    private float _rage;
    private float rage {
        get { return _rage;}
        set {
            _rage = value;
            bar.sizeDelta = new Vector2(200 * (_rage/max), 20);
        }
    }
    public float startRage;
    public float max;
    public RectTransform bar;
    // Raging can only be started by this class
    private bool _isRaging;
    public void StartRage() {
        if (rage > MinRage) {
            _isRaging = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rage = startRage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) StartRage();

        if (!_isRaging) {
            rage += 0.1f;
            if (rage > max) rage = max;
        } else {
            rage -= 0.5f;
            if (rage < 0) {
                rage = 0;
                _isRaging = false;
            } 
        }
    }
}
