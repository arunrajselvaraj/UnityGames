using UnityEngine;
using System.Collections;

public class SuffleController : MonoBehaviour 
{
	private int[] m_index = new int[ 16 ]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15  };
	private int[] m_indexRotation = new int[] { 90, 180, 270  } ; 

	public SceneController m_SceneController ;
		
	
	/// <summary>
	/// Suffles the puzzle pieces.
	/// </summary>
	public void SufflePuzzlePieces () 
	{
		int[] suffleIndex_ = suffle( m_index )  ;
		for ( int i = 0 ; i < m_SceneController.m_puzzlePieces.Length ; i++ )	
		{
			m_SceneController.m_puzzlePieces[i].transform.position = m_SceneController.m_puzPos [ suffleIndex_[i] ] ; 
			int rot_ = m_indexRotation [  Random.Range ( 0, 3 ) ] ;
			m_SceneController.m_puzzlePieces[i].transform.rotation = new Quaternion ( 0, 0, rot_, 0) ;
		}
	}
	
	/// <summary>
	/// Suffle the specified.
	/// </summary>
	/// <param name="s">S.</param>
	private int[] suffle(int[] s)
	{
		for(int n = s.Length - 1 ; n > 0; --n)
		{
			//int k = Random.Next( n  - 1);
			int k = Random.Range(0, s.Length );
			int t = s[n];
			s[n] =  s[k];
			s[k] = t;
		}
		return s ;
	}
	
}
