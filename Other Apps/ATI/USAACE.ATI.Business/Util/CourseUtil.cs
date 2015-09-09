using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;

namespace USAACE.ATI.Business.Util
{
    /// <summary>
    /// A class containing several utility functions for dealing with courses
    /// </summary>
    public static class CourseUtil
    {
        /// <summary>
        /// Gets the course display value based on the course, list of systems, and list of course types
        /// </summary>
        /// <param name="course">The course to analyze</param>
        /// <param name="systems">The list of systems for determining appropriate system</param>
        /// <param name="courseTypes">The list of course types for determining appropriate course type</param>
        /// <returns>The display value for the course</returns>
        public static String GetCourseDisplayValue(Course course, IList<USAACE.ATI.Domain.Entities.System> systems, IList<CourseType> courseTypes)
        {
            return course.CourseName;

            /*USAACE.ATI.Domain.Entities.System system = systems.FirstOrDefault(x => x.SystemID == course.SystemID);

            CourseType type = courseTypes.FirstOrDefault(x => x.CourseTypeID == course.CourseTypeID);

            return GetCourseDisplayValue(course, system, type);*/
        }

        /// <summary>
        /// Gets the course display value based on the course, system, and course type
        /// </summary>
        /// <param name="course">The course to analyze</param>
        /// <param name="system">The system of the course</param>
        /// <param name="courseType">The course type</param>
        /// <returns>The display value for the course</returns>
        public static String GetCourseDisplayValue(Course course, USAACE.ATI.Domain.Entities.System system, CourseType courseType)
        {
            return course.CourseName;

            /*if (courseType != null)
            {
                return String.Format("{0} {1} {2} {3}", system != null ? system.SystemName : null, courseType != null ? courseType.CourseTypeName : null, course.CourseName,
                        course.CreateDate.HasValue ? course.CreateDate.Value.ToString("d MMM yyyy").ToUpper() : null);
            }
            else
            {
                return course.CourseName;
            }*/
        }
    }
}
