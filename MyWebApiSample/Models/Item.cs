using System.ComponentModel.DataAnnotations;

public class Item
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required!")]
    [StringLength(50, ErrorMessage = "Name Length cannot exceed 50 Characters!")]
    public string Name { get; set; }

    //[Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
    //ublic double Value { get; set; }
    }

