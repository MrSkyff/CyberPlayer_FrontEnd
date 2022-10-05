using Google.Protobuf.WellKnownTypes;
using System.Reflection;

namespace MVC_FrontEnd.Services.Mapper
{
    public class Mapper
    {
        private List<System.Type> AllowTypeList()
        {
            List<System.Type> types = new List<System.Type>()
            {
                typeof(String),
                typeof(DateTime),
                typeof(Int32),
                typeof(Decimal),
                typeof(Boolean),
                typeof(Int16),
                typeof(Int64),
                typeof(Double),
                typeof(Byte),
                typeof(Guid),
                typeof(Timestamp),
                typeof(float),
                typeof(short)
            };
            return types;
        }

        #region MapFromProto

        /// <summary>
        /// List map method
        /// </summary>
        /// <typeparam name="ClassTo"></typeparam>
        /// <typeparam name="ClassFrom"></typeparam>
        /// <param name="classTo"></param>
        /// <param name="classFrom"></param>
        public List<ClassTo> MapFromProto<ClassTo, ClassFrom>(List<ClassTo> classTo, List<ClassFrom> classFrom)
        {
            foreach (var currentClass in classFrom)
            {
                PropertyInfo[] classFromProp = currentClass!.GetType().GetProperties();
                var newClassToTemp = (ClassTo)Activator.CreateInstance(typeof(ClassTo))!;
                PropertyInfo[] classToProp = newClassToTemp.GetType().GetProperties();

                for (int i = 0, p = 0; i < classToProp.Length; i++, p++)
                {
                    if (AllowTypeList().Contains(classFromProp[p].PropertyType))
                    {
                        if (classToProp[i].Name == classFromProp[p].Name)
                        {
                            if (classToProp[i].PropertyType.Name == typeof(DateTime).Name)
                            {
                                classToProp[i].SetValue(newClassToTemp, Convert.ToDateTime(classFromProp[p].GetValue(currentClass, null)));
                            }
                            else
                            {
                                classToProp[i].SetValue(newClassToTemp, classFromProp[p].GetValue(currentClass, null));
                            }
                        }
                        else
                        {
                            for (int i2 = 0; i2 < classFromProp.Length; i2++)
                            {
                                if (classToProp[i].Name == classFromProp[i2].Name)
                                {
                                    if (classToProp[i].PropertyType.Name == typeof(DateTime).Name)
                                    {
                                        classToProp[i].SetValue(newClassToTemp, Convert.ToDateTime(classFromProp[i2].GetValue(currentClass, null)));
                                        break;
                                    }
                                    else
                                    {
                                        classToProp[i].SetValue(newClassToTemp, classFromProp[i2].GetValue(currentClass, null));
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else { --i; }
                }
                classTo.Add(newClassToTemp);
            }
            return classTo;
        }

        /// <summary>
        /// Single class map method
        /// </summary>
        /// <typeparam name="ClassTo"></typeparam>
        /// <typeparam name="ClassFrom"></typeparam>
        /// <param name="classTo"></param>
        /// <param name="classFrom"></param>
        public ClassTo MapFromProto<ClassTo, ClassFrom>(ClassTo classTo, ClassFrom classFrom)
        {
            PropertyInfo[] classFromProp = classFrom!.GetType().GetProperties();
            PropertyInfo[] classToProp = classTo!.GetType().GetProperties();

            for (int i = 0, p = 0; i < classToProp.Length; i++, p++)
            {
                if (AllowTypeList().Contains(classFromProp[p].PropertyType))
                {

                    if (classToProp[i].Name == classFromProp[i].Name)
                    {
                        if (classToProp[i].PropertyType.Name == typeof(DateTime).Name)
                        {
                            classToProp[i].SetValue(classTo, Convert.ToDateTime(classFromProp[p].GetValue(classFrom, null)));
                        }
                        else
                        {
                            classToProp[i].SetValue(classTo, classFromProp[p].GetValue(classFrom, null));
                        }

                    }
                    else
                    {
                        for (int i2 = 0; i2 < classFromProp.Length; i2++)
                        {
                            if (classToProp[i].Name == classFromProp[i2].Name)
                            {
                                if (classToProp[i].PropertyType.Name == typeof(DateTime).Name)
                                {
                                    classToProp[i].SetValue(classTo, Convert.ToDateTime(classFromProp[i2].GetValue(classFrom, null)));
                                    break;
                                }
                                else
                                {
                                    classToProp[i].SetValue(classTo, classFromProp[i2].GetValue(classFrom, null));
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    --i;
                }

            }
            return classTo;
        }

        #endregion


        #region MapToProto

        /// <summary>
        /// List class method - "ProtoBufModels" Not a reference type, use return data. On pass use "ToList()" method.
        /// </summary>
        /// <typeparam name="ClassTo"></typeparam>
        /// <typeparam name="ClassFrom"></typeparam>
        /// <param name="classTo"></param>
        /// <param name="classFrom"></param>
        public List<ClassTo> MapToProto<ClassTo, ClassFrom>(List<ClassTo> classTo, List<ClassFrom> classFrom)
        {
            foreach (var currentClass in classFrom)
            {
                PropertyInfo[] classFromProp = currentClass!.GetType().GetProperties();
                var newClassToTemp = (ClassTo)Activator.CreateInstance(typeof(ClassTo))!;
                PropertyInfo[] classToProp = newClassToTemp.GetType().GetProperties();

                for (int i = 0, p = 0; i < classToProp.Length; i++, p++)
                {
                    if (AllowTypeList().Contains(classToProp[i].PropertyType))
                    {
                        if (classToProp[i].Name == classFromProp[p].Name)
                        {
                            if (classFromProp[p].PropertyType.Name == typeof(DateTime).Name)
                            {
                                classToProp[i].SetValue(newClassToTemp, classFromProp[p].GetValue(currentClass, null)!.ToString());
                            }
                            else
                            {
                                classToProp[i].SetValue(newClassToTemp, classFromProp[p].GetValue(currentClass, null));
                            }
                        }
                        else
                        {
                            for (int i2 = 0; i2 < classFromProp.Length; i2++)
                            {
                                if (classToProp[i].Name == classFromProp[i2].Name)
                                {
                                    if (classFromProp[i2].PropertyType.Name == typeof(DateTime).Name)
                                    {
                                        classToProp[i].SetValue(newClassToTemp, classFromProp[i2].GetValue(currentClass, null)!.ToString());
                                        break;
                                    }
                                    else
                                    {
                                        classToProp[i].SetValue(newClassToTemp, classFromProp[i2].GetValue(currentClass, null));
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else { --p; }
                }
                classTo.Add(newClassToTemp);
            }
            return classTo;
        }

        /// <summary>
        /// Single map method, for "ClassTo" pass "new ProtoClassName{}".
        /// </summary>
        /// <typeparam name="ClassTo"></typeparam>
        /// <typeparam name="ClassFrom"></typeparam>
        /// <param name="classTo"></param>
        /// <param name="classFrom"></param>
        public ClassTo MapToProto<ClassTo, ClassFrom>(ClassTo classTo, ClassFrom classFrom)
        {
            PropertyInfo[] classFromProp = classFrom!.GetType().GetProperties();
            PropertyInfo[] classToProp = classTo!.GetType().GetProperties();

            for (int i = 0, p = 0; i < classToProp.Length; i++, p++)
            {
                if (AllowTypeList().Contains(classToProp[i].PropertyType))
                {
                    if (classToProp[p].Name == classFromProp[p].Name)
                    {
                        if (classFromProp[i].PropertyType.Name == typeof(DateTime).Name)
                        {
                            classToProp[i].SetValue(classTo, classFromProp[p].GetValue(classFrom, null)!.ToString());
                        }
                        else
                        {
                            classToProp[i].SetValue(classTo, classFromProp[p].GetValue(classFrom, null));
                        }
                    }
                    else
                    {
                        for (int i2 = 0; i2 < classFromProp.Length; i2++)
                        {
                            if (classToProp[i].Name == classFromProp[i2].Name)
                            {
                                if (classFromProp[i2].PropertyType.Name == typeof(DateTime).Name)
                                {
                                    classToProp[i].SetValue(classTo, classFromProp[i2].GetValue(classFrom, null)!.ToString());
                                    break;
                                }
                                else
                                {
                                    classToProp[i].SetValue(classTo, classFromProp[i2].GetValue(classFrom, null));
                                    break;
                                }

                            }
                        }
                    }
                }
                else { --p; }
            }
            return classTo;
        }

        #endregion
    }
}
