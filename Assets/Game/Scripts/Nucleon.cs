using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {

    #region Public Members

    public float AttractionForce;

    #endregion

    #region Private Members

    private Rigidbody body;

    #endregion

    #region Public Methods

    public void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        body.AddForce(transform.localPosition * -AttractionForce);
    }

    #endregion  
}
