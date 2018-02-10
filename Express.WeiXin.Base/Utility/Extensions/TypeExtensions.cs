using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace HongYang.WeiXin.Base.Utility.Extensions
{
    public static class TypeExtensions
    {
        public static string AssemblyName(this Type type)
        {
            return type.Assembly.GetName().Name;
        }

        public static string FullNameWithAssembly(this Type type)
        {
            return string.Format("{0},{1}", type.FullName, type.Assembly.GetName().Name);
        }

        public static bool IsAssignableFromGeneric(this Type type, Type genericTypeDefinition)
        {
            try
            {
                var gtd = genericTypeDefinition.GetGenericTypeDefinition();
                foreach (var t in type.FindInterfaces((objType, objCriteria) => true, null))
                {
                    if (!t.IsGenericType)
                        continue;

                    return gtd.IsAssignableFrom(t.GetGenericTypeDefinition());
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static IEnumerable<ConstructorInfo> GetConstructorsWithDependency(this Type type, Type dependencyType)
        {
            return type.GetConstructors()
                .Where(x => x.GetParameters()
                .Any(xx => xx.ParameterType == dependencyType));
        }

        public static IEnumerable<PropertyInfo> GetPropertiesWithDependency(this Type type, Type dependencyType)
        {
            var props = type.GetProperties(BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance)
                 .Select(p => new
                 {
                     PropertyInfo = p,
                     p.PropertyType,
                     IndexParameters = p.GetIndexParameters(),
                     Accessors = p.GetAccessors(false)
                 })
                 .Where(x => x.PropertyType == dependencyType
                     && x.IndexParameters.Count() == 0 // must not be an indexer
                     && (x.Accessors.Length != 1 || x.Accessors[0].ReturnType == typeof(void))); //must have get/set, or only set

            return props.Select(p => p.PropertyInfo);
        }

        public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute(this Type type, Type attrType)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(o => o.GetCustomAttribute(attrType) != null);
            return props;
        }

        public static PropertyInfo GetPropertyInfo(this Type type, string propertyName, bool ignoreCase)
        {
            Func<PropertyInfo, bool> predicate = null;
            if (ignoreCase)
                predicate = o => o.Name.ToLower() == propertyName.ToLower();
            else
                predicate = o => o.Name == propertyName;

            return type.GetProperties(BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(predicate);
        }

        public static PropertyDescriptor GetPropertyDescriptor(this Type type, string propertyName, bool ignoreCase)
        {
            return System.ComponentModel.TypeDescriptor.GetProperties(type).Find(propertyName, ignoreCase);
        }

        public static Type GetTypeByFullName(this string typeName)
        {
            int gidx = typeName.IndexOf('`');
            if (gidx < 0)
                return Type.GetType(typeName);

            int lidx = typeName.IndexOf('[');
            if(lidx <= 0)
                return Type.GetType(typeName);

            int ridx = typeName.LastIndexOf(']');
            if(ridx <= lidx)
                throw new Exception(string.Format("Invalid type name:{0}", typeName));

            var genericDefTypeName = typeName.Substring(0, lidx);
            if (ridx < typeName.Length - 1)
                genericDefTypeName += typeName.Substring(ridx + 1);

            var argsCount = Convert.ToInt32(genericDefTypeName.Substring(gidx + 1, lidx - gidx - 1));
            var genericDefType = Type.GetType(genericDefTypeName);
            var argTypesName = typeName.Substring(lidx + 1, ridx - lidx - 1);
            Stack<char> lbrakets = new Stack<char>();
            List<string> argTypesNames = new List<string>();
            StringBuilder argTypeName = new StringBuilder();
            foreach (var c in argTypesName)
            {
                if (c == '[')
                {
                    lbrakets.Push(c);
                    if (lbrakets.Count > 1)
                    {
                        argTypeName.Append(c);
                    }
                }
                else if (c == ']')
                {
                    lbrakets.Pop();
                    if (lbrakets.Count > 0)
                    {
                        argTypeName.Append(c);
                    }
                    else
                    {
                        argTypesNames.Add(argTypeName.ToString());
                        argTypeName.Clear();
                    }
                }
                else if (c == ',')
                {
                    if (lbrakets.Count > 0)
                    {
                        argTypeName.Append(c);
                    }
                }
                else
                {
                    argTypeName.Append(c);
                }
            }
            if (argTypesNames.Count != argsCount)
                throw new Exception(string.Format("type name {0} argment types count doesn't equals to {1}", typeName, argsCount));

            Type[] argTypes = argTypesNames.Select(o => o.GetTypeByFullName()).ToArray();

            var genericType = genericDefType.MakeGenericType(argTypes);
            return genericType;
        }
    }
}
