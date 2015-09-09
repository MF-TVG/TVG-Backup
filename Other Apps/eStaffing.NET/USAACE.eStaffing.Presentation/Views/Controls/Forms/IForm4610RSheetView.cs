using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;

namespace USAACE.eStaffing.Presentation.Views.Controls.Forms
{
    public interface IForm4610RSheetView : IFormControlView
    {
        String Title { get; set; }

        String UIC { get; set; }

        String UnitDesignation { get; set; }

        String TDANumber { get; set; }

        String CCNumber { get; set; }

        IList<Form4610RItemChange> ItemChanges { get; set; }

        Nullable<Int32> SelectedItemChange { get; set; }

        IList<Form4610RItemOtherDelete> OtherItemDeletions { get; set; }

        Nullable<Int32> SelectedOtherItemDeletion { get; set; }

        IList<Form4610RPositionChange> PositionChanges { get; set; }

        Nullable<Int32> SelectedPositionChange { get; set; }

        String Justification { get; set; }

        String ItemParagraphNumber { get; set; }

        String ItemLineNumber { get; set; }

        String ItemERC { get; set; }

        String ItemChapter { get; set; }

        String ItemNomenclature { get; set; }

        Nullable<Decimal> ItemCost { get; set; }

        Nullable<Int16> ItemQuantityAddReq { get; set; }

        Nullable<Int16> ItemQuantityAddAuth { get; set; }

        Nullable<Int16> ItemQuantityDeleteReq { get; set; }

        Nullable<Int16> ItemQuantityDeleteAuth { get; set; }

        Nullable<Int16> ItemNewParaQtyReq { get; set; }

        Nullable<Int16> ItemNewParaQtyAuth { get; set; }

        Nullable<Int16> ItemNewRecapQtyReq { get; set; }

        Nullable<Int16> ItemNewRecapQtyAuth { get; set; }

        Nullable<Int16> ItemQtyOnHand { get; set; }

        String OtherItemParagraphNumber { get; set; }

        String OtherItemLineNumber { get; set; }

        String OtherItemERC { get; set; }

        String OtherItemChapter { get; set; }

        String OtherItemNomenclature { get; set; }

        Nullable<Decimal> OtherItemCost { get; set; }

        Nullable<Int16> OtherItemQuantityDeleteReq { get; set; }

        Nullable<Int16> OtherItemQuantityDeleteAuth { get; set; }

        String OtherItemUIC { get; set; }

        String OtherItemTDANumber { get; set; }

        String OtherItemCCNumber { get; set; }

        Nullable<Boolean> OtherItemAssetTrf { get; set; }

        String OtherItemRemarks { get; set; }

        String PositionParagraphNumber { get; set; }

        String PositionLineNumber { get; set; }

        Nullable<Int16> PositionCountAdd { get; set; }

        Nullable<Int16> PositionCountDelete { get; set; }

        String PositionDescription { get; set; }

        String PositionGR { get; set; }

        String PositionMOS { get; set; }

        String PositionASILIC { get; set; }

        String PositionBR { get; set; }

        String PositionID { get; set; }

        String PositionAMSC { get; set; }

        Nullable<Int16> PositionNewRecapQtyReq { get; set; }

        Nullable<Int16> PositionNewRecapQtyAuth { get; set; }
    }
}
