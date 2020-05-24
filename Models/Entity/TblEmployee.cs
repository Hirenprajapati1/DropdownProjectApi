using System;
using System.Collections.Generic;

namespace DropdownProject.Models.Entity
{
    public partial class TblEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Department { get; set; }

        public virtual TblDepartment DepartmentNavigation { get; set; }
    }
}
