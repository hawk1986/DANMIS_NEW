using System;
using System.ComponentModel.DataAnnotations;

namespace DANMIS_NEW.ViewModel
{
    public class SimpleDataViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [Required()]
        public Guid ID { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        [Required()]
        public string Data { get; set; }
    }
}