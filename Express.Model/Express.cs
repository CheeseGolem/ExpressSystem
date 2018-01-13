using System;
namespace Express.Model
{
    /// <summary>
    /// Express:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Express
    {
        public Express()
        { }
        #region Model
        private string _id;
        private string _expressid;
        private string _userid;
        private string _sender;
        private string _sendphone;
        private int? _status = 0;
        private string _remark;
        private DateTime _arrivaltime;
        private DateTime _gettime;
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExpressId
        {
            set { _expressid = value; }
            get { return _expressid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sender
        {
            set { _sender = value; }
            get { return _sender; }
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
        /// 0-未接收 1-已接收 2-已超期
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ArrivalTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime GetTime { get; set; }
        #endregion Model

    }
}

