using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Database;

namespace USAACE.Common.CodeServices
{
    /// <summary>
    /// Used for generating code classes based on database table information.
    /// </summary>
    public static class ClassGenerator
    {
        /// <summary>
        /// Used for generating a class based on a table and a root namespace.
        /// </summary>
        /// <param name="table">The data table to generate the class for.</param>
        /// <param name="rootNameSpace">The root namespace for the entity classes.</param>
        /// <returns>The generated class text.</returns>
        public static String GenerateClass(Table table, String rootNameSpace)
        {
            StringBuilder classBuilder = new StringBuilder();

            classBuilder.AppendFormat(CLASS_HEADER, rootNameSpace, table.Schema, table.Name, table.IsView.ToString().ToLower());

            IList<Column> searchColumns = new List<Column>();

            foreach (Column column in table.Columns)
            {
                classBuilder.AppendFormat(MEMBER_PROPERTY_TEMPLATE, GenerationUtil.GetClrType(column), GenerationUtil.GetMemberName(column), GenerationUtil.GetPropertyAttributeSettings(column), column.Name, table.Schema, table.Name);

                foreach (Column searchColumn in column.GetSearchColumns())
                {
                    searchColumns.Add(searchColumn);
                }
            }

            classBuilder.AppendFormat(SEARCH_CLASS_HEADER, table.Name);

            foreach (Column searchColumn in searchColumns)
            {
                if (searchColumn.SearchOperation != SearchOperation.IsIn)
                {
                    classBuilder.AppendFormat(SEARCH_MEMBER_PROPERTY_TEMPLATE, GenerationUtil.GetClrType(searchColumn), GenerationUtil.GetMemberName(searchColumn), GenerationUtil.GetPropertyAttributeSettings(searchColumn), searchColumn.Name, table.Schema, table.Name);
                }
                else
                {
                    classBuilder.AppendFormat(SEARCH_MEMBER_LIST_PROPERTY_TEMPLATE, GenerationUtil.GetClrType(searchColumn), GenerationUtil.GetMemberName(searchColumn), GenerationUtil.GetPropertyAttributeSettings(searchColumn), searchColumn.Name, table.Schema, table.Name);
                }
                
            }

            classBuilder.Append(SEARCH_CLASS_FOOTER);

            classBuilder.AppendFormat(EXTENDED_CLASS_HEADER, table.Name);

            classBuilder.Append(CLASS_FOOTER);

            return classBuilder.ToString();
        }

        private const String CLASS_HEADER =
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace {0}
{{
    /// <summary>
    /// An entity representation of a record for the {1}.{2} data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = ""{1}"", IsView = {3})]
    public class {2} : EntityBase
    {{
        private {2}Search _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public {2}Search SearchProperties
        {{
            get
            {{
                if (_searchProperties == null)
                {{
                    _searchProperties = new {2}Search();
                }}

                return _searchProperties;
            }}
        }}

        private {2}Extended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public {2}Extended ExtendedProperties
        {{
            get
            {{
                if (_extendedProperties == null)
                {{
                    _extendedProperties = new {2}Extended();
                }}

                return _extendedProperties;
            }}
        }}
";

        private const String MEMBER_PROPERTY_TEMPLATE =
@"
        private {0} {1};

        /// <summary>
        /// A property representation of the {3} field for a record in the {4}.{5} data table. 
        /// </summary>
        [EntityProperty({2})]
        public {0} {3}
        {{
            get {{ return {1}; }}
            set {{ {1} = value; }}
        }}
";

        private const String SEARCH_CLASS_HEADER =
@"
    }}

    [Serializable]
    public class {0}Search : EntitySearchBase
    {{
        internal {0}Search() {{ }}
";

        private const String SEARCH_MEMBER_PROPERTY_TEMPLATE =
@"
        private {0} {1};

        /// <summary>
        /// A search property representation of the {3} field for a record in the {4}.{5} data table. 
        /// </summary>
        [EntityProperty({2})]
        public {0} {3}
        {{
            get {{ return {1}; }}
            set {{ {1} = value; }}
        }}
";

        private const String SEARCH_MEMBER_LIST_PROPERTY_TEMPLATE =
@"
        private IList<{0}> {1};

        /// <summary>
        /// A search property representation of the {3} field for a record in the {4}.{5} data table. 
        /// </summary>
        [EntityProperty({2})]
        public IList<{0}> {3}
        {{
            get
            {{
                if ({1} == null)
                {{
                    {1} = new List<{0}>();
                }}
                return {1};
            }}
            set {{ {1} = value; }}
        }}
";

        private const String SEARCH_CLASS_FOOTER =
@"
    }
";

        private const String EXTENDED_CLASS_HEADER =
@"
    [Serializable]
    public partial class {0}Extended : EntityExtendedBase
    {{
        internal {0}Extended() {{ }}";

        private const String CLASS_FOOTER =
@"
    }
}";

    }
}
