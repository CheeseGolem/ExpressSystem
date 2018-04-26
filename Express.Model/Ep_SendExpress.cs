using System;
namespace Express.Model
{
    /// <summary>
    /// Ep_SendExpress:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Ep_SendExpress
    {
        public Ep_SendExpress()
        { }
        #region Model
        private int _expressid;
        private string _receivename;
        private string _receivephone;
        private string _receiveaddress;
        private int? _senduserid;
        private int? _status;
        private int? _isexpensive;
        private DateTime? _createtime = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int ExpressId
        {
            set { _expressid = value; }
            get { return _expressid; }
        }
        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string ReceiveName
        {
            set { _receivename = value; }
            get { return _receivename; }
        }
        /// <summary>
        /// 收件人手机号
        /// </summary>
        public string ReceivePhone
        {
            set { _receivephone = value; }
            get { return _receivephone; }
        }
        /// <summary>
        /// 收件人地址
        /// </summary>
        public string ReceiveAddress
        {
            set { _receiveaddress = value; }
            get { return _receiveaddress; }
        }
        /// <summary>
        /// 寄件用户ID
        /// </summary>
        public int? SendUserId
        {
            set { _senduserid = value; }
            get { return _senduserid; }
        }
        /// <summary>
        /// 状态 0-未接收 1-已接收 2-已发出
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 是否保价 0-否 1-是
        /// </summary>
        public int? IsExpensive
        {
            set { _isexpensive = value; }
            get { return _isexpensive; }
        }
        /// <summary>
        /// 订单创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}

