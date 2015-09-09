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
    public class TransmittalSheetPresenter : BasePresenter
    {
        /// <summary>
        /// The ITransmittalSheetView for the TransmittalSheetPresenter
        /// </summary>
        private new ITransmittalSheetView View
        {
            get
            {
                return base.View as ITransmittalSheetView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ITransmittalSheetView
        /// </summary>
        /// <param name="view">The ITransmittalSheetView</param>
        public TransmittalSheetPresenter(ITransmittalSheetView view)
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

                Transmittal transmittal = FormDataUtil.LoadSpecificFormData<Transmittal>(formData);

                this.View.IsTaskerResponse = transmittal.IsTaskerResponse;
                this.View.TaskerNumber = transmittal.TaskerNumber;
                this.View.Subject = transmittal.Subject;
                this.View.ActionOfficer = transmittal.ActionOfficer;
                this.View.OfficeSymbol = transmittal.OfficeSymbol;
                this.View.PhoneNumber = transmittal.PhoneNumber;
                this.View.SuspenseDate = transmittal.SuspenseDate;
                this.View.FormDate = transmittal.TransmittalDate;
                this.View.Signature = transmittal.Signature;
                this.View.Approval = transmittal.Approval;
                this.View.Information = transmittal.Information;
                this.View.ReadAhead = transmittal.ReadAhead;
                this.View.Other = transmittal.Other;
                this.View.OtherText = transmittal.OtherText;
                this.View.Recommendation = transmittal.Recommendation;
                this.View.RecommendationCSM = transmittal.RecommendationCSM;
                this.View.RecommendationCPG = transmittal.RecommendationCPG;
                this.View.RecommendationDCOS = transmittal.RecommendationDCOS;
                this.View.RecommendationDCG = transmittal.RecommendationDCG;
                this.View.RecommendationCG = transmittal.RecommendationCG;
                this.View.Discussion = transmittal.Discussion;
                this.View.KeyAreaFunding = transmittal.KeyAreaFunding;
                this.View.KeyAreaPolicy = transmittal.KeyAreaPolicy;
                this.View.KeyAreaEquipment = transmittal.KeyAreaEquipment;
                this.View.KeyAreaLegal = transmittal.KeyAreaLegal;
                this.View.KeyAreaTraining = transmittal.KeyAreaTraining;
                this.View.KeyAreaPersonnel = transmittal.KeyAreaPersonnel;
                this.View.KeyAreaCongressional = transmittal.KeyAreaCongressional;
                this.View.KeyAreaStrategy = transmittal.KeyAreaStrategy;
                this.View.KeyAreaOther = transmittal.KeyAreaOther;
                this.View.KeyAreaOtherText = transmittal.KeyAreaOtherText;
                this.View.PrincipalComments = transmittal.PrincipalComments;

                IList<TransmittalCoord> coords = transmittal.TransmittalCoords;

                this.View.Coordinations = coords;
            }

            ShowTaskerNumber();
            ShowOtherText();
            ShowKeyAreaOtherText();
        }

        public void Save()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                Transmittal transmittal = FormDataUtil.LoadSpecificFormData<Transmittal>(formData);

                transmittal.IsTaskerResponse = this.View.IsTaskerResponse;
                transmittal.TaskerNumber = this.View.TaskerNumber;
                transmittal.Subject = this.View.Subject;
                transmittal.ActionOfficer = this.View.ActionOfficer;
                transmittal.OfficeSymbol = this.View.OfficeSymbol;
                transmittal.PhoneNumber = this.View.PhoneNumber;
                transmittal.SuspenseDate = this.View.SuspenseDate;
                transmittal.TransmittalDate = this.View.FormDate;
                transmittal.Signature = this.View.Signature;
                transmittal.Approval = this.View.Approval;
                transmittal.Information = this.View.Information;
                transmittal.ReadAhead = this.View.ReadAhead;
                transmittal.Other = this.View.Other;
                transmittal.OtherText = this.View.OtherText;
                transmittal.Recommendation = this.View.Recommendation;
                transmittal.RecommendationCSM = this.View.RecommendationCSM;
                transmittal.RecommendationCPG = this.View.RecommendationCPG;
                transmittal.RecommendationDCOS = this.View.RecommendationDCOS;
                transmittal.RecommendationDCG = this.View.RecommendationDCG;
                transmittal.RecommendationCG = this.View.RecommendationCG;
                transmittal.Discussion = this.View.Discussion;
                transmittal.KeyAreaFunding = this.View.KeyAreaFunding;
                transmittal.KeyAreaPolicy = this.View.KeyAreaPolicy;
                transmittal.KeyAreaEquipment = this.View.KeyAreaEquipment;
                transmittal.KeyAreaLegal = this.View.KeyAreaLegal;
                transmittal.KeyAreaTraining = this.View.KeyAreaTraining;
                transmittal.KeyAreaPersonnel = this.View.KeyAreaPersonnel;
                transmittal.KeyAreaCongressional = this.View.KeyAreaCongressional;
                transmittal.KeyAreaStrategy = this.View.KeyAreaStrategy;
                transmittal.KeyAreaOther = this.View.KeyAreaOther;
                transmittal.KeyAreaOtherText = this.View.KeyAreaOtherText;
                transmittal.PrincipalComments = this.View.PrincipalComments;

                transmittal.TransmittalCoords = (List<TransmittalCoord>)this.View.Coordinations;

                DataService.SaveFormData(formData, transmittal);

                Form form = new Form();
                form.FormID = this.View.FormID;

                form = DataService.LoadForm(form);

                FormUtil.SetFormTypeValues(form, transmittal);

                form = DataService.SaveForm(form);
            }

            Load();
        }

        public void ShowTaskerNumber()
        {
            this.View.ShowTaskerNumber = this.View.IsTaskerResponse == true;
        }

        public void ShowOtherText()
        {
            this.View.ShowOtherText = this.View.Other == true;
        }

        public void ShowKeyAreaOtherText()
        {
            this.View.ShowKeyAreaOtherText = this.View.KeyAreaOther == true;
        }

        public void LoadCoord()
        {
            if (this.View.SelectedCoordID.HasValue)
            {
                IList<TransmittalCoord> coords = this.View.Coordinations;

                TransmittalCoord coord = coords.FirstOrDefault(x => x.ListIndex == this.View.SelectedCoordID);

                this.View.CoordResponse = coord.Concur;
                this.View.CoordAgency = coord.Agency;
                this.View.CoordName = coord.Name;
                this.View.CoordPhone = coord.Phone;
                this.View.CoordDate = coord.CoordDate;
                this.View.CoordRemarks = coord.Remarks;
            }
            else
            {
                this.View.CoordResponse = null;
                this.View.CoordAgency = null;
                this.View.CoordName = null;
                this.View.CoordPhone = null;
                this.View.CoordDate = null;
                this.View.CoordRemarks = null;
            }
        }

        public void SaveCoord()
        {
            IList<TransmittalCoord> coords = this.View.Coordinations;

            TransmittalCoord coord = this.View.SelectedCoordID.HasValue ?
                coords.FirstOrDefault(x => x.ListIndex == this.View.SelectedCoordID) :
                new TransmittalCoord { ListIndex = coords.Count > 0 ? coords.Last().ListIndex + 1 : 0 };

            coord.Concur = this.View.CoordResponse;
            coord.Agency = this.View.CoordAgency;
            coord.Name = this.View.CoordName;
            coord.Phone = this.View.CoordPhone;
            coord.CoordDate = this.View.CoordDate;
            coord.Remarks = this.View.CoordRemarks;

            if (this.View.SelectedCoordID.HasValue == false)
            {
                coords.Add(coord);
            }

            this.View.Coordinations = coords;
        }

        public void DeleteCoord()
        {
            if (this.View.SelectedCoordID.HasValue)
            {
                IList<TransmittalCoord> coords = this.View.Coordinations;

                TransmittalCoord coord = coords.FirstOrDefault(x => x.ListIndex == this.View.SelectedCoordID);

                coords.Remove(coord);

                this.View.Coordinations = coords;
            }
        }

        public void SaveDefault()
        {
            Transmittal transmittal = new Transmittal();

            transmittal.IsTaskerResponse = this.View.IsTaskerResponse;
            transmittal.TaskerNumber = this.View.TaskerNumber;
            transmittal.Subject = this.View.Subject;
            transmittal.ActionOfficer = this.View.ActionOfficer;
            transmittal.OfficeSymbol = this.View.OfficeSymbol;
            transmittal.PhoneNumber = this.View.PhoneNumber;
            transmittal.SuspenseDate = this.View.SuspenseDate;
            transmittal.TransmittalDate = this.View.FormDate;
            transmittal.Signature = this.View.Signature;
            transmittal.Approval = this.View.Approval;
            transmittal.Information = this.View.Information;
            transmittal.ReadAhead = this.View.ReadAhead;
            transmittal.Other = this.View.Other;
            transmittal.OtherText = this.View.OtherText;
            transmittal.Recommendation = this.View.Recommendation;
            transmittal.RecommendationCSM = this.View.RecommendationCSM;
            transmittal.RecommendationCPG = this.View.RecommendationCPG;
            transmittal.RecommendationDCOS = this.View.RecommendationDCOS;
            transmittal.RecommendationDCG = this.View.RecommendationDCG;
            transmittal.RecommendationCG = this.View.RecommendationCG;
            transmittal.Discussion = this.View.Discussion;
            transmittal.KeyAreaFunding = this.View.KeyAreaFunding;
            transmittal.KeyAreaPolicy = this.View.KeyAreaPolicy;
            transmittal.KeyAreaEquipment = this.View.KeyAreaEquipment;
            transmittal.KeyAreaLegal = this.View.KeyAreaLegal;
            transmittal.KeyAreaTraining = this.View.KeyAreaTraining;
            transmittal.KeyAreaPersonnel = this.View.KeyAreaPersonnel;
            transmittal.KeyAreaCongressional = this.View.KeyAreaCongressional;
            transmittal.KeyAreaStrategy = this.View.KeyAreaStrategy;
            transmittal.KeyAreaOther = this.View.KeyAreaOther;
            transmittal.KeyAreaOtherText = this.View.KeyAreaOtherText;
            transmittal.PrincipalComments = this.View.PrincipalComments;

            transmittal.TransmittalCoords = (List<TransmittalCoord>)this.View.Coordinations;

            OrganizationFormDefault formDefault = new OrganizationFormDefault();
            formDefault.OrganizationGroupID = this.View.SubmitGroupID;
            formDefault.FormTypeID = this.View.FormTypeID;

            DataService.SaveOrganizationFormDefault(formDefault, transmittal);
        }
    }
}
