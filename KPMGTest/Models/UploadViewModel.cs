using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KPMGTest.Models
{
    public class UploadViewModel
    {
        [Required(ErrorMessage = "Please choose a xlsx or csv file to upload.")]
        //[FileExtensions(Extensions = "xlsx")]
        public HttpPostedFileBase File { get; set; }
        public bool IsFirstRowAsColumnName { get; set; }
        public string TotalCount { get; set; }
    }
}