using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Express.Model{
	 	//Ep_Question
		public class Ep_Question
	{
   		     
      	/// <summary>
		/// QId
        /// </summary>		
		private int _qid;
        public int QId
        {
            get{ return _qid; }
            set{ _qid = value; }
        }        
		/// <summary>
		/// QContent
        /// </summary>		
		private string _qcontent;
        public string QContent
        {
            get{ return _qcontent; }
            set{ _qcontent = value; }
        }        
		/// <summary>
		/// Openid
        /// </summary>		
		private string _openid;
        public string Openid
        {
            get{ return _openid; }
            set{ _openid = value; }
        }        
		/// <summary>
		/// QTime
        /// </summary>		
		private DateTime _qtime;
        public DateTime QTime
        {
            get{ return _qtime; }
            set{ _qtime = value; }
        }        
		   
	}
}

