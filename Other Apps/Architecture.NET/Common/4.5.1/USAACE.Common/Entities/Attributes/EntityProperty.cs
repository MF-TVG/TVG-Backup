using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace USAACE.Common.Entities.Attributes
{
    /// <summary>
    /// An attribute used to identify a property that is part of an entity
    /// </summary>
    public class EntityProperty : Attribute
    {
        private Boolean _identityField = false;

        /// <summary>
        /// If the field is a primary key identity field
        /// </summary>
        public Boolean IdentityField
        {
            get { return _identityField; }
            set { _identityField = value; }
        }

        private Byte _precision = default(Byte);

        /// <summary>
        /// The precision of the field, applies only to numeric fields
        /// </summary>
        public Byte Precision
        {
            get { return _precision; }
            set { _precision = value; }
        }

        private Byte _scale = default(Byte);

        /// <summary>
        /// The scale of the field, applies only to numeric fields
        /// </summary>
        public Byte Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }

        private Int32 _size = default(Int32);

        /// <summary>
        /// The size of the field, applies only to char, varchar, and varbinary fields
        /// </summary>
        public Int32 Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private Boolean _searchOnly = false;

        /// <summary>
        /// Designates a property only to be used in searches
        /// </summary>
        public Boolean SearchOnly
        {
            get { return _searchOnly; }
            set { _searchOnly = value; }
        }
    }
}
