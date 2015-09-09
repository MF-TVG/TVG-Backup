using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.Common.Web;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Presentation.Presenters.Controls.Forms;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;
using USAACE.eStaffing.Web.Util;

namespace USAACE.eStaffing.Web.Controls.Forms
{
    public partial class Form4610RSheet : FormControl, IForm4610RSheetView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private Form4610RSheetPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public Form4610RSheetPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new Form4610RSheetPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadForm()
        {
            rblOtherItemAssetTrf.BindBooleanListControl("Yes", "No");

            Presenter.Load();
        }

        protected override void SaveForm()
        {
            Presenter.Save();
        }

        protected override void SaveDefault()
        {
            Presenter.SaveDefault();
        }

        protected void dlItemChanges_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is Form4610RItemChange)
                {
                    Form4610RItemChange change = e.Item.DataItem as Form4610RItemChange;

                    (e.Item.FindControl("ltrItem") as Literal).Text = (e.Item.ItemIndex + 1).ToString();
                    (e.Item.FindControl("ltrParagraphNumber") as Literal).Text = change.ParagraphNumber;
                    (e.Item.FindControl("ltrLineNumber") as Literal).Text = change.LineNumber;
                    (e.Item.FindControl("ltrERC") as Literal).Text = change.ERC;
                    (e.Item.FindControl("ltrChapter") as Literal).Text = change.Chapter;
                    (e.Item.FindControl("ltrNomenclature") as Literal).Text = change.Nomenclature;
                    (e.Item.FindControl("ltrCost") as Literal).Text = change.Cost.ToStringSafe();
                    (e.Item.FindControl("ltrQuantityAddReq") as Literal).Text = change.QuantityAddReq.ToStringSafe();
                    (e.Item.FindControl("ltrQuantityAddAuth") as Literal).Text = change.QuantityAddAuth.ToStringSafe();
                    (e.Item.FindControl("ltrQuantityDeleteReq") as Literal).Text = change.QuantityDeleteReq.ToStringSafe();
                    (e.Item.FindControl("ltrQuantityDeleteAuth") as Literal).Text = change.QuantityDeleteAuth.ToStringSafe();
                    (e.Item.FindControl("ltrNewParaQtyReq") as Literal).Text = change.QuantityNewParaReq.ToStringSafe();
                    (e.Item.FindControl("ltrNewParaQtyAuth") as Literal).Text = change.QuantityNewParaAuth.ToStringSafe();
                    (e.Item.FindControl("ltrNewRecapQtyReq") as Literal).Text = change.QuantityRecapReq.ToStringSafe();
                    (e.Item.FindControl("ltrNewRecapQtyAuth") as Literal).Text = change.QuantityRecapAuth.ToStringSafe();
                    (e.Item.FindControl("ltrQtyOnHand") as Literal).Text = change.QuantityNotAuth.ToStringSafe();
                    (e.Item.FindControl("imbEditItemChange") as ImageButton).CommandArgument = change.ListIndex.ToString();
                    (e.Item.FindControl("imbDeleteItemChange") as ImageButton).CommandArgument = change.ListIndex.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditItemChange_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedItemChange = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                Presenter.LoadItemChange();
                mpEditItemChange.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbDeleteItemChange_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedItemChange = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                mpDeleteItemChangeConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddItemChange_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedItemChange = null;
                Presenter.LoadItemChange();
                mpEditItemChange.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveItemChange_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveItemChange();
                mpEditItemChange.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelItemChange_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditItemChange.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteItemChangeConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteItemChange();
                mpDeleteItemChangeConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteItemChangeCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteItemChangeConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlOtherItemDeletions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is Form4610RItemOtherDelete)
                {
                    Form4610RItemOtherDelete change = e.Item.DataItem as Form4610RItemOtherDelete;

                    (e.Item.FindControl("ltrItem") as Literal).Text = (e.Item.ItemIndex + 1).ToString();
                    (e.Item.FindControl("ltrParagraphNumber") as Literal).Text = change.ParagraphNumber;
                    (e.Item.FindControl("ltrLineNumber") as Literal).Text = change.LineNumber;
                    (e.Item.FindControl("ltrERC") as Literal).Text = change.ERC;
                    (e.Item.FindControl("ltrChapter") as Literal).Text = change.Chapter;
                    (e.Item.FindControl("ltrNomenclature") as Literal).Text = change.Nomenclature;
                    (e.Item.FindControl("ltrCost") as Literal).Text = change.Cost.ToStringSafe();
                    (e.Item.FindControl("ltrQuantityDeleteReq") as Literal).Text = change.QuantityDeleteReq.ToStringSafe();
                    (e.Item.FindControl("ltrQuantityDeleteAuth") as Literal).Text = change.QuantityDeleteAuth.ToStringSafe();
                    (e.Item.FindControl("ltrUIC") as Literal).Text = change.UIC;
                    (e.Item.FindControl("ltrTDANumber") as Literal).Text = change.TDANumber;
                    (e.Item.FindControl("ltrCCNumber") as Literal).Text = change.CCNumber;
                    (e.Item.FindControl("imgAssetTrfYes") as Image).Visible = change.AssetTrf == true;
                    (e.Item.FindControl("imgAssetTrfNo") as Image).Visible = change.AssetTrf == false;
                    (e.Item.FindControl("ltrRemarks") as Literal).Text = change.Remarks;
                    (e.Item.FindControl("imbEditOtherItemDeletion") as ImageButton).CommandArgument = change.ListIndex.ToString();
                    (e.Item.FindControl("imbDeleteOtherItemDeletion") as ImageButton).CommandArgument = change.ListIndex.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditOtherItemDeletion_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedOtherItemDeletion = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                Presenter.LoadOtherItemDeletion();
                mpEditOtherItemDeletion.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbDeleteOtherItemDeletion_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedOtherItemDeletion = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                mpDeleteOtherItemDeletionConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddOtherItemDeletion_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedOtherItemDeletion = null;
                Presenter.LoadOtherItemDeletion();
                mpEditOtherItemDeletion.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveOtherItemDeletion_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveOtherItemDeletion();
                mpEditOtherItemDeletion.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelOtherItemDeletion_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditOtherItemDeletion.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteOtherItemDeletionConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteOtherItemDeletion();
                mpDeleteOtherItemDeletionConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteOtherItemDeletionCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteOtherItemDeletionConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dlPositionChanges_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                if (e.Item.DataItem is Form4610RPositionChange)
                {
                    Form4610RPositionChange change = e.Item.DataItem as Form4610RPositionChange;

                    (e.Item.FindControl("ltrItem") as Literal).Text = (e.Item.ItemIndex + 1).ToString();
                    (e.Item.FindControl("ltrParagraphNumber") as Literal).Text = change.ParagraphNumber;
                    (e.Item.FindControl("ltrLineNumber") as Literal).Text = change.LineNumber;
                    (e.Item.FindControl("ltrPositionAdd") as Literal).Text = change.PositionAdd.ToStringSafe();
                    (e.Item.FindControl("ltrPositionDelete") as Literal).Text = change.PositionDelete.ToStringSafe();
                    (e.Item.FindControl("ltrDescription") as Literal).Text = change.Description;
                    (e.Item.FindControl("ltrGR") as Literal).Text = change.GR;
                    (e.Item.FindControl("ltrMOS") as Literal).Text = change.MOS;
                    (e.Item.FindControl("ltrASILIC") as Literal).Text = change.ASILIC;
                    (e.Item.FindControl("ltrBR") as Literal).Text = change.BR;
                    (e.Item.FindControl("ltrID") as Literal).Text = change.ID;
                    (e.Item.FindControl("ltrAMSC") as Literal).Text = change.AMSC;
                    (e.Item.FindControl("ltrNewRecapQtyReq") as Literal).Text = change.QuantityRecapReq.ToStringSafe();
                    (e.Item.FindControl("ltrNewRecapQtyAuth") as Literal).Text = change.QuantityRecapAuth.ToStringSafe();
                    (e.Item.FindControl("imbEditPositionChange") as ImageButton).CommandArgument = change.ListIndex.ToString();
                    (e.Item.FindControl("imbDeletePositionChange") as ImageButton).CommandArgument = change.ListIndex.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbEditPositionChange_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedPositionChange = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                Presenter.LoadPositionChange();
                mpEditPositionChange.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void imbDeletePositionChange_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedPositionChange = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                mpDeletePositionChangeConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnAddPositionChange_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedPositionChange = null;
                Presenter.LoadPositionChange();
                mpEditPositionChange.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSavePositionChange_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SavePositionChange();
                mpEditPositionChange.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelPositionChange_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditPositionChange.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeletePositionChangeConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeletePositionChange();
                mpDeletePositionChangeConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeletePositionChangeCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeletePositionChangeConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        internal override void SetEnabledState(Boolean enabled)
        {
            txtTitle.Enabled = enabled;
            txtUIC.Enabled = enabled;
            txtUnit.Enabled = enabled;
            txtTDANumber.Enabled = enabled;
            txtCCNumber.Enabled = enabled;

            dlItemChanges.Enabled = enabled;
            btnAddItemChange.Visible = enabled;

            dlOtherItemDeletions.Enabled = enabled;
            btnAddOtherItemDeletion.Visible = enabled;

            dlPositionChanges.Enabled = enabled;
            btnAddPositionChange.Visible = enabled;

            hteJustification.Enabled = enabled;
        }

        public String Title
        {
            get
            {
                return txtTitle.Text;
            }
            set
            {
                txtTitle.Text = value;
            }
        }

        public String UIC
        {
            get
            {
                return txtUIC.Text;
            }
            set
            {
                txtUIC.Text = value;
            }
        }

        public String UnitDesignation
        {
            get
            {
                return txtUnit.Text;
            }
            set
            {
                txtUnit.Text = value;
            }
        }

        public String TDANumber
        {
            get
            {
                return txtTDANumber.Text;
            }
            set
            {
                txtTDANumber.Text = value;
            }
        }

        public String CCNumber
        {
            get
            {
                return txtCCNumber.Text;
            }
            set
            {
                txtCCNumber.Text = value;
            }
        }

        public IList<Form4610RItemChange> ItemChanges
        {
            get
            {
                return this.ViewState["ItemChanges"] as IList<Form4610RItemChange>;
            }
            set
            {
                this.ViewState["ItemChanges"] = value;

                dlItemChanges.DataSource = value;
                dlItemChanges.DataBind();
            }
        }

        public Nullable<Int32> SelectedItemChange
        {
            get
            {
                return this.ViewState["SelectedItemChange"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["SelectedItemChange"] = value;
            }
        }

        public IList<Form4610RItemOtherDelete> OtherItemDeletions
        {
            get
            {
                return this.ViewState["OtherItemDeletions"] as IList<Form4610RItemOtherDelete>;
            }
            set
            {
                this.ViewState["OtherItemDeletions"] = value;

                dlOtherItemDeletions.DataSource = value;
                dlOtherItemDeletions.DataBind();
            }
        }

        public Nullable<Int32> SelectedOtherItemDeletion
        {
            get
            {
                return this.ViewState["SelectedOtherItemDeletion"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["SelectedOtherItemDeletion"] = value;
            }
        }

        public IList<Form4610RPositionChange> PositionChanges
        {
            get
            {
                return this.ViewState["PositionChanges"] as IList<Form4610RPositionChange>;
            }
            set
            {
                this.ViewState["PositionChanges"] = value;

                dlPositionChanges.DataSource = value;
                dlPositionChanges.DataBind();
            }
        }

        public Nullable<Int32> SelectedPositionChange
        {
            get
            {
                return this.ViewState["SelectedPositionChange"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["SelectedPositionChange"] = value;
            }
        }

        public String Justification
        {
            get
            {
                return hteJustification.Text;
            }
            set
            {
                hteJustification.Text = value;
            }
        }

        public String ItemParagraphNumber
        {
            get
            {
                return txtItemParagraphNumber.Text;
            }
            set
            {
                txtItemParagraphNumber.Text = value;
            }
        }

        public String ItemLineNumber
        {
            get
            {
                return txtItemLineNumber.Text;
            }
            set
            {
                txtItemLineNumber.Text = value;
            }
        }

        public String ItemERC
        {
            get
            {
                return txtItemERC.Text;
            }
            set
            {
                txtItemERC.Text = value;
            }
        }

        public String ItemChapter
        {
            get
            {
                return txtItemChapter.Text;
            }
            set
            {
                txtItemChapter.Text = value;
            }
        }

        public String ItemNomenclature
        {
            get
            {
                return txtItemNomenclature.Text;
            }
            set
            {
                txtItemNomenclature.Text = value;
            }
        }

        public Nullable<Decimal> ItemCost
        {
            get
            {
                return txtItemCost.Text.ToNullable<Decimal>();
            }
            set
            {
                txtItemCost.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> ItemQuantityAddReq
        {
            get
            {
                return txtItemQuantityAddReq.Text.ToNullable<Int16>();
            }
            set
            {
                txtItemQuantityAddReq.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> ItemQuantityAddAuth
        {
            get
            {
                return txtItemQuantityAddAuth.Text.ToNullable<Int16>();
            }
            set
            {
                txtItemQuantityAddAuth.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> ItemQuantityDeleteReq
        {
            get
            {
                return txtItemQuantityDeleteReq.Text.ToNullable<Int16>();
            }
            set
            {
                txtItemQuantityDeleteReq.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> ItemQuantityDeleteAuth
        {
            get
            {
                return txtItemQuantityDeleteAuth.Text.ToNullable<Int16>();
            }
            set
            {
                txtItemQuantityDeleteAuth.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> ItemNewParaQtyReq
        {
            get
            {
                return txtItemNewParaQtyReq.Text.ToNullable<Int16>();
            }
            set
            {
                txtItemNewParaQtyReq.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> ItemNewParaQtyAuth
        {
            get
            {
                return txtItemNewParaQtyAuth.Text.ToNullable<Int16>();
            }
            set
            {
                txtItemNewParaQtyAuth.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> ItemNewRecapQtyReq
        {
            get
            {
                return txtItemNewRecapQtyReq.Text.ToNullable<Int16>();
            }
            set
            {
                txtItemNewRecapQtyReq.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> ItemNewRecapQtyAuth
        {
            get
            {
                return txtItemNewRecapQtyAuth.Text.ToNullable<Int16>();
            }
            set
            {
                txtItemNewRecapQtyAuth.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> ItemQtyOnHand
        {
            get
            {
                return txtItemQtyOnHand.Text.ToNullable<Int16>();
            }
            set
            {
                txtItemQtyOnHand.Text = value.ToStringSafe();
            }
        }

        public String OtherItemParagraphNumber
        {
            get
            {
                return txtOtherItemParagraphNumber.Text;
            }
            set
            {
                txtOtherItemParagraphNumber.Text = value;
            }
        }

        public String OtherItemLineNumber
        {
            get
            {
                return txtOtherItemLineNumber.Text;
            }
            set
            {
                txtOtherItemLineNumber.Text = value;
            }
        }

        public String OtherItemERC
        {
            get
            {
                return txtOtherItemERC.Text;
            }
            set
            {
                txtOtherItemERC.Text = value;
            }
        }

        public String OtherItemChapter
        {
            get
            {
                return txtOtherItemChapter.Text;
            }
            set
            {
                txtOtherItemChapter.Text = value;
            }
        }

        public String OtherItemNomenclature
        {
            get
            {
                return txtOtherItemNomenclature.Text;
            }
            set
            {
                txtOtherItemNomenclature.Text = value;
            }
        }

        public Nullable<Decimal> OtherItemCost
        {
            get
            {
                return txtOtherItemCost.Text.ToNullable<Decimal>();
            }
            set
            {
                txtOtherItemCost.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> OtherItemQuantityDeleteReq
        {
            get
            {
                return txtOtherItemQuantityDeleteReq.Text.ToNullable<Int16>();
            }
            set
            {
                txtOtherItemQuantityDeleteReq.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> OtherItemQuantityDeleteAuth
        {
            get
            {
                return txtOtherItemQuantityDeleteAuth.Text.ToNullable<Int16>();
            }
            set
            {
                txtOtherItemQuantityDeleteAuth.Text = value.ToStringSafe();
            }
        }

        public String OtherItemUIC
        {
            get
            {
                return txtOtherItemUIC.Text;
            }
            set
            {
                txtOtherItemUIC.Text = value;
            }
        }

        public String OtherItemTDANumber
        {
            get
            {
                return txtOtherItemTDANumber.Text;
            }
            set
            {
                txtOtherItemTDANumber.Text = value;
            }
        }

        public String OtherItemCCNumber
        {
            get
            {
                return txtOtherItemCCNumber.Text;
            }
            set
            {
                txtOtherItemCCNumber.Text = value;
            }
        }

        public Nullable<Boolean> OtherItemAssetTrf
        {
            get
            {
                return rblOtherItemAssetTrf.SelectedValue.ToNullable<Boolean>();
            }
            set
            {
                rblOtherItemAssetTrf.SelectedValue = value.ToStringSafe();
            }
        }

        public String OtherItemRemarks
        {
            get
            {
                return txtOtherItemRemarks.Text;
            }
            set
            {
                txtOtherItemRemarks.Text = value;
            }
        }

        public String PositionParagraphNumber
        {
            get
            {
                return txtPositionParagraphNumber.Text;
            }
            set
            {
                txtPositionParagraphNumber.Text = value;
            }
        }

        public String PositionLineNumber
        {
            get
            {
                return txtPositionLineNumber.Text;
            }
            set
            {
                txtPositionLineNumber.Text = value;
            }
        }

        public Nullable<Int16> PositionCountAdd
        {
            get
            {
                return txtPositionCountAdd.Text.ToNullable<Int16>();
            }
            set
            {
                txtPositionCountAdd.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> PositionCountDelete
        {
            get
            {
                return txtPositionCountDelete.Text.ToNullable<Int16>();
            }
            set
            {
                txtPositionCountDelete.Text = value.ToStringSafe();
            }
        }

        public String PositionDescription
        {
            get
            {
                return txtPositionDescription.Text;
            }
            set
            {
                txtPositionDescription.Text = value;
            }
        }

        public String PositionGR
        {
            get
            {
                return txtPositionGR.Text;
            }
            set
            {
                txtPositionGR.Text = value;
            }
        }

        public String PositionMOS
        {
            get
            {
                return txtPositionMOS.Text;
            }
            set
            {
                txtPositionMOS.Text = value;
            }
        }

        public String PositionASILIC
        {
            get
            {
                return txtPositionASILIC.Text;
            }
            set
            {
                txtPositionASILIC.Text = value;
            }
        }

        public String PositionBR
        {
            get
            {
                return txtPositionBR.Text;
            }
            set
            {
                txtPositionBR.Text = value;
            }
        }

        public String PositionID
        {
            get
            {
                return txtPositionID.Text;
            }
            set
            {
                txtPositionID.Text = value;
            }
        }

        public String PositionAMSC
        {
            get
            {
                return txtPositionAMSC.Text;
            }
            set
            {
                txtPositionAMSC.Text = value;
            }
        }

        public Nullable<Int16> PositionNewRecapQtyReq
        {
            get
            {
                return txtPositionNewRecapQtyReq.Text.ToNullable<Int16>();
            }
            set
            {
                txtPositionNewRecapQtyReq.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int16> PositionNewRecapQtyAuth
        {
            get
            {
                return txtPositionNewRecapQtyAuth.Text.ToNullable<Int16>();
            }
            set
            {
                txtPositionNewRecapQtyAuth.Text = value.ToStringSafe();
            }
        }
    }
}