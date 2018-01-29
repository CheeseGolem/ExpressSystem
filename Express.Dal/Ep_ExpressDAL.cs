using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
	/// <summary>
	/// 数据访问类:Ep_ExpressDAL
	/// </summary>
	public partial class Ep_ExpressDAL
	{
        public Ep_ExpressDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ep_Express");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Express.Model.Ep_Express model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ep_Express(");
            strSql.Append("ExpressId,UserId,Sender,SendPhone,Status,Remark,ArrivalTime,GetTime,Type,Location)");
            strSql.Append(" values (");
            strSql.Append("@ExpressId,@UserId,@Sender,@SendPhone,@Status,@Remark,@ArrivalTime,@GetTime,@Type,@Location)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ExpressId", SqlDbType.VarChar,36),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@Sender", SqlDbType.NVarChar,20),
                    new SqlParameter("@SendPhone", SqlDbType.VarChar,15),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.VarChar,200),
                    new SqlParameter("@ArrivalTime", SqlDbType.DateTime),
                    new SqlParameter("@GetTime", SqlDbType.DateTime),
                    new SqlParameter("@Type", SqlDbType.Int,4),
                    new SqlParameter("@Location", SqlDbType.VarChar,20)};
            parameters[0].Value = model.ExpressId;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.Sender;
            parameters[3].Value = model.SendPhone;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.ArrivalTime;
            parameters[7].Value = model.GetTime;
            parameters[8].Value = model.Type;
            parameters[9].Value = model.Location;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Express.Model.Ep_Express model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ep_Express set ");
            strSql.Append("ExpressId=@ExpressId,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("Sender=@Sender,");
            strSql.Append("SendPhone=@SendPhone,");
            strSql.Append("Status=@Status,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("ArrivalTime=@ArrivalTime,");
            strSql.Append("GetTime=@GetTime,");
            strSql.Append("Type=@Type,");
            strSql.Append("Location=@Location");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ExpressId", SqlDbType.VarChar,36),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@Sender", SqlDbType.NVarChar,20),
                    new SqlParameter("@SendPhone", SqlDbType.VarChar,15),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.VarChar,200),
                    new SqlParameter("@ArrivalTime", SqlDbType.DateTime),
                    new SqlParameter("@GetTime", SqlDbType.DateTime),
                    new SqlParameter("@Type", SqlDbType.Int,4),
                    new SqlParameter("@Location", SqlDbType.VarChar,20),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ExpressId;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.Sender;
            parameters[3].Value = model.SendPhone;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.ArrivalTime;
            parameters[7].Value = model.GetTime;
            parameters[8].Value = model.Type;
            parameters[9].Value = model.Location;
            parameters[10].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ep_Express ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ep_Express ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Express.Model.Ep_Express GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ExpressId,UserId,Sender,SendPhone,Status,Remark,ArrivalTime,GetTime,Type,Location from Ep_Express ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            Express.Model.Ep_Express model = new Express.Model.Ep_Express();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Express.Model.Ep_Express DataRowToModel(DataRow row)
        {
            Express.Model.Ep_Express model = new Express.Model.Ep_Express();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ExpressId"] != null)
                {
                    model.ExpressId = row["ExpressId"].ToString();
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Sender"] != null)
                {
                    model.Sender = row["Sender"].ToString();
                }
                if (row["SendPhone"] != null)
                {
                    model.SendPhone = row["SendPhone"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["ArrivalTime"] != null && row["ArrivalTime"].ToString() != "")
                {
                    model.ArrivalTime = DateTime.Parse(row["ArrivalTime"].ToString());
                }
                if (row["GetTime"] != null && row["GetTime"].ToString() != "")
                {
                    model.GetTime = DateTime.Parse(row["GetTime"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["Location"] != null)
                {
                    model.Location = row["Location"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ExpressId,UserId,Sender,SendPhone,Status,Remark,ArrivalTime,GetTime,Type,Location ");
            strSql.Append(" FROM Ep_Express ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,ExpressId,UserId,Sender,SendPhone,Status,Remark,ArrivalTime,GetTime,Type,Location ");
            strSql.Append(" FROM Ep_Express ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Ep_Express ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from Ep_Express T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Ep_Express";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod        

        /// <summary>
        /// 生成SqlParameter对象
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private SqlParameter CreateSqlParameter(string fields, Model.Ep_Express model)
        {
            //通过反射获取指定属性的值
            Type type = model.GetType();
            System.Reflection.PropertyInfo pi = type.GetProperty(fields);//获取指定的属性
            if (pi == null)
            {
                throw new Exception("没有找到指定的属性" + fields);//抛异常
            }
            object value = pi.GetValue(model, null);//获取属性值

            return new SqlParameter("@" + fields, value);
        }

        /// <summary>
        /// 更新指定列
        /// </summary>
        /// <param name="model">News对象</param>
        /// <param name="fields">列数组</param>
        /// <param name="where">where条件</param>
        /// <returns></returns>
        public int Update(Express.Model.Ep_Express model, string[] fields, string where)
        {
            if (fields == null || fields.Length <= 0)
            {
                return 0;
            }

            SqlParameter[] ps = new SqlParameter[fields.Length];

            //"a"+"b"+"c"+"d" //每次拼接都会产生一个新的字符串对象
            //StringBuilder只有一个对象
            StringBuilder sb = new StringBuilder();
            sb.Append("update Ep_Express set ");

            for (int i = 0; i < fields.Length; i++)
            {
                sb.AppendFormat("{0}=@{0}{1}", fields[i], (i != fields.Length - 1 ? "," : ""));//最后一位去掉逗号

                ps[i] = this.CreateSqlParameter(fields[i], model);//生成SqlParameter对象
            }

            sb.Append(" where " + where);

            return DbHelperSQL.ExecuteSql(sb.ToString(), ps);
        }


        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListEpUser(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();            
            strSql.Append("select ID,ExpressId,Ep_User.UserId,Sender,SendPhone,Status,Ep_User.Remark,ArrivalTime,GetTime,Type,Location ");
            strSql.Append(" from Ep_Express,Ep_User ");            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where Ep_Express.UserId=Ep_User.UserId " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}

