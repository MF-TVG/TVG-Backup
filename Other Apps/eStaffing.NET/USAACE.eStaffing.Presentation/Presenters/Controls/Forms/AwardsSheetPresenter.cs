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
using USAACE.eStaffing.Domain.LookupEntities;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;

namespace USAACE.eStaffing.Presentation.Presenters.Controls.Forms
{
    public class AwardsSheetPresenter : BasePresenter
    {
        /// <summary>
        /// The IAwardsSheetView for the AwardsSheetPresenter
        /// </summary>
        private new IAwardsSheetView View
        {
            get
            {
                return base.View as IAwardsSheetView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the IAwardsSheetView
        /// </summary>
        /// <param name="view">The IAwardsSheetView</param>
        public AwardsSheetPresenter(IAwardsSheetView view)
        {
            base.View = view;
        }

        public void Initialize()
        {

        }

        public void Load()
        {
            LoadLookups();

            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                AwardSheet awardSheet = FormDataUtil.LoadSpecificFormData<AwardSheet>(formData);

                this.View.Name = awardSheet.Name;
                this.View.Organization = awardSheet.Unit;
                this.View.PresentationDate = awardSheet.PresentationDate;
                this.View.DutyPosition = awardSheet.PresentDutyPosition;
                this.View.PreviousAward = awardSheet.HighestAwardLevel;
                this.View.SoldierFlagged = awardSheet.SoldierFlagged;
                this.View.SoldierFlaggedReason = awardSheet.SoldierFlaggedReason;
                this.View.StationTime = awardSheet.StationTime;
                this.View.AwardReason = awardSheet.AwardReason;
                this.View.AwardLevel = awardSheet.AwardLevel;
                this.View.Height = awardSheet.Height;
                this.View.Weight = awardSheet.Weight;
                this.View.Age = awardSheet.Age;
                this.View.BodyFatAuth = awardSheet.BodyFatAuth;
                this.View.BodyFatHas = awardSheet.BodyFatHas;
                this.View.BodyFatGo = awardSheet.Go;
                this.View.APFTDate = awardSheet.APFTDate;
                this.View.APFTPass = awardSheet.APFTPass;
                this.View.Profile = awardSheet.APFTProfile;
                this.View.TotalServiceYears = awardSheet.TotalYearsService;
                this.View.KeyPositions = awardSheet.KeyPositions;
                this.View.CurrentPositions = awardSheet.CurrentPositions;
                this.View.CurrentAwards = awardSheet.CurrentAwards;
                this.View.LeaderComments = awardSheet.LeaderComments;
                this.View.SeniorNCOComments = awardSheet.SeniorNCOComments;
                this.View.UnitSignDate = awardSheet.UnitSignDate;
                this.View.UnitComments = awardSheet.UnitComments;
            }

            ShowSoldierFlaggedReason();
        }

        public void LoadLookups()
        {
            IList<AwardLevel> awardLevels = FormLookupUtil.LoadSpecificLookup<AwardLevel>(this.View.FormTypeID, this.View.SubmitOrganizationID, "AwardLevel");
            IList<AwardReason> awardReasons = FormLookupUtil.LoadSpecificLookup<AwardReason>(this.View.FormTypeID, this.View.SubmitOrganizationID, "AwardReason");

            this.View.PreviousAwards = awardLevels;
            this.View.AwardReasons = awardReasons;
            this.View.AwardLevels = awardLevels;
        }

        public void Save()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                AwardSheet awardSheet = FormDataUtil.LoadSpecificFormData<AwardSheet>(formData);

                awardSheet.Name = this.View.Name;
                awardSheet.Unit = this.View.Organization;
                awardSheet.PresentationDate = this.View.PresentationDate;
                awardSheet.PresentDutyPosition = this.View.DutyPosition;
                awardSheet.HighestAwardLevel = this.View.PreviousAward;
                awardSheet.SoldierFlagged = this.View.SoldierFlagged;
                awardSheet.SoldierFlaggedReason = this.View.SoldierFlaggedReason;
                awardSheet.StationTime = this.View.StationTime;
                awardSheet.AwardReason = this.View.AwardReason;
                awardSheet.AwardLevel = this.View.AwardLevel;
                awardSheet.Height = this.View.Height;
                awardSheet.Weight = this.View.Weight;
                awardSheet.Age = this.View.Age;
                awardSheet.BodyFatAuth = this.View.BodyFatAuth;
                awardSheet.BodyFatHas = this.View.BodyFatHas;
                awardSheet.Go = this.View.BodyFatGo;
                awardSheet.APFTDate = this.View.APFTDate;
                awardSheet.APFTPass = this.View.APFTPass;
                awardSheet.APFTProfile = this.View.Profile;
                awardSheet.TotalYearsService = this.View.TotalServiceYears;
                awardSheet.KeyPositions = this.View.KeyPositions;
                awardSheet.CurrentPositions = this.View.CurrentPositions;
                awardSheet.CurrentAwards = this.View.CurrentAwards;
                awardSheet.LeaderComments = this.View.LeaderComments;
                awardSheet.SeniorNCOComments = this.View.SeniorNCOComments;
                awardSheet.UnitSignDate = this.View.UnitSignDate;
                awardSheet.UnitComments = this.View.UnitComments;

                DataService.SaveFormData(formData, awardSheet);

                Form form = new Form();
                form.FormID = this.View.FormID;

                form = DataService.LoadForm(form);

                FormUtil.SetFormTypeValues(form, awardSheet);

                form = DataService.SaveForm(form);
            }

            Load();
        }

        public void ShowSoldierFlaggedReason()
        {
            this.View.ShowSoldierFlaggedReason = this.View.SoldierFlagged == true;
        }

        public void SaveDefault()
        {
            AwardSheet awardSheet = new AwardSheet();

            awardSheet.Name = this.View.Name;
            awardSheet.Unit = this.View.Organization;
            awardSheet.PresentationDate = this.View.PresentationDate;
            awardSheet.PresentDutyPosition = this.View.DutyPosition;
            awardSheet.HighestAwardLevel = this.View.PreviousAward;
            awardSheet.SoldierFlagged = this.View.SoldierFlagged;
            awardSheet.SoldierFlaggedReason = this.View.SoldierFlaggedReason;
            awardSheet.StationTime = this.View.StationTime;
            awardSheet.AwardReason = this.View.AwardReason;
            awardSheet.AwardLevel = this.View.AwardLevel;
            awardSheet.Height = this.View.Height;
            awardSheet.Weight = this.View.Weight;
            awardSheet.Age = this.View.Age;
            awardSheet.BodyFatAuth = this.View.BodyFatAuth;
            awardSheet.BodyFatHas = this.View.BodyFatHas;
            awardSheet.Go = this.View.BodyFatGo;
            awardSheet.APFTDate = this.View.APFTDate;
            awardSheet.APFTPass = this.View.APFTPass;
            awardSheet.APFTProfile = this.View.Profile;
            awardSheet.TotalYearsService = this.View.TotalServiceYears;
            awardSheet.KeyPositions = this.View.KeyPositions;
            awardSheet.CurrentPositions = this.View.CurrentPositions;
            awardSheet.CurrentAwards = this.View.CurrentAwards;
            awardSheet.LeaderComments = this.View.LeaderComments;
            awardSheet.SeniorNCOComments = this.View.SeniorNCOComments;
            awardSheet.UnitSignDate = this.View.UnitSignDate;
            awardSheet.UnitComments = this.View.UnitComments;

            OrganizationFormDefault formDefault = new OrganizationFormDefault();
            formDefault.OrganizationGroupID = this.View.SubmitGroupID;
            formDefault.FormTypeID = this.View.FormTypeID;

            DataService.SaveOrganizationFormDefault(formDefault, awardSheet);
        }
    }
}
