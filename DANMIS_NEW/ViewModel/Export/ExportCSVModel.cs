using ResourceLibrary;
using System.ComponentModel.DataAnnotations;

namespace DANMIS_NEW.ViewModel
{
    public class ExportVotesCSVModel
    {
        [Display(Name = "品牌")]
        public string Brand { get; set; }
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Display(Name = "得票數")]
        public int Counts { get; set; }
        
    }
}