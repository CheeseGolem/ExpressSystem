using System;
namespace Express.Model
{
    /// <summary>
    /// VirtualExpress:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class VirtualExpress
    {
        public VirtualExpress()
        { }
        #region Model
        private int _id;
        private string _expresscode;
        private string _receivedname;
        private string _receivedphone;
        private string _sendname;
        private string _sendphone;
        private string _address;
        private string _info;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExpressCode
        {
            set { _expresscode = value; }
            get { return _expresscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReceivedName
        {
            set { _receivedname = value; }
            get { return _receivedname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReceivedPhone
        {
            set { _receivedphone = value; }
            get { return _receivedphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SendName
        {
            set { _sendname = value; }
            get { return _sendname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SendPhone
        {
            set { _sendphone = value; }
            get { return _sendphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Info
        {
            set { _info = value; }
            get { return _info; }
        }
        #endregion Model

    }
}

