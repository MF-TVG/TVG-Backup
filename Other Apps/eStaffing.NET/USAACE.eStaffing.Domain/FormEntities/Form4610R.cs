using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.FormEntities
{
    [Serializable]
    public class Form4610R : FormEntityBase
    {
        private String _title;

        /// <summary>
        /// A property representation of the Title field for a record in the dbo.Form4610R data table. 
        /// </summary>
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _uic;

        /// <summary>
        /// A property representation of the UIC field for a record in the dbo.Form4610R data table. 
        /// </summary>
        public String UIC
        {
            get { return _uic; }
            set { _uic = value; }
        }

        private String _unit;

        /// <summary>
        /// A property representation of the UIC field for a record in the dbo.Form4610R data table. 
        /// </summary>
        public String Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private String _tdaNumber;

        /// <summary>
        /// A property representation of the TDANumber field for a record in the dbo.Form4610R data table. 
        /// </summary>
        public String TDANumber
        {
            get { return _tdaNumber; }
            set { _tdaNumber = value; }
        }

        private String _ccNumber;

        /// <summary>
        /// A property representation of the CCNum field for a record in the dbo.Form4610R data table. 
        /// </summary>
        public String CCNumber
        {
            get { return _ccNumber; }
            set { _ccNumber = value; }
        }

        private String _justification;

        /// <summary>
        /// A property representation of the Justification field for a record in the dbo.Form4610R data table. 
        /// </summary>
        public String Justification
        {
            get { return _justification; }
            set { _justification = value; }
        }

        private List<Form4610RItemChange> _itemChanges;

        public List<Form4610RItemChange> ItemChanges
        {
            get
            {
                if (_itemChanges == null)
                {
                    _itemChanges = new List<Form4610RItemChange>();
                }

                return _itemChanges;
            }
            set
            {
                _itemChanges = value;
            }
        }

        private List<Form4610RItemOtherDelete> _itemOtherDeletions;

        public List<Form4610RItemOtherDelete> ItemOtherDeletions
        {
            get
            {
                if (_itemOtherDeletions == null)
                {
                    _itemOtherDeletions = new List<Form4610RItemOtherDelete>();
                }

                return _itemOtherDeletions;
            }
            set
            {
                _itemOtherDeletions = value;
            }
        }

        private List<Form4610RPositionChange> _positionChanges;

        public List<Form4610RPositionChange> PositionChanges
        {
            get
            {
                if (_positionChanges == null)
                {
                    _positionChanges = new List<Form4610RPositionChange>();
                }

                return _positionChanges;
            }
            set
            {
                _positionChanges = value;
            }
        }
    }

    [Serializable]
    public class Form4610RItemChange : FormSubEntityBase
    {
        private String _paragraphNumber;

        /// <summary>
        /// A property representation of the ParagraphNumber field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public String ParagraphNumber
        {
            get { return _paragraphNumber; }
            set { _paragraphNumber = value; }
        }

        private String _lineNumber;

        /// <summary>
        /// A property representation of the LineNumber field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public String LineNumber
        {
            get { return _lineNumber; }
            set { _lineNumber = value; }
        }

        private String _erc;

        /// <summary>
        /// A property representation of the ERC field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public String ERC
        {
            get { return _erc; }
            set { _erc = value; }
        }

        private String _chapter;

        /// <summary>
        /// A property representation of the Chapter field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public String Chapter
        {
            get { return _chapter; }
            set { _chapter = value; }
        }

        private String _nomenclature;

        /// <summary>
        /// A property representation of the Nomenclature field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public String Nomenclature
        {
            get { return _nomenclature; }
            set { _nomenclature = value; }
        }

        private Nullable<Decimal> _cost;

        /// <summary>
        /// A property representation of the Cost field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public Nullable<Decimal> Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        private Nullable<Int16> _quantityAddReq;

        /// <summary>
        /// A property representation of the QuantityAddReq field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityAddReq
        {
            get { return _quantityAddReq; }
            set { _quantityAddReq = value; }
        }

        private Nullable<Int16> _quantityAddAuth;

        /// <summary>
        /// A property representation of the QuantityAddAuth field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityAddAuth
        {
            get { return _quantityAddAuth; }
            set { _quantityAddAuth = value; }
        }

        private Nullable<Int16> _quantityDeleteReq;

        /// <summary>
        /// A property representation of the QuantityDeleteReq field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityDeleteReq
        {
            get { return _quantityDeleteReq; }
            set { _quantityDeleteReq = value; }
        }

        private Nullable<Int16> _quantityDeleteAuth;

        /// <summary>
        /// A property representation of the QuantityDeleteAuth field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityDeleteAuth
        {
            get { return _quantityDeleteAuth; }
            set { _quantityDeleteAuth = value; }
        }

        private Nullable<Int16> _quantityNewParaReq;

        /// <summary>
        /// A property representation of the QuantityNewParaReq field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityNewParaReq
        {
            get { return _quantityNewParaReq; }
            set { _quantityNewParaReq = value; }
        }

        private Nullable<Int16> _quantityNewParaAuth;

        /// <summary>
        /// A property representation of the QuantityNewParaAuth field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityNewParaAuth
        {
            get { return _quantityNewParaAuth; }
            set { _quantityNewParaAuth = value; }
        }

        private Nullable<Int16> _quantityRecapReq;

        /// <summary>
        /// A property representation of the QuantityRecapReq field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityRecapReq
        {
            get { return _quantityRecapReq; }
            set { _quantityRecapReq = value; }
        }

        private Nullable<Int16> _quantityRecapAuth;

        /// <summary>
        /// A property representation of the QuantityRecapAuth field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityRecapAuth
        {
            get { return _quantityRecapAuth; }
            set { _quantityRecapAuth = value; }
        }

        private Nullable<Int16> _quantityNotAuth;

        /// <summary>
        /// A property representation of the QuantityNotAuth field for a record in the dbo.Form4610RItemChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityNotAuth
        {
            get { return _quantityNotAuth; }
            set { _quantityNotAuth = value; }
        }
    }

    [Serializable]
    public class Form4610RItemOtherDelete : FormSubEntityBase
    {
        private String _paragraphNumber;

        /// <summary>
        /// A property representation of the ParagraphNumber field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public String ParagraphNumber
        {
            get { return _paragraphNumber; }
            set { _paragraphNumber = value; }
        }

        private String _lineNumber;

        /// <summary>
        /// A property representation of the LineNumber field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public String LineNumber
        {
            get { return _lineNumber; }
            set { _lineNumber = value; }
        }

        private String _erc;

        /// <summary>
        /// A property representation of the ERC field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public String ERC
        {
            get { return _erc; }
            set { _erc = value; }
        }

        private String _chapter;

        /// <summary>
        /// A property representation of the Chapter field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public String Chapter
        {
            get { return _chapter; }
            set { _chapter = value; }
        }

        private String _nomenclature;

        /// <summary>
        /// A property representation of the Nomenclature field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public String Nomenclature
        {
            get { return _nomenclature; }
            set { _nomenclature = value; }
        }

        private Nullable<Decimal> _cost;

        /// <summary>
        /// A property representation of the Cost field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public Nullable<Decimal> Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        private Nullable<Int16> _quantityDeleteReq;

        /// <summary>
        /// A property representation of the QuantityDeleteReq field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public Nullable<Int16> QuantityDeleteReq
        {
            get { return _quantityDeleteReq; }
            set { _quantityDeleteReq = value; }
        }

        private Nullable<Int16> _quantityDeleteAuth;

        /// <summary>
        /// A property representation of the QuantityDeleteAuth field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public Nullable<Int16> QuantityDeleteAuth
        {
            get { return _quantityDeleteAuth; }
            set { _quantityDeleteAuth = value; }
        }

        private String _uic;

        /// <summary>
        /// A property representation of the UIC field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public String UIC
        {
            get { return _uic; }
            set { _uic = value; }
        }

        private String _tdaNumber;

        /// <summary>
        /// A property representation of the TDANumber field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public String TDANumber
        {
            get { return _tdaNumber; }
            set { _tdaNumber = value; }
        }

        private String _ccNumber;

        /// <summary>
        /// A property representation of the CCNumber field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public String CCNumber
        {
            get { return _ccNumber; }
            set { _ccNumber = value; }
        }

        private Nullable<Boolean> _assetTrf;

        /// <summary>
        /// A property representation of the AssetTrf field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public Nullable<Boolean> AssetTrf
        {
            get { return _assetTrf; }
            set { _assetTrf = value; }
        }

        private String _remarks;

        /// <summary>
        /// A property representation of the Remarks field for a record in the dbo.Form4610RItemOtherDelete data table. 
        /// </summary>
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
    }

    [Serializable]
    public class Form4610RPositionChange : FormSubEntityBase
    {
        private String _paragraphNumber;

        /// <summary>
        /// A property representation of the ParagraphNumber field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public String ParagraphNumber
        {
            get { return _paragraphNumber; }
            set { _paragraphNumber = value; }
        }

        private String _lineNumber;

        /// <summary>
        /// A property representation of the LineNumber field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public String LineNumber
        {
            get { return _lineNumber; }
            set { _lineNumber = value; }
        }

        private Nullable<Int16> _positionAdd;

        /// <summary>
        /// A property representation of the PositionAdd field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public Nullable<Int16> PositionAdd
        {
            get { return _positionAdd; }
            set { _positionAdd = value; }
        }

        private Nullable<Int16> _positionDelete;

        /// <summary>
        /// A property representation of the PositionDelete field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public Nullable<Int16> PositionDelete
        {
            get { return _positionDelete; }
            set { _positionDelete = value; }
        }

        private String _description;

        /// <summary>
        /// A property representation of the Description field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private String _gr;

        /// <summary>
        /// A property representation of the GR field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public String GR
        {
            get { return _gr; }
            set { _gr = value; }
        }

        private String _mos;

        /// <summary>
        /// A property representation of the MOS field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public String MOS
        {
            get { return _mos; }
            set { _mos = value; }
        }

        private String _asilic;

        /// <summary>
        /// A property representation of the ASILIC field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public String ASILIC
        {
            get { return _asilic; }
            set { _asilic = value; }
        }

        private String _br;

        /// <summary>
        /// A property representation of the BR field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public String BR
        {
            get { return _br; }
            set { _br = value; }
        }

        private String _id;

        /// <summary>
        /// A property representation of the ID field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public String ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _amsc;

        /// <summary>
        /// A property representation of the AMSC field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public String AMSC
        {
            get { return _amsc; }
            set { _amsc = value; }
        }

        private Nullable<Int16> _quantityRecapReq;

        /// <summary>
        /// A property representation of the QuantityRecapReq field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityRecapReq
        {
            get { return _quantityRecapReq; }
            set { _quantityRecapReq = value; }
        }

        private Nullable<Int16> _quantityRecapAuth;

        /// <summary>
        /// A property representation of the QuantityRecapAuth field for a record in the dbo.Form4610RPositionChange data table. 
        /// </summary>
        public Nullable<Int16> QuantityRecapAuth
        {
            get { return _quantityRecapAuth; }
            set { _quantityRecapAuth = value; }
        }
    }
}
