using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hubu.sgms.Utils
{
    public class BeanUils
    {
        /// <summary>
        /// 将from中的同名属性赋值到to中
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static int TransFields(Object from,Object to)
        {
            int count = 0;
            Type fromType = from.GetType();
            Type toType = to.GetType();
            PropertyInfo[] fromPropertyInfos = fromType.GetProperties();
            foreach(PropertyInfo propertyInfo in fromPropertyInfos)
            {
                Object valueToSet = propertyInfo.GetValue(from);
                if (valueToSet != null){
                    PropertyInfo toProperty = toType.GetProperty(propertyInfo.Name);
                    if (toProperty != null)
                    {
                        try
                        {
                            toProperty.SetValue(to, valueToSet);
                            count++;
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// 将bean中的同名属性替换到sql中
        /// </summary>
        /// <param name="sqlToSet"></param>
        /// <param name="bean"></param>
        /// <returns></returns>
        public static IList<SqlParameter> SetInSQL(string sqlToSet, Object bean) {
            IList<SqlParameter> sqlParameterList = new List<SqlParameter>();

            string[] paramArray = sqlToSet.Split('@');
            List<string> paramList = new List<string>();
            for(int i = 1; i < paramArray.Length; i++)
            {
                if (paramArray[i].IndexOf(',') != -1 || paramArray[i].IndexOf(')') != -1)
                {
                    paramArray[i] = paramArray[i].Substring(0, paramArray[i].Length-1);//去掉末尾的","或者")"
                    paramList.Add(paramArray[i]);
                }                
            }

            foreach(string paramStr in paramList)
            {
                Type type = bean.GetType();
                PropertyInfo propertyInfo = type.GetProperty(paramStr);
                if (propertyInfo != null)
                {
                    Object value = propertyInfo.GetValue(bean);
                    //if (value == null)
                    //{
                    //    throw new Exception("bean中没有'"+paramStr+"'该属性，无法注入");
                    //}
                    //else
                    //{
                    //    sqlToSet.Replace("@" + paramStr, value + "");
                    //    sqlParameterList.Add(new SqlParameter("@" + paramStr, value));
                    //}
                    sqlToSet.Replace("@" + paramStr, value + "");
                    sqlParameterList.Add(new SqlParameter("@" + paramStr, value));
                }
                
            }

            return sqlParameterList;
        }

        /// <summary>
        /// 设置dataTable中的string属性到装入的对象中
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public static int SetStringValues(Object obj,DataRow dataRow)
        {
            if (obj == null)
            {
                return 0;
            }

            int count = 0;
            Type type = obj.GetType();
            PropertyInfo[] propertyInfoArray = type.GetProperties();
            foreach(PropertyInfo propertyInfo in propertyInfoArray)
            {
                if (!typeof(System.String).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    continue;
                }
                string propertyName = propertyInfo.Name;

                //开头存在下划线_的情况，应删除开头下划线
                if (propertyName.StartsWith("_"))
                {
                    propertyName=propertyName.Substring(1);
                }
                Object value = dataRow[propertyName];
                if (value != null)
                {
                    Type propertyType = propertyInfo.PropertyType;
                    if (propertyType.Equals(typeof(string)))
                    {
                        propertyInfo.SetValue(obj, value.ToString());
                        count++;
                    } 
                    
                }
            }
            return count;
        }
    }
}
