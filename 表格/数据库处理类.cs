using Config;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 表格分层;

namespace fangleinew
{
    class 数据库处理类
    {
        string _con = "";
        public 数据库处理类()
        {
            XmlConfig xmlConfig = new XmlConfig(Environment.CurrentDirectory + @"\config\设置.xml");
            _con = xmlConfig.Read("DBConfig", "DB");
        }
        /// <summary>
        /// 判断是否存在指定编号的检测报告
        /// </summary>
        /// <param name="bh">检测报告编号</param>
        /// <returns></returns>
        public bool ExistsZB(string bh)
        {
            try
            {
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = string.Format("SELECT COUNT(*) FROM 检测报告总表 Where 编号='{0}' ", bh);  //SQL查询语句 (Name,StationID,Date)。按照数据库中的表的字段顺序保存
                    SqlCommand sqlman = new SqlCommand(sql, mycon);
                    SqlDataReader sqlreader = sqlman.ExecuteReader();
                    int count = 0;
                    while (sqlreader.Read())
                    {
                        count = sqlreader.GetInt32(0);
                    }
                    if (count > 0)//如果大于0说明存在
                    {
                        return true;
                    }

                    return false;
                }

            }
            catch
            {
                return true;
            }
        }
        public string getPeopleByLB(string LB)
        {
            string PeopleStr = "";
            using (SqlConnection mycon = new SqlConnection(_con))
            {
                mycon.Open();//打开

                string sql = string.Format("select  * from 人员列表  Where 类别 ='{0}' order  BY 编号", LB);  //SQL查询语句 (Name,StationID,Date)。按照数据库中的表的字段顺序保存
                SqlCommand sqlman = new SqlCommand(sql, mycon);
                SqlDataReader sqlreader = sqlman.ExecuteReader();
                while (sqlreader.Read())
                {
                    PeopleStr += sqlreader.GetString(sqlreader.GetOrdinal("姓名")).Trim() + ',';
                }
            }
            if (PeopleStr.Length > 0)
            {
                PeopleStr = PeopleStr.Substring(0, PeopleStr.Length - 1);
            }
                return PeopleStr;
        }
        public bool AddZB(报告总表要素 zbys)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = "insert into 检测报告总表 (编号,检测开始日期,检测结束日期,下次检测日期,受检单位,单位地址,联系部门,负责人,电话,邮编,检测仪器设备) VALUES(@编号,@检测开始日期,@检测结束日期,@下次检测日期,@受检单位,@单位地址,@联系部门,@负责人,@电话,@邮编,@检测仪器设备)";
                    using (SqlCommand sqlman = new SqlCommand(sql, mycon))
                    {
                        sqlman.Parameters.AddWithValue("@编号", zbys.编号);
                        sqlman.Parameters.AddWithValue("@检测开始日期", zbys.检测开始日期);
                        sqlman.Parameters.AddWithValue("@检测结束日期", zbys.检测结束日期);
                        sqlman.Parameters.AddWithValue("@下次检测日期", zbys.下次检测日期);
                        sqlman.Parameters.AddWithValue("@受检单位", zbys.受检单位名称);
                        sqlman.Parameters.AddWithValue("@单位地址", zbys.地址);
                        sqlman.Parameters.AddWithValue("@联系部门", zbys.联系部门);
                        sqlman.Parameters.AddWithValue("@负责人", zbys.负责人);
                        sqlman.Parameters.AddWithValue("@电话", zbys.电话);
                        sqlman.Parameters.AddWithValue("@邮编", zbys.邮编);
                        sqlman.Parameters.AddWithValue("@检测仪器设备", zbys.仪器列表);
                        sw.Start();
                        int jlCount = sqlman.ExecuteNonQuery();
                        if (jlCount > 0)
                            return true;
                        return false;
                    }

                      
                  
                }

            }
            catch
            {
                return true;
            }
        }

        public ObservableCollection<检测报告总表类> getZB()
        {
            ObservableCollection<检测报告总表类> zbs = new ObservableCollection<检测报告总表类>();
            using (SqlConnection mycon = new SqlConnection(_con))
            {
                mycon.Open();//打开

                string sql = string.Format("select  * from 检测报告总表");  //SQL查询语句 (Name,StationID,Date)。按照数据库中的表的字段顺序保存
                SqlCommand sqlman = new SqlCommand(sql, mycon);
                SqlDataReader sqlreader = sqlman.ExecuteReader();
                while (sqlreader.Read())
                {
                    zbs.Add(new 检测报告总表类()
                    {
                        CompanyAddress = sqlreader.GetString(sqlreader.GetOrdinal("单位地址")).Trim(),
                        StartDate = sqlreader.GetDateTime(sqlreader.GetOrdinal("检测开始日期")),
                        EndDate = sqlreader.GetDateTime(sqlreader.GetOrdinal("检测结束日期")),
                        NextDate = sqlreader.GetDateTime(sqlreader.GetOrdinal("下次检测日期")),
                        TelephoneNumber = sqlreader.IsDBNull(sqlreader.GetOrdinal("电话")) ? "" : sqlreader.GetString(sqlreader.GetOrdinal("电话")).Trim(),
                        CompanyName = sqlreader.GetString(sqlreader.GetOrdinal("受检单位")).Trim(),
                        ContactDepartment = sqlreader.GetString(sqlreader.GetOrdinal("联系部门")).Trim(),
                        Zbid = sqlreader.GetString(sqlreader.GetOrdinal("编号")).Trim(),
                        ZrPeople = sqlreader.IsDBNull(sqlreader.GetOrdinal("负责人")) ? "" : sqlreader.GetString(sqlreader.GetOrdinal("负责人")).Trim(),
                    });
                }
            }
            return zbs;
        }
    }
}
