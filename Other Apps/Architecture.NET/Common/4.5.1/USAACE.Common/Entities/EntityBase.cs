using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using USAACE.Common.Entities.Attributes;
using System.Data.SqlClient;
using USAACE.Common.DataAccess;
using System.Configuration;
using USAACE.Common.DataTypes;
using USAACE.Common.Exceptions;

namespace USAACE.Common.Entities
{
    /// <summary>
    /// An abstract class for the base functionality of an entity
    /// </summary>
    [Serializable]
    public abstract class EntityBase
    {
        /// <summary>
        /// Loads the entity
        /// </summary>
        /// <returns>Whether the load was successful</returns>
        public Boolean Load()
        {
            EntityTable entityAttribute = this.GetType().GetCustomAttributes(typeof(EntityTable), false).FirstOrDefault() as EntityTable;

            if (entityAttribute.IsView == true)
            {
                throw new USAACEException(ExceptionType.Unrecoverable, "A load cannot be performed on an entity based on a view.");
            }

            SqlCommand loadCommand = this.GenerateSqlCommand(DataOperation.Load);
            loadCommand.Connection.Open();

            SqlDataReader reader = loadCommand.ExecuteReader();

            Boolean readResult = false;

            if (reader.Read())
            {
                readResult = true;

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    this.GetType().GetProperty(reader.GetName(i)).SetValue(this, reader.GetValue(i) != System.DBNull.Value ? reader.GetValue(i) : null, null);
                }
            }

            reader.Close();

            loadCommand.Connection.Close();
            loadCommand.Connection.Dispose();

            return readResult;
        }

        /// <summary>
        /// Saves the entity
        /// </summary>
        public void Save()
        {
            EntityTable entityAttribute = this.GetType().GetCustomAttributes(typeof(EntityTable), false).FirstOrDefault() as EntityTable;

            if (entityAttribute.IsView == true)
            {
                throw new USAACEException(ExceptionType.Unrecoverable, "A save cannot be performed on an entity based on a view.");
            }

            PropertyInfo identityProperty = this.GetType().GetProperties().First(x => x.GetCustomAttributes(typeof(EntityProperty), false).FirstOrDefault(y => y is EntityProperty && (y as EntityProperty).IdentityField == true) != null);

            DataOperation operation = identityProperty.GetValue(this, null) == null ? DataOperation.Insert : DataOperation.Update;

            SqlCommand saveCommand = this.GenerateSqlCommand(operation);
            saveCommand.Connection.Open();

            if (operation == DataOperation.Update)
            {
                saveCommand.ExecuteNonQuery();
            }
            else
            {
                SqlDataReader reader = saveCommand.ExecuteReader();

                if (reader.Read())
                {
                    identityProperty.SetValue(this, reader.GetValue(0).ToNullable<Int32>(), null);
                }

                reader.Close();
            }

            saveCommand.Connection.Close();
            saveCommand.Connection.Dispose();
        }

        /// <summary>
        /// Deletes the entity and sets the identity property value to null
        /// </summary>
        public void Delete()
        {
            EntityTable entityAttribute = this.GetType().GetCustomAttributes(typeof(EntityTable), false).FirstOrDefault() as EntityTable;

            if (entityAttribute.IsView == true)
            {
                throw new USAACEException(ExceptionType.Unrecoverable, "A delete operation cannot be performed on an entity based on a view.");
            }

            SqlCommand deleteCommand = this.GenerateSqlCommand(DataOperation.Delete);
            deleteCommand.Connection.Open();

            deleteCommand.ExecuteNonQuery();

            deleteCommand.Connection.Close();
            deleteCommand.Connection.Dispose();

            PropertyInfo identityProperty = this.GetType().GetProperties().First(x => x.GetCustomAttributes(typeof(EntityProperty), false).FirstOrDefault(y => y is EntityProperty && (y as EntityProperty).IdentityField == true) != null);

            identityProperty.SetValue(this, null, null);
        }

        /// <summary>
        /// Deep copies an entity leaving the original intact
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <returns>The copied entity</returns>
        public T Copy<T>() where T : EntityBase, new()
        {
            return this.Copy(true, new T());
        }

        /// <summary>
        /// Deep copies an entity leaving the original intact
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="includePrimaryKey">True if the primary key value should be copied as well, false otherwise</param>
        /// <returns>The copied entity</returns>
        public T Copy<T>(Boolean includePrimaryKey) where T : EntityBase, new()
        {
            return this.Copy(includePrimaryKey, new T());
        }

        /// <summary>
        /// Deep copies an entity leaving the original intact
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="includePrimaryKey">True if the primary key value should be copied as well, false otherwise</param>
        /// <param name="destination">The destination object that it should be copied to</param>
        /// <returns>The copied entity</returns>
        public T Copy<T>(Boolean includePrimaryKey, T destination) where T : EntityBase
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                EntityProperty entityAttribute = property.GetCustomAttributes(typeof(EntityProperty), false).FirstOrDefault() as EntityProperty;

                if (entityAttribute != null && (entityAttribute.IdentityField != true || includePrimaryKey))
                {
                    Object propertyValue = property.GetValue(this, null);

                    if (propertyValue is String && propertyValue as String == String.Empty)
                    {
                        propertyValue = null;
                    }

                    property.SetValue(destination, propertyValue, null);
                }
            }

            return destination;
        }

        /// <summary>
        /// Executes a search of entities that match the properties set in the current entity
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <returns>A list of entities that match the current entity properties</returns>
        public IList<T> Search<T>() where T : EntityBase, new()
        {
            SqlCommand searchCommand = this.GenerateSqlCommand(DataOperation.Search);
            searchCommand.Connection.Open();

            SqlDataReader reader = searchCommand.ExecuteReader();

            IList<T> results = new List<T>();

            while (reader.Read())
            {
                T result = new T();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    typeof(T).GetProperty(reader.GetName(i)).SetValue(result, reader.GetValue(i) != System.DBNull.Value ? reader.GetValue(i) : null, null);
                }

                results.Add(result);
            }

            reader.Close();

            searchCommand.Connection.Close();
            searchCommand.Connection.Dispose();

            return results;
        }

        /// <summary>
        /// Lists all of the entities in the table the entity represents
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <returns>The list of all entities in the table</returns>
        public IList<T> ListAll<T>() where T : EntityBase, new()
        {
            T input = new T();

            return input.Search<T>();
        }

        /// <summary>
        /// Lists all of the entities in the table the entity represents creating a dictionary based on the primary key value
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <returns>A dictionary by primary key value of all entities in the table</returns>
        public IDictionary<Nullable<Int32>, T> ListAllDictionary<T>() where T : EntityBase, new()
        {
            EntityTable entityAttribute = this.GetType().GetCustomAttributes(typeof(EntityTable), false).FirstOrDefault() as EntityTable;

            if (entityAttribute.IsView == true)
            {
                throw new USAACEException(ExceptionType.Unrecoverable, "A dictionary list all operation cannot be performed on an entity based on a view.");
            }

            IList<T> list = ListAll<T>();

            PropertyInfo primaryKey = GetPrimaryKeyProperty();

            IDictionary<Nullable<Int32>, T> dictionary = new Dictionary<Nullable<Int32>, T>();

            foreach (T item in list)
            {
                Nullable<Int32> primaryKeyValue = primaryKey.GetValue(item, null) as Nullable<Int32>;

                if (!dictionary.ContainsKey(primaryKeyValue))
                {
                    dictionary.Add(new KeyValuePair<Nullable<Int32>, T>(primaryKeyValue, item));
                }
            }

            return dictionary;
        }

        /// <summary>
        /// Generates the SQL command to execute on the database
        /// </summary>
        /// <param name="operation">The type of operation to execute</param>
        /// <returns>The SQL command with all of the required parameters and settings entered</returns>
        private SqlCommand GenerateSqlCommand(DataOperation operation)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

            SqlCommand command = new SqlCommand();
            command.CommandText = DataAccessUtil.GetStoredProcedureName(this, operation);
            command.Connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                EntityProperty entityAttribute = property.GetCustomAttributes(typeof(EntityProperty), false).FirstOrDefault() as EntityProperty;

                if (entityAttribute != null)
                {
                    SqlParameter parameter = GetPropertyParameter(property, this);

                    if (entityAttribute.IdentityField == true && (operation == DataOperation.Load || operation == DataOperation.Delete
                        || operation == DataOperation.Search || operation == DataOperation.Update))
                    {
                        command.Parameters.Add(parameter);
                    }
                    else if (entityAttribute.IdentityField == false && (operation == DataOperation.Load || operation == DataOperation.Update
                        || operation == DataOperation.Search || operation == DataOperation.Insert))
                    {
                        command.Parameters.Add(parameter);
                    }
                }
            }

            if (operation == DataOperation.Search)
            {
                EntitySearchBase searchBase = this.GetType().GetProperty("SearchProperties").GetValue(this, null) as EntitySearchBase;

                if (searchBase != null)
                {
                    foreach (PropertyInfo searchProperty in searchBase.GetType().GetProperties())
                    {
                        EntityProperty searchAttribute = searchProperty.GetCustomAttributes(typeof(EntityProperty), false).FirstOrDefault() as EntityProperty;

                        if (searchAttribute != null)
                        {
                            SqlParameter parameter = GetPropertyParameter(searchProperty, searchBase);

                            command.Parameters.Add(parameter);
                        }
                    }
                }
            }

            return command;
        }

        private SqlParameter GetPropertyParameter(PropertyInfo property, Object item)
        {
            Object propertyValue = property.GetValue(item, null);

            if (property.PropertyType == typeof(String) && propertyValue as String == String.Empty)
            {
                propertyValue = null;
            }
            else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>))
            {
                propertyValue = GetSplitString(propertyValue);
            }

            SqlParameter parameter = new SqlParameter();
            parameter.SqlDbType = DataAccessUtil.GetSqlType(property.PropertyType);
            parameter.ParameterName = DataAccessUtil.GetParameterName(property.Name);
            parameter.Value = propertyValue;
            parameter.IsNullable = true;

            return parameter;
        }

        public String GetSplitString(Object propertyValue)
        {
            if (propertyValue is IList<Nullable<Byte>>)
            {
                IList<Nullable<Byte>> list = propertyValue as IList<Nullable<Byte>>;
                return list.Count > 0 ? String.Join("||", list.Where(x => x != null).Select(x => x.ToString())) : null;
            }
            else if (propertyValue is IList<Nullable<Int16>>)
            {
                IList<Nullable<Int16>> list = propertyValue as IList<Nullable<Int16>>;
                return list.Count > 0 ? String.Join("||", list.Where(x => x != null).Select(x => x.ToString())) : null;
            }
            else if (propertyValue is IList<Nullable<Int32>>)
            {
                IList<Nullable<Int32>> list = propertyValue as IList<Nullable<Int32>>;
                return list.Count > 0 ? String.Join("||", list.Where(x => x != null).Select(x => x.ToString())) : null;
            }
            else if (propertyValue is IList<Nullable<Int64>>)
            {
                IList<Nullable<Int64>> list = propertyValue as IList<Nullable<Int64>>;
                return list.Count > 0 ? String.Join("||", list.Where(x => x != null).Select(x => x.ToString())) : null;
            }
            else if (propertyValue is IList<String>)
            {
                IList<String> list = propertyValue as IList<String>;
                return list.Count > 0 ? String.Join("||", list.Where(x => x != null).Select(x => x.ToString())) : null;
            }
            else if (propertyValue is IList<Nullable<DateTime>>)
            {
                IList<Nullable<DateTime>> list = propertyValue as IList<Nullable<DateTime>>;
                return list.Count > 0 ? String.Join("||", list.Where(x => x != null).Select(x => x.ToString())) : null;
            }
            else if (propertyValue is IList<Nullable<Decimal>>)
            {
                IList<Nullable<Decimal>> list = propertyValue as IList<Nullable<Decimal>>;
                return list.Count > 0 ? String.Join("||", list.Where(x => x != null).Select(x => x.ToString())) : null;
            }
            else
            {
                return null;
            }
        }

        private PropertyInfo GetPrimaryKeyProperty()
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                EntityProperty entityAttribute = property.GetCustomAttributes(typeof(EntityProperty), false).FirstOrDefault() as EntityProperty;

                if (entityAttribute != null && entityAttribute.IdentityField == true)
                {
                    return property;
                }
            }

            return null;
        }
    }
}
