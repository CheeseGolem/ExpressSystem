using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Express.Model{
	 	//Ep_Answer
		public class Ep_Answer
	{
   		     
      	/// <summary>
		/// AId
        /// </summary>		
		private int _aid;
        public int AId
        {
            get{ return _aid; }
            set{ _aid = value; }
        }        
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
		/// AContent
        /// </summary>		
		private string _acontent;
        public string AContent
        {
            get{ return _acontent; }
            set{ _acontent = value; }
        }        
		/// <summary>
		/// ATime
        /// </summary>		
		private DateTime _atime;
        public DateTime ATime
        {
            get{ return _atime; }
            set{ _atime = value; }
        }        
		   
	}
}

