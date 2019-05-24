using Config;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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


        /// <summary>
        /// 判断是否存在指定编号的建筑物表续
        /// </summary>
        /// <param name="bh">检测报告编号</param>
        /// <returns></returns>
        public bool ExistsJZWBX(string bh)
        {
            try
            {
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = string.Format("SELECT COUNT(*) FROM 建筑物防雷装置检测表续 Where 编号='{0}' ", bh);  //SQL查询语句 (Name,StationID,Date)。按照数据库中的表的字段顺序保存
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

        /// <summary>
        /// 判断是否存在指定编号的SPD检测表
        /// </summary>
        /// <param name="bh">SPD编号</param>
        /// <returns></returns>
        public bool ExistsSPD(string bh)
        {
            try
            {
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = string.Format("SELECT COUNT(*) FROM SPD检测表 Where 编号='{0}' ", bh);  //SQL查询语句 (Name,StationID,Date)。按照数据库中的表的字段顺序保存
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

        public bool AddJZWBX(建筑物防雷装置表续要素 bxys)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = "insert into 建筑物防雷装置检测表续 (编号,金属门窗检测点数,金属门窗过渡电阻,金属门窗单项评价,外墙大型金属物检测点数,外墙大型金属物过渡电阻,外墙大型金属物单项评价,金属框架检测点数,金属框架过渡电阻,金属框架单项评价,接地装置形式,接地方式,接地装置检测点数,接地装置接地电阻,接地装置单项评价,室内大型设备名称1,室内大型设备电阻1,室内大型设备名称2,室内大型设备电阻2,室内大型设备名称3,室内大型设备电阻3,室内大型设备名称4,室内大型设备电阻4,室内大型设备名称5,室内大型设备电阻5,室内大型设备名称6,室内大型设备电阻6,室内大型设备名称7,室内大型设备电阻7,室内大型设备名称8,室内大型设备电阻8,室内大型设备名称9,室内大型设备电阻9,室内大型设备名称10,室内大型设备电阻10,室内大型设备名称11,室内大型设备电阻11,入户管线名称1,入户管线电阻1,入户管线名称2,入户管线电阻2,入户管线名称3,入户管线电阻3,入户管线名称4,入户管线电阻4,入户管线名称5,入户管线电阻5,入户管线名称6,入户管线电阻6,入户管线名称7,入户管线电阻7,入户管线名称8,入户管线电阻8,入户管线名称9,入户管线电阻9,入户管线名称10,入户管线电阻10,入户管线名称11,入户管线电阻11,竖向管井内管线名称1,竖向管井内管线电阻1,竖向管井内管线名称2,竖向管井内管线电阻2,竖向管井内管线名称3,竖向管井内管线电阻3,竖向管井内管线名称4,竖向管井内管线电阻4,竖向管井内管线名称5,竖向管井内管线电阻5,竖向管井内管线名称6,竖向管井内管线电阻6,竖向管井内管线名称7,竖向管井内管线电阻7,竖向管井内管线名称8,竖向管井内管线电阻8,竖向管井内管线名称9,竖向管井内管线电阻9,竖向管井内管线名称10,竖向管井内管线电阻10,竖向管井内管线名称11,竖向管井内管线电阻11,主要检测仪器,技术评定,检测员,校核人,技术负责人) VALUES(@编号,@金属门窗检测点数,@金属门窗过渡电阻,@金属门窗单项评价,@外墙大型金属物检测点数,@外墙大型金属物过渡电阻,@外墙大型金属物单项评价,@金属框架检测点数,@金属框架过渡电阻,@金属框架单项评价,@接地装置形式,@接地方式,@接地装置检测点数,@接地装置接地电阻,@接地装置单项评价,@室内大型设备名称1,@室内大型设备电阻1,@室内大型设备名称2,@室内大型设备电阻2,@室内大型设备名称3,@室内大型设备电阻3,@室内大型设备名称4,@室内大型设备电阻4,@室内大型设备名称5,@室内大型设备电阻5,@室内大型设备名称6,@室内大型设备电阻6,@室内大型设备名称7,@室内大型设备电阻7,@室内大型设备名称8,@室内大型设备电阻8,@室内大型设备名称9,@室内大型设备电阻9,@室内大型设备名称10,@室内大型设备电阻10,@室内大型设备名称11,@室内大型设备电阻11,@入户管线名称1,@入户管线电阻1,@入户管线名称2,@入户管线电阻2,@入户管线名称3,@入户管线电阻3,@入户管线名称4,@入户管线电阻4,@入户管线名称5,@入户管线电阻5,@入户管线名称6,@入户管线电阻6,@入户管线名称7,@入户管线电阻7,@入户管线名称8,@入户管线电阻8,@入户管线名称9,@入户管线电阻9,@入户管线名称10,@入户管线电阻10,@入户管线名称11,@入户管线电阻11,@竖向管井内管线名称1,@竖向管井内管线电阻1,@竖向管井内管线名称2,@竖向管井内管线电阻2,@竖向管井内管线名称3,@竖向管井内管线电阻3,@竖向管井内管线名称4,@竖向管井内管线电阻4,@竖向管井内管线名称5,@竖向管井内管线电阻5,@竖向管井内管线名称6,@竖向管井内管线电阻6,@竖向管井内管线名称7,@竖向管井内管线电阻7,@竖向管井内管线名称8,@竖向管井内管线电阻8,@竖向管井内管线名称9,@竖向管井内管线电阻9,@竖向管井内管线名称10,@竖向管井内管线电阻10,@竖向管井内管线名称11,@竖向管井内管线电阻11,@主要检测仪器,@技术评定,@检测员,@校核人,@技术负责人)";
                    using (SqlCommand sqlman = new SqlCommand(sql, mycon))
                    {
                        Type t = bxys.GetType();
                        PropertyInfo[] PropertyList = t.GetProperties();
                        foreach (PropertyInfo item in PropertyList)
                        {
                            try
                            {
                                if (!(item.Name.Contains("Error") || item.Name.Contains("Item")))
                                {
                                    
                                    string name = item.Name;
                                    sqlman.Parameters.AddWithValue($"@{name}", item.GetValue(bxys, null));
                                }
                            }
                            catch(Exception ex)
                            {
                            }
                        }


                        

                        sw.Start();
                        int jlCount = sqlman.ExecuteNonQuery();
                        if (jlCount > 0)
                            return true;
                        return false;
                    }



                }

            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool AddSPD(SPD要素 bxys)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = "insert into SPD检测表 (编号,第一级编号,第一级安装位置,第一级产品型号,第一级安装数量,第一级Uc标称值,第一级检查电流,第一级Up检查值,第一级脱离器检查,第一级Iie测试值L1,第一级Iie测试值L2,第一级Iie测试值L3,第一级Iie测试值N,第一级Uima测试值L1,第一级Uima测试值L2,第一级Uima测试值L3,第一级Uima测试值N,第一级状态指示器,第一级引线长度,第一级连线色标,第一级连线截面,第一级过渡电阻,第一级过流保护,第二级编号,第二级安装位置,第二级产品型号,第二级安装数量,第二级Uc标称值,第二级检查电流,第二级Up检查值,第二级脱离器检查,第二级Iie测试值L1,第二级Iie测试值L2,第二级Iie测试值L3,第二级Iie测试值N,第二级Uima测试值L1,第二级Uima测试值L2,第二级Uima测试值L3,第二级Uima测试值N,第二级状态指示器,第二级引线长度,第二级连线色标,第二级连线截面,第二级过渡电阻,第二级过流保护,第三级编号,第三级安装位置,第三级产品型号,第三级安装数量,第三级Uc标称值,第三级检查电流,第三级Up检查值,第三级脱离器检查,第三级Iie测试值L1,第三级Iie测试值L2,第三级Iie测试值L3,第三级Iie测试值N,第三级Uima测试值L1,第三级Uima测试值L2,第三级Uima测试值L3,第三级Uima测试值N,第三级状态指示器,第三级引线长度,第三级连线色标,第三级连线截面,第三级过渡电阻,第三级过流保护,SPD检测综评,检测员,校核人,技术负责人,日期) VALUES(@编号,@第一级编号,@第一级安装位置,@第一级产品型号,@第一级安装数量,@第一级Uc标称值,@第一级检查电流,@第一级Up检查值,@第一级脱离器检查,@第一级Iie测试值L1,@第一级Iie测试值L2,@第一级Iie测试值L3,@第一级Iie测试值N,@第一级Uima测试值L1,@第一级Uima测试值L2,@第一级Uima测试值L3,@第一级Uima测试值N,@第一级状态指示器,@第一级引线长度,@第一级连线色标,@第一级连线截面,@第一级过渡电阻,@第一级过流保护,@第二级编号,@第二级安装位置,@第二级产品型号,@第二级安装数量,@第二级Uc标称值,@第二级检查电流,@第二级Up检查值,@第二级脱离器检查,@第二级Iie测试值L1,@第二级Iie测试值L2,@第二级Iie测试值L3,@第二级Iie测试值N,@第二级Uima测试值L1,@第二级Uima测试值L2,@第二级Uima测试值L3,@第二级Uima测试值N,@第二级状态指示器,@第二级引线长度,@第二级连线色标,@第二级连线截面,@第二级过渡电阻,@第二级过流保护,@第三级编号,@第三级安装位置,@第三级产品型号,@第三级安装数量,@第三级Uc标称值,@第三级检查电流,@第三级Up检查值,@第三级脱离器检查,@第三级Iie测试值L1,@第三级Iie测试值L2,@第三级Iie测试值L3,@第三级Iie测试值N,@第三级Uima测试值L1,@第三级Uima测试值L2,@第三级Uima测试值L3,@第三级Uima测试值N,@第三级状态指示器,@第三级引线长度,@第三级连线色标,@第三级连线截面,@第三级过渡电阻,@第三级过流保护,@SPD检测综评,@检测员,@校核人,@技术负责人,@日期)";
                    using (SqlCommand sqlman = new SqlCommand(sql, mycon))
                    {
                        Type t = bxys.GetType();
                        PropertyInfo[] PropertyList = t.GetProperties();
                        foreach (PropertyInfo item in PropertyList)
                        {
                            try
                            {
                                if (!(item.Name.Contains("Error") || item.Name.Contains("Item")))
                                {

                                    string name = item.Name;
                                    sqlman.Parameters.AddWithValue($"@{name}", item.GetValue(bxys, null));
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }




                        sw.Start();
                        int jlCount = sqlman.ExecuteNonQuery();
                        if (jlCount > 0)
                            return true;
                        return false;
                    }



                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateJZWBX(建筑物防雷装置表续要素 bxys)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = "update  建筑物防雷装置检测表续 set (金属门窗检测点数,金属门窗过渡电阻,金属门窗单项评价,外墙大型金属物检测点数,外墙大型金属物过渡电阻,外墙大型金属物单项评价,金属框架检测点数,金属框架过渡电阻,金属框架单项评价,接地装置形式,接地方式,接地装置检测点数,接地装置接地电阻,接地装置单项评价,室内大型设备名称1,室内大型设备电阻1,室内大型设备名称2,室内大型设备电阻2,室内大型设备名称3,室内大型设备电阻3,室内大型设备名称4,室内大型设备电阻4,室内大型设备名称5,室内大型设备电阻5,室内大型设备名称6,室内大型设备电阻6,室内大型设备名称7,室内大型设备电阻7,室内大型设备名称8,室内大型设备电阻8,室内大型设备名称9,室内大型设备电阻9,室内大型设备名称10,室内大型设备电阻10,室内大型设备名称11,室内大型设备电阻11,入户管线名称1,入户管线电阻1,入户管线名称2,入户管线电阻2,入户管线名称3,入户管线电阻3,入户管线名称4,入户管线电阻4,入户管线名称5,入户管线电阻5,入户管线名称6,入户管线电阻6,入户管线名称7,入户管线电阻7,入户管线名称8,入户管线电阻8,入户管线名称9,入户管线电阻9,入户管线名称10,入户管线电阻10,入户管线名称11,入户管线电阻11,竖向管井内管线名称1,竖向管井内管线电阻1,竖向管井内管线名称2,竖向管井内管线电阻2,竖向管井内管线名称3,竖向管井内管线电阻3,竖向管井内管线名称4,竖向管井内管线电阻4,竖向管井内管线名称5,竖向管井内管线电阻5,竖向管井内管线名称6,竖向管井内管线电阻6,竖向管井内管线名称7,竖向管井内管线电阻7,竖向管井内管线名称8,竖向管井内管线电阻8,竖向管井内管线名称9,竖向管井内管线电阻9,竖向管井内管线名称10,竖向管井内管线电阻10,竖向管井内管线名称11,竖向管井内管线电阻11,主要检测仪器,技术评定,检测员,校核人,技术负责人) = (select @金属门窗检测点数,@金属门窗过渡电阻,@金属门窗单项评价,@外墙大型金属物检测点数,@外墙大型金属物过渡电阻,@外墙大型金属物单项评价,@金属框架检测点数,@金属框架过渡电阻,@金属框架单项评价,@接地装置形式,@接地方式,@接地装置检测点数,@接地装置接地电阻,@接地装置单项评价,@室内大型设备名称1,@室内大型设备电阻1,@室内大型设备名称2,@室内大型设备电阻2,@室内大型设备名称3,@室内大型设备电阻3,@室内大型设备名称4,@室内大型设备电阻4,@室内大型设备名称5,@室内大型设备电阻5,@室内大型设备名称6,@室内大型设备电阻6,@室内大型设备名称7,@室内大型设备电阻7,@室内大型设备名称8,@室内大型设备电阻8,@室内大型设备名称9,@室内大型设备电阻9,@室内大型设备名称10,@室内大型设备电阻10,@室内大型设备名称11,@室内大型设备电阻11,@入户管线名称1,@入户管线电阻1,@入户管线名称2,@入户管线电阻2,@入户管线名称3,@入户管线电阻3,@入户管线名称4,@入户管线电阻4,@入户管线名称5,@入户管线电阻5,@入户管线名称6,@入户管线电阻6,@入户管线名称7,@入户管线电阻7,@入户管线名称8,@入户管线电阻8,@入户管线名称9,@入户管线电阻9,@入户管线名称10,@入户管线电阻10,@入户管线名称11,@入户管线电阻11,@竖向管井内管线名称1,@竖向管井内管线电阻1,@竖向管井内管线名称2,@竖向管井内管线电阻2,@竖向管井内管线名称3,@竖向管井内管线电阻3,@竖向管井内管线名称4,@竖向管井内管线电阻4,@竖向管井内管线名称5,@竖向管井内管线电阻5,@竖向管井内管线名称6,@竖向管井内管线电阻6,@竖向管井内管线名称7,@竖向管井内管线电阻7,@竖向管井内管线名称8,@竖向管井内管线电阻8,@竖向管井内管线名称9,@竖向管井内管线电阻9,@竖向管井内管线名称10,@竖向管井内管线电阻10,@竖向管井内管线名称11,@竖向管井内管线电阻11,@主要检测仪器,@技术评定,@检测员,@校核人,@技术负责人) where 编号=@编号";
                    string sql2 = "";
                    Type t = bxys.GetType();
                    PropertyInfo[] PropertyList = t.GetProperties();
                    foreach (PropertyInfo item in PropertyList)
                    {
                        try
                        {
                            if (!(item.Name.Contains("Error") || item.Name.Contains("Item") || item.Name=="编号"))
                            {
                                sql2 += item.Name + "=@" + item.Name+",";
                               
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if(sql2.Length>0)
                    {
                        sql2 = sql2.Substring(0, sql2.Length - 1);
                        sql = "update  建筑物防雷装置检测表续 set " + sql2 + " where 编号=@编号";
                        using (SqlCommand sqlman = new SqlCommand(sql, mycon))
                        {

                            foreach (PropertyInfo item in PropertyList)
                            {
                                try
                                {
                                    if (!(item.Name.Contains("Error") || item.Name.Contains("Item")))
                                    {

                                        string name = item.Name;
                                        sqlman.Parameters.AddWithValue($"@{name}", item.GetValue(bxys, null));
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }




                            sw.Start();
                            int jlCount = sqlman.ExecuteNonQuery();
                            if (jlCount > 0)
                                return true;
                            return false;
                        }
                    }
                   



                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public bool UpdateSPD(SPD要素 bxys)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql;
                    string sql2 = "";
                    Type t = bxys.GetType();
                    PropertyInfo[] PropertyList = t.GetProperties();
                    foreach (PropertyInfo item in PropertyList)
                    {
                        try
                        {
                            if (!(item.Name.Contains("Error") || item.Name.Contains("Item") || item.Name == "编号"))
                            {
                                sql2 += item.Name + "=@" + item.Name + ",";

                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (sql2.Length > 0)
                    {
                        sql2 = sql2.Substring(0, sql2.Length - 1);
                        sql = "update  SPD检测表 set " + sql2 + " where 编号=@编号";
                        using (SqlCommand sqlman = new SqlCommand(sql, mycon))
                        {

                            foreach (PropertyInfo item in PropertyList)
                            {
                                try
                                {
                                    if (!(item.Name.Contains("Error") || item.Name.Contains("Item")))
                                    {

                                        string name = item.Name;
                                        sqlman.Parameters.AddWithValue($"@{name}", item.GetValue(bxys, null));
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }




                            sw.Start();
                            int jlCount = sqlman.ExecuteNonQuery();
                            if (jlCount > 0)
                                return true;
                            return false;
                        }
                    }




                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public 建筑物防雷装置表续要素 GetJZWBXbyBh(string BH)
        {
            建筑物防雷装置表续要素 xbys = new 建筑物防雷装置表续要素();
            try
            {
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = $"select  * from 建筑物防雷装置检测表续 where 编号='{BH}'";
                    SqlDataAdapter ada = new SqlDataAdapter(sql, _con);
                    DataTable dtbl = new DataTable();
                    ada.Fill(dtbl);
                    foreach (DataColumn item in dtbl.Columns)
                    {
                        Type t = xbys.GetType();
                        PropertyInfo[] PropertyList = t.GetProperties();
                        foreach (PropertyInfo itemP in PropertyList)
                        {
                            if(itemP.Name== item.ColumnName)
                            {
                                itemP.SetValue(xbys, dtbl.Rows[0][item]);
                            }
                        }
                        

                    }
                }

            }
            catch (Exception ex)
            {
                
            }
            return xbys;
        }

        public SPD要素 GetSPDbyBh(string BH)
        {
            SPD要素 xbys = new SPD要素();
            try
            {
                using (SqlConnection mycon = new SqlConnection(_con))
                {
                    mycon.Open();//打开
                    string sql = $"select  * from SPD检测表 where 编号='{BH}'";
                    SqlDataAdapter ada = new SqlDataAdapter(sql, _con);
                    DataTable dtbl = new DataTable();
                    ada.Fill(dtbl);
                    foreach (DataColumn item in dtbl.Columns)
                    {
                        Type t = xbys.GetType();
                        PropertyInfo[] PropertyList = t.GetProperties();
                        foreach (PropertyInfo itemP in PropertyList)
                        {
                            if (itemP.Name == item.ColumnName)
                            {
                                itemP.SetValue(xbys, dtbl.Rows[0][item]);
                            }
                        }


                    }
                }

            }
            catch (Exception ex)
            {

            }
            return xbys;
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
        public static void ForeachClassProperties<T>(T model)
        {
            Type t = model.GetType();
            PropertyInfo[] PropertyList = t.GetProperties();
            foreach (PropertyInfo item in PropertyList)
            {
                string name = item.Name;
                object value = item.GetValue(model, null);
            }
        }

    }
}
