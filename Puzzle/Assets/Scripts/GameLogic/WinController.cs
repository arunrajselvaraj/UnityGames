using UnityEngine;
using System.Collections;
using System.Linq ;

public class WinController : MonoBehaviour 
{
	private bool m_isWin = false ;
	public GameObject[] m_TemplatePieces ;
	
	public int[] m_puzzleNo = new int[16] ;
	public int[] m_templateNo = new int[16] ;
	
	public GameManager m_GameManager ;

	void Start () 
	{
		for ( int i = 0 ; i < m_TemplatePieces.Length ; i++ )
		{
			m_templateNo[i] = int.Parse ( m_TemplatePieces[i].GetComponent<IdentifyName>().m_ObjName ) ;
		}
	}
	
	/// <summary>
	/// Check the win condition on Fixed intervals.
	/// </summary>
	
	void FixedUpdate () 
	{
		if( !m_isWin )
		{
			for ( int i = 0 ; i < m_TemplatePieces.Length ; i++ )
			{
				m_puzzleNo[i] =  int.Parse ( m_TemplatePieces[i].GetComponent<IdentifyName>().m_PuzzleName ) ;
			
				if( m_templateNo.SequenceEqual ( m_puzzleNo)  )
				{
					m_isWin = true ;
					m_GameManager.SetGameState ( GameManager.E_GameState.E_StopGame) ;
					BroadcastMessage ( "StopRayCast" ) ;
					
					//for Debug Checking
//					for ( int j = 0 ; j < m_TemplatePieces.Length ; j++ )
//					{
//						Log.InConsole( " WIN CONDITION OF PUZZLE --> !! " + j.ToString () + " -- " +  m_puzzleNo[j].ToString()   , Log.E_Level.E_High ) ;
//					}
					Log.InConsole( " WIN CONDITION SATISFIED !! "  , Log.E_Level.E_High ) ;
				}
			
			}
		}
		
	}
}
