using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    
	public void ReactToHit() {
		WanderingAI behaivor = GetComponent<WanderingAI>();
		
		if ( behaivor != null ) {
			behaivor.SetAlive(false);
		}
		
		StartCoroutine(Die());
		
	}
	
	private IEnumerator Die() {
		this.transform.Rotate(-75, 0, 0);
		
		yield return new WaitForSeconds(2.5f);
		
		Destroy(this.gameObject); 
		
	}
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
