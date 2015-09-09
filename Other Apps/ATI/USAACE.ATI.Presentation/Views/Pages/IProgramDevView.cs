using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.Common.Presentation;

namespace USAACE.ATI.Presentation.Views.Pages
{
    /// <summary>
    /// Interface for the ProgramDevView
    /// </summary>
    public interface IProgramDevView : IBaseView
    {
        /// <summary>
        /// The list of programs
        /// </summary>
        IList<Program> Programs { set; }

        /// <summary>
        /// The ID of the currently selected program
        /// </summary>
        Nullable<Int32> ProgramID { get; set; }

        /// <summary>
        /// The value for the program name
        /// </summary>
        String ProgramName { get; set; }

        /// <summary>
        /// The value for the program description
        /// </summary>
        String ProgramDescription { get; set; }

        /// <summary>
        /// The value for the fiscal year
        /// </summary>
        Nullable<Int16> FiscalYear { get; set; }

        /// <summary>
        /// The value for the program's locked status
        /// </summary>
        Nullable<Boolean> Locked { get; set; }

        /// <summary>
        /// The calculated value for if this is a new program
        /// </summary>
        Boolean IsNewProgram { set; }

        /// <summary>
        /// The value of the copied program name
        /// </summary>
        String CopyProgramName { get; set; }
    }
}
