using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBird : Bird
{[SerializeField]
    public bool _hasBlow;
    private Vector3 scaleChange;
    public void Blow()
    {
        if (State == BirdState.HitSomething || !_hasBlow)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
           StartCoroutine(ScaleUp());
            _hasBlow = true;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Blow();
        
    }
    public IEnumerator ScaleUp()
    {
        scaleChange = new Vector3(0.02f, 0.02f,0.02f);
        for (int i = 0; i <= 20; i++)
        {
            gameObject.transform.localScale += scaleChange;
            yield return new WaitForSeconds(0.1f);
            //scaleChange = -scaleChange;
        }
            
    }
}
