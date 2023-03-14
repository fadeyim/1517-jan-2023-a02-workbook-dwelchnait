using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace WestWindSystem.Entities
{
    [Table("Regions")]
    public class Region
    {
        /*******************************
         * [Key] is the default IDENTITY primary Key annotation
         * Compound key
         *   [Key,Column(Order=n)] place this annotation in front of each
         *                          part of your compound primary key
         * A non IDENTITY primary key
         *   [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
         *   The DatabaseGeneratedOption indicates that the user will supply
         *       the primary key value
         *****************************/ 
        [Key]
        public int RegionID { get; set; }

        //validation annotation
        //optional
        [Required(ErrorMessage ="Region description is a required field.")]
        [StringLength(50,ErrorMessage ="Region description is limited to 50 characters.")]
        public string RegionDescription { get; set; }


    //Example for a Computed field mapping
    //
    //    public decimal Subtotal { get; set; }
    //    public decimal Gst { get; set; }
    //    //total is a computed sql field
    //    //by using the .Computed EntityFramework DOES NOT expect
    //    //   data to be supplied for the field
    //    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    //    public decimal Total { get; set; }
    //}
}
