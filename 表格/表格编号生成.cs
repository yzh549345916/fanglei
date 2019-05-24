using Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fangleinew
{
    class 表格编号生成
    {
        string _con = "";
        public 表格编号生成()
        {
            XmlConfig xmlConfig = new XmlConfig(Environment.CurrentDirectory + @"\config\设置.xml");
            _con = xmlConfig.Read("DBConfig", "DB");

        }
        public string 获取总表最新编号()
        {
            try
            {
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = string.Format("select top 1 * from 检测报告总表  Where 检测开始日期>='{0}' and 检测开始日期<='{1}' order  BY 编号 DESC", DateTime.Now.Year + "-01-01", DateTime.Now.ToString("yyyy-MM-dd"));  //SQL查询语句 (Name,StationID,Date)。按照数据库中的表的字段顺序保存
                    SqlCommand sqlman = new SqlCommand(sql, mycon);
                    SqlDataReader sqlreader = sqlman.ExecuteReader();
                    string bhls = "";
                    while (sqlreader.Read())
                    {
                        bhls = sqlreader.GetString(sqlreader.GetOrdinal("编号")).Trim();
                    }
                    if (bhls.Length == 0)//如果当年不存在检测报告，新建第一个
                    {
                        return "HSFL-" + DateTime.Now.ToString("yy") + "-0001-XXXX";
                    }
                    else
                    {
                        int countls = 1;
                        try
                        {
                            countls = Convert.ToInt32(bhls.Split('-')[2].Trim());
                        }
                        catch
                        {
                        }
                        countls++;
                        return "HSFL-" + DateTime.Now.ToString("yy-") + countls.ToString().PadLeft(4,'0')+"-XXXX";
                    }
                }

            }
            catch
            {
                return "HSFL-" + DateTime.Now.ToString("yy") + "-0001-XXXX";
            }
        }

        public string 获取建筑物防雷装置表续最新编号()
        {
            try
            {
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = string.Format("select top 1 * from 建筑物防雷装置检测表续   order  BY 编号 DESC");  //SQL查询语句 (Name,StationID,Date)。按照数据库中的表的字段顺序保存
                    SqlCommand sqlman = new SqlCommand(sql, mycon);
                    SqlDataReader sqlreader = sqlman.ExecuteReader();
                    string bhls = "";
                    while (sqlreader.Read())
                    {
                        bhls = sqlreader.GetString(sqlreader.GetOrdinal("编号")).Trim();
                    }
                    if (bhls.Length == 0)//如果当年不存在检测报告，新建第一个
                    {
                        return "HSFL-JZWBX-" + DateTime.Now.ToString("yyyyMMdd") + "-0001";
                    }

                    try
                    {
                        if (bhls.Split('-')[2] == DateTime.Now.ToString("yyyyMMdd"))
                        {
                            int countls = 1;
                            try
                            {
                                countls = Convert.ToInt32(bhls.Split('-')[3].Trim());
                            }
                            catch
                            {
                            }
                            countls++;
                            return "HSFL-JZWBX-" + DateTime.Now.ToString("yyyyMMdd-") + countls.ToString().PadLeft(4, '0') ;
                        }
                    }
                    catch
                    {
                        return "HSFL-JZWBX-" + DateTime.Now.ToString("yyyyMMdd") + "-0001";
                    }
                }
                return "HSFL-JZWBX-" + DateTime.Now.ToString("yyyyMMdd") + "-0001";
            }
            catch
            {
                return "HSFL-JZWBX-" + DateTime.Now.ToString("yyyyMMdd") + "-0001";
            }
        }

        public string 获取SPD最新编号()
        {
            try
            {
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = string.Format("select top 1 * from SPD检测表 order  BY 编号 DESC");  //SQL查询语句 (Name,StationID,Date)。按照数据库中的表的字段顺序保存
                    SqlCommand sqlman = new SqlCommand(sql, mycon);
                    SqlDataReader sqlreader = sqlman.ExecuteReader();
                    string bhls = "";
                    while (sqlreader.Read())
                    {
                        bhls = sqlreader.GetString(sqlreader.GetOrdinal("编号")).Trim();
                    }
                    if (bhls.Length == 0)//如果当年不存在检测报告，新建第一个
                    {
                        return "HSFL-SPD-" + DateTime.Now.ToString("yyyyMMdd") + "-0001";
                    }

                    try
                    {
                        if (bhls.Split('-')[2] == DateTime.Now.ToString("yyyyMMdd"))
                        {
                            int countls = 1;
                            try
                            {
                                countls = Convert.ToInt32(bhls.Split('-')[3].Trim());
                            }
                            catch
                            {
                            }
                            countls++;
                            return "HSFL-SPD-" + DateTime.Now.ToString("yyyyMMdd-") + countls.ToString().PadLeft(4, '0');
                        }
                    }
                    catch
                    {
                        return "HSFL-SPD-" + DateTime.Now.ToString("yyyyMMdd") + "-0001";
                    }
                }
                return "HSFL-SPD-" + DateTime.Now.ToString("yyyyMMdd") + "-0001";
            }
            catch
            {
                return "HSFL-SPD-" + DateTime.Now.ToString("yyyyMMdd") + "-0001";
            }
        }
    }
}
