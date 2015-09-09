using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;

namespace USAACE.eStaffing.Presentation.Presenters.Controls.Forms
{
    public class Form4610RSheetPresenter : BasePresenter
    {
        /// <summary>
        /// The IForm4610RSheetView for the Form4610RSheetPresenter
        /// </summary>
        private new IForm4610RSheetView View
        {
            get
            {
                return base.View as IForm4610RSheetView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IForm4610RSheetView
        /// </summary>
        /// <param name="view">The IForm4610RSheetView</param>
        public Form4610RSheetPresenter(IForm4610RSheetView view)
        {
            base.View = view;
        }

        public void Load()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                Form4610R form4610r = FormDataUtil.LoadSpecificFormData<Form4610R>(formData);

                this.View.Title = form4610r.Title;
                this.View.UIC = form4610r.UIC;
                this.View.UnitDesignation = form4610r.Unit;
                this.View.TDANumber = form4610r.TDANumber;
                this.View.CCNumber = form4610r.CCNumber;
                this.View.Justification = form4610r.Justification;

                this.View.ItemChanges = form4610r.ItemChanges;
                this.View.OtherItemDeletions = form4610r.ItemOtherDeletions;
                this.View.PositionChanges = form4610r.PositionChanges;
            }
        }

        public void Save()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                Form4610R form4610r = FormDataUtil.LoadSpecificFormData<Form4610R>(formData);

                form4610r.Title = this.View.Title;
                form4610r.UIC = this.View.UIC;
                form4610r.Unit = this.View.UnitDesignation;
                form4610r.TDANumber = this.View.TDANumber;
                form4610r.CCNumber = this.View.CCNumber;
                form4610r.Justification = this.View.Justification;

                form4610r.ItemChanges = (List<Form4610RItemChange>)this.View.ItemChanges;
                form4610r.ItemOtherDeletions = (List<Form4610RItemOtherDelete>)this.View.OtherItemDeletions;
                form4610r.PositionChanges = (List<Form4610RPositionChange>)this.View.PositionChanges;

                DataService.SaveFormData(formData, form4610r);

                Form form = new Form();
                form.FormID = this.View.FormID;

                form = DataService.LoadForm(form);

                FormUtil.SetFormTypeValues(form, form4610r);

                form = DataService.SaveForm(form);
            }

            Load();
        }

        public void LoadItemChange()
        {
            Form4610RItemChange change = this.View.SelectedItemChange.HasValue ?
                this.View.ItemChanges.FirstOrDefault(x => x.ListIndex == this.View.SelectedItemChange) :
                new Form4610RItemChange();

            this.View.ItemParagraphNumber = change.ParagraphNumber;
            this.View.ItemLineNumber = change.LineNumber;
            this.View.ItemERC = change.ERC;
            this.View.ItemChapter = change.Chapter;
            this.View.ItemNomenclature = change.Nomenclature;
            this.View.ItemCost = change.Cost;
            this.View.ItemQuantityAddReq = change.QuantityAddReq;
            this.View.ItemQuantityAddAuth = change.QuantityAddAuth;
            this.View.ItemQuantityDeleteReq = change.QuantityDeleteReq;
            this.View.ItemQuantityDeleteAuth = change.QuantityDeleteAuth;
            this.View.ItemNewParaQtyReq = change.QuantityNewParaReq;
            this.View.ItemNewParaQtyAuth = change.QuantityNewParaAuth;
            this.View.ItemNewRecapQtyReq = change.QuantityRecapReq;
            this.View.ItemNewRecapQtyAuth = change.QuantityRecapAuth;
            this.View.ItemQtyOnHand = change.QuantityNotAuth;
        }

        public void SaveItemChange()
        {
            IList<Form4610RItemChange> changes = this.View.ItemChanges;

            Form4610RItemChange change = this.View.SelectedItemChange.HasValue ?
                changes.FirstOrDefault(x => x.ListIndex == this.View.SelectedItemChange) :
                new Form4610RItemChange { ListIndex = changes.Count > 0 ? changes.Last().ListIndex + 1 : 0 };

            change.ParagraphNumber = this.View.ItemParagraphNumber;
            change.LineNumber = this.View.ItemLineNumber;
            change.ERC = this.View.ItemERC;
            change.Chapter = this.View.ItemChapter;
            change.Nomenclature = this.View.ItemNomenclature;
            change.Cost = this.View.ItemCost;
            change.QuantityAddReq = this.View.ItemQuantityAddReq;
            change.QuantityAddAuth = this.View.ItemQuantityAddAuth;
            change.QuantityDeleteReq = this.View.ItemQuantityDeleteReq;
            change.QuantityDeleteAuth = this.View.ItemQuantityDeleteAuth;
            change.QuantityNewParaReq = this.View.ItemNewParaQtyReq;
            change.QuantityNewParaAuth = this.View.ItemNewParaQtyAuth;
            change.QuantityRecapReq = this.View.ItemNewRecapQtyReq;
            change.QuantityRecapAuth = this.View.ItemNewRecapQtyAuth;
            change.QuantityNotAuth = this.View.ItemQtyOnHand;

            if (this.View.SelectedItemChange.HasValue == false)
            {
                changes.Add(change);
            }

            this.View.ItemChanges = changes;
        }

        public void DeleteItemChange()
        {
            if (this.View.SelectedItemChange.HasValue)
            {
                IList<Form4610RItemChange> changes = this.View.ItemChanges;

                Form4610RItemChange change = changes.FirstOrDefault(x => x.ListIndex == this.View.SelectedItemChange);

                changes.Remove(change);

                this.View.ItemChanges = changes;
            }
        }

        public void LoadOtherItemDeletion()
        {
            Form4610RItemOtherDelete otherDeletion = this.View.SelectedOtherItemDeletion.HasValue ?
                this.View.OtherItemDeletions.FirstOrDefault(x => x.ListIndex == this.View.SelectedOtherItemDeletion) :
                new Form4610RItemOtherDelete();

            this.View.OtherItemParagraphNumber = otherDeletion.ParagraphNumber;
            this.View.OtherItemLineNumber = otherDeletion.LineNumber;
            this.View.OtherItemERC = otherDeletion.ERC;
            this.View.OtherItemChapter = otherDeletion.Chapter;
            this.View.OtherItemNomenclature = otherDeletion.Nomenclature;
            this.View.OtherItemCost = otherDeletion.Cost;
            this.View.OtherItemQuantityDeleteReq = otherDeletion.QuantityDeleteReq;
            this.View.OtherItemQuantityDeleteAuth = otherDeletion.QuantityDeleteAuth;
            this.View.OtherItemUIC = otherDeletion.UIC;
            this.View.OtherItemTDANumber = otherDeletion.TDANumber;
            this.View.OtherItemCCNumber = otherDeletion.CCNumber;
            this.View.OtherItemAssetTrf = otherDeletion.AssetTrf;
            this.View.OtherItemRemarks = otherDeletion.Remarks;
        }

        public void SaveOtherItemDeletion()
        {
            IList<Form4610RItemOtherDelete> otherDeletions = this.View.OtherItemDeletions;

            Form4610RItemOtherDelete otherDeletion = this.View.SelectedOtherItemDeletion.HasValue ?
                otherDeletions.FirstOrDefault(x => x.ListIndex == this.View.SelectedOtherItemDeletion) :
                new Form4610RItemOtherDelete { ListIndex = otherDeletions.Count > 0 ? otherDeletions.Last().ListIndex + 1 : 0 };

            otherDeletion.ParagraphNumber = this.View.OtherItemParagraphNumber;
            otherDeletion.LineNumber = this.View.OtherItemLineNumber;
            otherDeletion.ERC = this.View.OtherItemERC;
            otherDeletion.Chapter = this.View.OtherItemChapter;
            otherDeletion.Nomenclature = this.View.OtherItemNomenclature;
            otherDeletion.Cost = this.View.OtherItemCost;
            otherDeletion.QuantityDeleteReq = this.View.OtherItemQuantityDeleteReq;
            otherDeletion.QuantityDeleteAuth = this.View.OtherItemQuantityDeleteAuth;
            otherDeletion.UIC = this.View.OtherItemUIC;
            otherDeletion.TDANumber = this.View.OtherItemTDANumber;
            otherDeletion.CCNumber = this.View.OtherItemCCNumber;
            otherDeletion.AssetTrf = this.View.OtherItemAssetTrf;
            otherDeletion.Remarks = this.View.OtherItemRemarks;

            if (this.View.SelectedOtherItemDeletion.HasValue == false)
            {
                otherDeletions.Add(otherDeletion);
            }

            this.View.OtherItemDeletions = otherDeletions;
        }

        public void DeleteOtherItemDeletion()
        {
            if (this.View.SelectedOtherItemDeletion.HasValue)
            {
                IList<Form4610RItemOtherDelete> otherDeletions = this.View.OtherItemDeletions;

                Form4610RItemOtherDelete otherDelete = otherDeletions.FirstOrDefault(x => x.ListIndex == this.View.SelectedOtherItemDeletion);

                otherDeletions.Remove(otherDelete);

                this.View.OtherItemDeletions = otherDeletions;
            }
        }

        public void LoadPositionChange()
        {
            Form4610RPositionChange change = this.View.SelectedPositionChange.HasValue ?
                this.View.PositionChanges.FirstOrDefault(x => x.ListIndex == this.View.SelectedPositionChange) :
                new Form4610RPositionChange();

            this.View.PositionParagraphNumber = change.ParagraphNumber;
            this.View.PositionLineNumber = change.LineNumber;
            this.View.PositionCountAdd = change.PositionAdd;
            this.View.PositionCountDelete = change.PositionDelete;
            this.View.PositionDescription = change.Description;
            this.View.PositionGR = change.GR;
            this.View.PositionMOS = change.MOS;
            this.View.PositionASILIC = change.ASILIC;
            this.View.PositionBR = change.BR;
            this.View.PositionID = change.ID;
            this.View.PositionAMSC = change.AMSC;
            this.View.PositionNewRecapQtyReq = change.QuantityRecapReq;
            this.View.PositionNewRecapQtyAuth = change.QuantityRecapAuth;
        }

        public void SavePositionChange()
        {
            IList<Form4610RPositionChange> changes = this.View.PositionChanges;

            Form4610RPositionChange change = this.View.SelectedPositionChange.HasValue ?
                changes.FirstOrDefault(x => x.ListIndex == this.View.SelectedPositionChange) :
                new Form4610RPositionChange { ListIndex = changes.Count > 0 ? changes.Last().ListIndex + 1 : 0 };

            change.ParagraphNumber = this.View.PositionParagraphNumber;
            change.LineNumber = this.View.PositionLineNumber;
            change.PositionAdd = this.View.PositionCountAdd;
            change.PositionDelete = this.View.PositionCountDelete;
            change.Description = this.View.PositionDescription;
            change.GR = this.View.PositionGR;
            change.MOS = this.View.PositionMOS;
            change.ASILIC = this.View.PositionASILIC;
            change.BR = this.View.PositionBR;
            change.ID = this.View.PositionID;
            change.AMSC = this.View.PositionAMSC;
            change.QuantityRecapReq = this.View.PositionNewRecapQtyReq;
            change.QuantityRecapAuth = this.View.PositionNewRecapQtyAuth;

            if (this.View.SelectedPositionChange.HasValue == false)
            {
                changes.Add(change);
            }

            this.View.PositionChanges = changes;
        }

        public void DeletePositionChange()
        {
            if (this.View.SelectedPositionChange.HasValue)
            {
                IList<Form4610RPositionChange> changes = this.View.PositionChanges;

                Form4610RPositionChange change = changes.FirstOrDefault(x => x.ListIndex == this.View.SelectedPositionChange);

                changes.Remove(change);

                this.View.PositionChanges = changes;
            }

        }

        public void SaveDefault()
        {
            Form4610R form4610r = new Form4610R();

            form4610r.Title = this.View.Title;
            form4610r.UIC = this.View.UIC;
            form4610r.Unit = this.View.UnitDesignation;
            form4610r.TDANumber = this.View.TDANumber;
            form4610r.CCNumber = this.View.CCNumber;
            form4610r.Justification = this.View.Justification;

            form4610r.ItemChanges = (List<Form4610RItemChange>)this.View.ItemChanges;
            form4610r.ItemOtherDeletions = (List<Form4610RItemOtherDelete>)this.View.OtherItemDeletions;
            form4610r.PositionChanges = (List<Form4610RPositionChange>)this.View.PositionChanges;

            OrganizationFormDefault formDefault = new OrganizationFormDefault();
            formDefault.OrganizationGroupID = this.View.SubmitGroupID;
            formDefault.FormTypeID = this.View.FormTypeID;

            DataService.SaveOrganizationFormDefault(formDefault, form4610r);
        }
    }
}
