using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Express.Common;
using Express.Model;
namespace Express.BLL {
	 	//Ep_Question
		public partial class Ep_QuestionBLL
	{
   		     
		private readonly Express.DAL.Ep_QuestionDAL dal=new Express.DAL.Ep_QuestionDAL();
		public Ep_QuestionBLL()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int QId)
		{
			return dal.Exists(QId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Express.Model.Ep_Question model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Express.Model.Ep_Question model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int QId)
		{
			
			return dal.Delete(QId);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string QIdlist )
		{
			return dal.DeleteList(QIdlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Express.Model.Ep_Question GetModel(int QId)
		{
			
			return dal.GetModel(QId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Express.Model.Ep_Question GetModelByCache(int QId)
		{
			
			string CacheKey = "Ep_QuestionModel-" + QId;
			object objModel = Express.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(QId);
					if (objModel != null)
					{
						int ModelCache = Express.Common.ConfigHelper.GetConfigInt("ModelCache");
						Express.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Express.Model.Ep_Question)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Express.Model.Ep_Question> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Express.Model.Ep_Question> DataTableToList(DataTable dt)
		{
			List<Express.Model.Ep_Question> modelList = new List<Express.Model.Ep_Question>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Express.Model.Ep_Question model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Express.Model.Ep_Question();					
													if(dt.Rows[n]["QId"].ToString()!="")
				{
					model.QId=int.Parse(dt.Rows[n]["QId"].ToString());
				}
																																				model.QContent= dt.Rows[n]["QContent"].ToString();
																																model.Openid= dt.Rows[n]["Openid"].ToString();
																												if(dt.Rows[n]["QTime"].ToString()!="")
				{
					model.QTime=DateTime.Parse(dt.Rows[n]["QTime"].ToString());
				}
																										
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
#endregion
   
	}
}