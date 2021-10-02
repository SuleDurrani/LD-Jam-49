using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageController : MonoBehaviour
{
    private const float chargeRate = 0.04f;
    private const float drainRate = 0.2f;

    private const int MinRage = 25;
    private float _rage;
    private float rage {
        get { return _rage; }
        set {
            _rage = value;
            bar.sizeDelta = new Vector2(200 * (_rage/max), 20);
            icon.sprite = _rage > 75 || _isRaging ? sprite3 :
                _rage > 50 ? sprite2 :
                _rage > 25 ? sprite1 :
                null;
        }
    }

    public float startRage;
    public float max;

    public Image icon;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    

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
            rage += chargeRate;
            if (rage > max) rage = max;
        } else {
            rage -= drainRate;
            if (rage < 0) {
                rage = 0;
                _isRaging = false;
            } 
        }
    }
}
