using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Business.Services;
using USAACE.ATI.Domain.Entities;

namespace USAACE.ATI.Business.Util
{
    /// <summary>
    /// A class containing several utility functions for dealing with POIs
    /// </summary>
    public static class POIUtil
    {
        /// <summary>
        /// Checks if a POI is currently used by a class in a locked program
        /// </summary>
        /// <param name="poi">The POI to check</param>
        /// <returns>True if POI is used in a locked program, False otherwise</returns>
        public static Boolean CheckLockedStatus(POI poi)
        {
            IDictionary<Nullable<Int32>, Course> courses = DataService.ListCourseDictionary();

            Class classItem = new Class();
            classItem.POIID = poi.POIID;

            IList<Class> classes = DataService.ListClasses(classItem);

            IList<Int32> courseIds = classes.Where(x => x.CourseID.HasValue).Select(x => x.CourseID.Value).Distinct().ToList();

            foreach (Int32 courseId in courseIds)
            {
                Course course = courses[courseId];
                Program program = DataService.GetProgram(new Program { ProgramID = course.ProgramID });

                if (program.Locked == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
