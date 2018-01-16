using System;
namespace Express.Model
{
	/// <summary>
	/// 用户信息
	/// </summary>
	[Serializable]
	public partial class Ep_User
	{
		public Ep_User()
		{}
		#region Model
		private string _userid;
		private string _name;
		private string _phone;
		private string _address;
		private string _wechatid;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WechatId
		{
			set{ _wechatid=value;}
			get{return _wechatid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

