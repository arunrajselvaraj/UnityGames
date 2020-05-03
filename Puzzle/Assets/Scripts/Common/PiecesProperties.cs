using UnityEngine;
using System.Collections;

public class PiecesProperties : MonoBehaviour 
{
	private BoxCollider2D m_Collider ;
	private SpriteRenderer m_renderer ;
	void Awake () 
	{
		m_Collider = this.gameObject.GetComponent<BoxCollider2D> () ;
		m_renderer = this.gameObject.GetComponent<SpriteRenderer> () ;
	}
	
	public void PiecesIO ( bool state_ )
	{
		m_Collider.enabled = state_ ;
	}
	
	public void PiecesVisiblity ( bool state_ )
	{
		//Log.InConsole( " PiecesVisiblity SET to " + this.gameObject.name + state_.ToString () , Log.E_Level.E_High ) ;
		m_renderer.enabled = state_ ;
	}
	
	
}
