using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Model
{
    /// <summary>
	/// Ep_Shelf:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class Ep_Shelf
    {
        public Ep_Shelf()
        { }
        #region Model
        private int _sid;
        private string _shelf;
        private string _location;
        private int? _type;
        private string _remark;
        private DateTime? _createtime;
        private DateTime? _updatetime;
        /// <summary>
        /// 
        /// </summary>
        public int SId
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shelf
        {
            set { _shelf = value; }
            get { return _shelf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Location
        {
            set { _location = value; }
            get { return _location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
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
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model

    }
}
