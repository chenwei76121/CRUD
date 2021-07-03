using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPractice.Models
{
    public class JobModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(10,MinimumLength =3)]
        [Display(Name = "職缺代碼")]
        public string Code { get; set; }
        
        [Required]
        [Display(Name = "職缺名稱")]
        public string Name { get; set; }

        [Display(Name = "工作內容")]
        public string Desc { get; set; }

        [Display(Name = "最低薪資")]
        public int? MinSalary { get; set; }
        
        [Display(Name = "最高薪資")]
        public int? MaxSalary { get; set; }
        
        [Display(Name = "工作地點")]
        public string JobLocation { get; set; }




    }
}