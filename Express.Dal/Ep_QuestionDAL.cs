using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Express.DBUtility;
namespace Express.DAL  
{
	 	//Ep_Question
		public partial class Ep_QuestionDAL
	{
   		     
		public bool Exists(int QId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ep_Question");
			strSql.Append(" where ");
			                                       strSql.Append(" QId = @QId  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@QId", SqlDbType.Int,4)
			};
			parameters[0].Value = QId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Express.Model.Ep_Question model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ep_Question(");			
            strSql.Append("QContent,Openid,QTime");
			strSql.Append(") values (");
            strSql.Append("@QContent,@Openid,@QTime");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@QContent", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@Openid", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@QTime", SqlDbType.DateTime)             
              
            };
			            
            parameters[0].Value = model.QContent;                        
            parameters[1].Value = model.Openid;                        
            parameters[2].Value = model.QTime;                        
			   
			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);			
			if (obj == null)
			{
				return 0;
			}
			else
			{
				                    
            	return Convert.ToInt32(obj);
                                                                  
			}			   
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Express.Model.Ep_Question model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ep_Question set ");
			                                                
            strSql.Append(" QContent = @QContent , ");                                    
            strSql.Append(" Openid = @Openid , ");                                    
            strSql.Append(" QTime = @QTime  ");            			
			strSql.Append(" where QId=@QId ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@QId", SqlDbType.Int,4) ,            
                        new SqlParameter("@QContent", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@Openid", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@QTime", SqlDbType.DateTime)             
              
            };
						            
            parameters[0].Value = model.QId;                        
            parameters[1].Value = model.QContent;                        
            parameters[2].Value = model.Openid;                        
            parameters[3].Value = model.QTime;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int QId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ep_Question ");
			strSql.Append(" where QId=@QId");
						SqlParameter[] parameters = {
					new SqlParameter("@QId", SqlDbType.Int,4)
			};
			parameters[0].Value = QId;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string QIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ep_Question ");
			strSql.Append(" where ID in ("+QIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Express.Model.Ep_Question GetModel(int QId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select QId, QContent, Openid, QTime  ");			
			strSql.Append("  from Ep_Question ");
			strSql.Append(" where QId=@QId");
						SqlParameter[] parameters = {
					new SqlParameter("@QId", SqlDbType.Int,4)
			};
			parameters[0].Value = QId;

			
			Express.Model.Ep_Question model=new Express.Model.Ep_Question();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["QId"].ToString()!="")
				{
					model.QId=int.Parse(ds.Tables[0].Rows[0]["QId"].ToString());
				}
																																				model.QContent= ds.Tables[0].Rows[0]["QContent"].ToString();
																																model.Openid= ds.Tables[0].Rows[0]["Openid"].ToString();
																												if(ds.Tables[0].Rows[0]["QTime"].ToString()!="")
				{
					model.QTime=DateTime.Parse(ds.Tables[0].Rows[0]["QTime"].ToString());
				}
																														
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM Ep_Question ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM Ep_Question ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

