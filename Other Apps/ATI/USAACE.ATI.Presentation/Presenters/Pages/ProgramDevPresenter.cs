using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.Common.Presentation;
using USAACE.ATI.Business.Services;
using USAACE.ATI.Domain.Entities;

namespace USAACE.ATI.Presentation.Presenters.Pages
{
    /// <summary>
    /// Presenter for the ProgramDevView
    /// </summary>
    public class ProgramDevPresenter : BasePresenter
    {
        /// <summary>
        /// The ProgramDevView for the ProgramDevPresenter
        /// </summary>
        public new IProgramDevView View
        {
            get
            {
                return base.View as IProgramDevView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ProgramDevView
        /// </summary>
        /// <param name="view">The ProgramDevView</param>
        public ProgramDevPresenter(IProgramDevView view)
        {
            base.View = view;
        }

        /// <summary>
        /// Load action for the presenter
        /// </summary>
        public void Load()
        {
            this.View.Programs = DataService.GetPrograms().OrderBy(x => x.ProgramName).ToList();

            LoadProgram();
        }

        /// <summary>
        /// Loads the selected program
        /// </summary>
        public void LoadProgram()
        {
            if (this.View.ProgramID.HasValue)
            {
                Program program = new Program();
                program.ProgramID = this.View.ProgramID;

                program = DataService.GetProgram(program);

                this.View.ProgramName = program.ProgramName;
                this.View.ProgramDescription = program.ProgramDescription;
                this.View.FiscalYear = program.FiscalYear;
                this.View.Locked = program.Locked;
                this.View.IsNewProgram = false;
            }
            else
            {
                this.View.ProgramName = null;
                this.View.ProgramDescription = null;
                this.View.FiscalYear = null;
                this.View.Locked = null;
                this.View.IsNewProgram = true;
            }
        }

        /// <summary>
        /// Saves the selected program
        /// </summary>
        public void Save()
        {
            Program program = new Program();
            program.ProgramID = this.View.ProgramID;

            if (program.ProgramID.HasValue)
            {
                program = DataService.GetProgram(program);
            }

            program.ProgramName = this.View.ProgramName;
            program.ProgramDescription = this.View.ProgramDescription;
            program.FiscalYear = this.View.FiscalYear;
            program.Locked = this.View.Locked;

            program = DataService.SaveProgram(program);

            Load();

            this.View.ProgramID = program.ProgramID;

            LoadProgram();
        }

        /// <summary>
        /// Deletes the selected program
        /// </summary>
        public void Delete()
        {
            Program program = new Program();
            program.ProgramID = this.View.ProgramID;

            DataService.DeleteProgram(program);

            Load();
        }
        
        /// <summary>
        /// Copies the selected program
        /// </summary>
        public void CopyProgram()
        {
            Program program = new Program();
            program.ProgramID = this.View.ProgramID;

            Program copyProgram = DataService.CopyProgram(program, this.View.CopyProgramName);

            Load();

            this.View.ProgramID = copyProgram.ProgramID;

            LoadProgram();
        }
    }
}
